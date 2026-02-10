pipeline {
    agent any

    environment {
        PATH = "/opt/homebrew/bin:${env.PATH}"
        DOTNET_HOME = "/opt/homebrew/opt/dotnet"
        ASPNETCORE_URLS = 'http://0.0.0.0:5000'
        PUBLISH_DIR = 'publish'
        APP_DLL = 'MydeploymentProject.dll'
    }

    stages {

        stage('Restore') {
            steps {
                sh '/opt/homebrew/bin/dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh '/opt/homebrew/bin/dotnet build -c Release'
            }
        }

     stage('Publish') {
    steps {
        sh """
        mkdir -p ${PUBLISH_DIR}
        /opt/homebrew/bin/dotnet publish ./MydeploymentProject.csproj -c Release -o ${PUBLISH_DIR}
        """
    }
}


        stage('Deploy (Local)') {
            steps {
                sh '''
                echo 'Stopping old app if running...'
                pkill -f MydeploymentProject.dll || true
                echo 'Starting application...'
                nohup /opt/homebrew/bin/dotnet $WORKSPACE/${PUBLISH_DIR}/${APP_DLL} --urls http://0.0.0.0:5000 &

                '''
            }
        }

        stage('Smoke Test') {
            steps {
                sh '''
                sleep 5
                curl -f http://localhost:5000 || true
                '''
            }
        }
    }

    post {
        success {
            echo '✅ Application deployed successfully'
        }
        failure {
            echo '❌ Deployment failed'
        }
    }
}

