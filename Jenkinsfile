def PROJECT_NAME = "Jenkins.IO"
def CUSTOM_WORKSPACE = "C:\\Game Dev\\Unity\\${PROJECT_NAME}"
def UNITY_VERSION = "6000.0.43f1"
def UNITY_INSTALLATION = "C:\\Program Files\\Unity\\Hub\\Editor\\${UNITY_VERSION}\\Editor"

pipeline {
    environment {
        PROJECT_PATH = "${CUSTOM_WORKSPACE}"
        BUILD_WINDOWS = "true"
    }
    agent any
    
    stages {
        stage('Test Windows') {
            when { expression { env.BUILD_WINDOWS == 'true' } }
            steps {
                dir("${CUSTOM_WORKSPACE}") {
                    script {
                        def unityExe = "${UNITY_INSTALLATION}\\Unity.exe"
                        def resultsPath = "TestResults.xml"
                        
                        bat "\"${unityExe}\" -runTests -batchmode -nographics -projectPath \"${env.PROJECT_PATH}\" -testPlatform EditMode -testResults \"${resultsPath}\""
                    }
                    nunit testResultsPattern: 'TestResults.xml'
                }
            }
        }
        
        stage('Build Windows') {
            when { expression { env.BUILD_WINDOWS == 'true' } }
            steps {
                dir("${CUSTOM_WORKSPACE}") {
                    script {
                        def unityExe = "${UNITY_INSTALLATION}\\Unity.exe"
                        bat "\"${unityExe}\" -quit -batchmode -projectPath \"${env.PROJECT_PATH}\" -executeMethod Build.BuildScript.PerformBuild -logFile -"
                    }
                }
            }
        }
    }
}