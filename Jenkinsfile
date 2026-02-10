
pipeline {
    agent any

    environment {
        DOTNET = '/opt/homebrew/bin/dotnet'
        PATH = "${DOTNET_HOME}:${env.PATH}"

        ASPNETCORE_URLS = 'http://localhost:5000'
        PUBLISH_DIR = 'publish'
        APP_DLL = 'MydeploymentProject.dll'
    }

    stages {

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build -c Release'
            }
        }

        stage('Publish') {
            steps {
                sh "dotnet publish -c Release -o ${PUBLISH_DIR}"
            }
        }

        stage('Deploy (Local)') {
            steps {
                sh '''
                echo "Stopping old app if running..."
                pkill -f ${APP_DLL} || true

                echo "Starting application..."
                nohup dotnet ${PUBLISH_DIR}/${APP_DLL} > app.log 2>&1 &
                '''
            }
        }

        stage('Smoke Test') {
            steps {
                sh '''
                sleep 5
                curl -f http://localhost:5000
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

