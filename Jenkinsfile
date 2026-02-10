pipeline {
    agent any

    environment {
        DOTNET_ROOT = "/opt/homebrew/bin"
        PATH = "${DOTNET_ROOT}:${env.PATH}"
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
                sh 'dotnet publish MydeploymentProject.csproj -c Release -o publish'
            }
        }
    }

    post {
        success {
            echo 'Archiving publish artifacts'
            archiveArtifacts artifacts: 'publish/**', fingerprint: true
        }
    }
}
