pipeline {
    agent any

    environment {
        DOTNET_ROOT = "/opt/homebrew/bin"
        PATH = "${DOTNET_ROOT}:${env.PATH}"
    }

    stages {

        stage('Restore') {
            steps {
                echo 'Restoring NuGet packages'
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                echo 'Building application'
                sh 'dotnet build -c Release'
            }
        }

        stage('Publish') {
            steps {
                echo 'Publishing application'
                sh 'dotnet publish MydeploymentProject.csproj -c Release -o publish'
            }
        }

        stage('Run (Smoke Test)') {
            steps {
                sh '''
                echo "Starting app..."
                cd publish
                dotnet MydeploymentProject.dll &
                APP_PID=$!
                sleep 5
                echo "App started, PID=$APP_PID"
                kill $APP_PID
                echo "App stopped"
                '''
            }
        }
    }

    post {
        success {
            echo 'Archiving publish artifacts'
            archiveArtifacts artifacts: 'publish/**', fingerprint: true
        }
        failure {
            echo 'Pipeline failed'
        }
    }
}
