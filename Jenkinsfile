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
                sh 'dotnet publish -c Release -o publish'
            }
        }
    }

    post {
        success {
            echo 'CI Pipeline completed successfully 🎉'
        }
        failure {
            echo 'CI Pipeline failed ❌'
        }
    }
}
