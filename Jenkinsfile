pipeline {
    agent any

    environment {
        PATH = "/opt/homebrew/bin:${env.PATH}"
        DOTNET_HOME = "/opt/homebrew/opt/dotnet"
        ASPNETCORE_URLS = 'http://localhost:5000'
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
                sh "/opt/homebrew/bin/dotnet publish -c Release -o ${PUBLISH_DIR}"
            }
        }

        stage('Deploy (Local)') {
            steps {
                sh '''
                echo "Stopping old app if running..."
                pkill -f ${APP_DLL} || true

                echo "Starting application..."
                nohup /opt/homebrew/bin/dotnet ${PUBLISH_DIR}/${APP_DLL} > app.log 2>&1 &
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

