pipeline {
    agent any

    environment {
        DOTNET_ROOT = "/opt/homebrew/bin"
        PATH = "${DOTNET_ROOT}:${env.PATH}"
    }

    stages {
        stage('Check Dotnet') {
            steps {
                sh 'dotnet --version'
            }
        }
    }
}
