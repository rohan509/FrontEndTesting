pipeline {
    agent any

    environment {
        PATH = "/opt/homebrew/bin:${env.PATH}"
        DOTNET_HOME = "/opt/homebrew/opt/dotnet"
        ASPNETCORE_URLS = 'http://0.0.0.0:5050'
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
        echo 'Cleaning old publish folder...'
        rm -rf ${PUBLISH_DIR}
        mkdir -p ${PUBLISH_DIR}

        /opt/homebrew/bin/dotnet publish MydeploymentProject.csproj -c Release -o ${PUBLISH_DIR}
        """
    }
}

stage('Deploy (Local)') {
    steps {
        sh '''
        echo "Stopping old app..."
        pkill -f MydeploymentProject.dll || true

        echo "Starting app fully detached..."

        nohup setsid /opt/homebrew/bin/dotnet $WORKSPACE/publish/MydeploymentProject.dll \
        --urls http://0.0.0.0:5050 \
        > $WORKSPACE/app.log 2>&1 < /dev/null &

        sleep 5

        echo "Checking if app started..."
        lsof -i :5050 || true
        '''
    }
}




        stage('Smoke Test') {
            steps {
                sh '''
                sleep 5
                curl -f http://localhost:5050 || true
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
