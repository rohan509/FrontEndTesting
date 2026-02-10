pipeline {
    agent any

    environment {
        DOTNET = '/opt/homebrew/bin/dotnet'
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
        DOTNET_NOLOGO = '1'
    }

    stages {

        stage('Check dotnet') {
            steps {
                sh '''
                    echo "PATH=$PATH"
                    $DOTNET --version
                '''
            }
        }

        stage('Restore') {
            steps {
                sh '$DOTNET restore'
            }
        }

        stage('Build') {
            steps {
                sh '$DOTNET build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                sh '''
                    $DOTNET publish \
                    --configuration Release \
                    --output publish
                '''
            }
        }
    }

    post {
        success {
            echo "✅ dotnet works in Jenkins"
        }
        failure {
            echo "❌ dotnet still not visible"
        }
    }
}
