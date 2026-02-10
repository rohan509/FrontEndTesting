pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
        DOTNET_NOLOGO = '1'
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Check dotnet') {
            steps {
                sh 'dotnet --version'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                sh '''
                    dotnet publish \
                    --configuration Release \
                    --output publish
                '''
            }
        }

        stage('Deploy (Local)') {
            steps {
                sh '''
                    echo "Stopping existing app (if any)..."
                    pkill -f "dotnet FrontEndTesting.dll" || true

                    echo "Starting app..."
                    nohup dotnet publish/FrontEndTesting.dll > app.log 2>&1 &
                '''
            }
        }

        stage('Smoke Test') {
            steps {
                sh '''
                    sleep 5
                    curl -I http://localhost:5000 || true
                '''
            }
        }
    }

    post {
        success {
            echo "✅ Build & deployment successful"
        }
        failure {
            echo "❌ Build failed"
        }
    }
}
