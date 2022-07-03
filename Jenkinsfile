properties([pipelineTriggers([githubPush()])])

pipeline {
    agent any

    stages {
        stage('hello') {
            steps {
                // Get some code from a GitHub repository
                echo 'hello'
            }
        }
        stage('deleteWorkspace') {
            steps {
                deleteDir()
            }
        }
        stage('clone') {
            steps {
                // Get some code from a GitHub repository
                git branch: 'master',
                url: 'https://github.com/ProductivityTools-Trips/ProductivityTools.Trips.Api.git'
            }
        }
        stage('build') {
            steps {
                bat(script: "dotnet publish ProductivityTools.Trips.Api.sln -c Release ", returnStdout: true)
            }
        }
        stage('deleteDbMigratorDir') {
            steps {
                bat('if exist "C:\\Bin\\TripsDbUp" RMDIR /Q/S "C:\\Bin\\TripsDbUp"')
            }
        }
        stage('copyDbMigratdorFiles') {
            steps {
                bat('xcopy "c:\\Program Files (x86)\\Jenkins\\workspace\\Trips.Api\\ProductivityTools.Trips.Api.DbUp\\bin\\Release\\net6.0\\publish" "C:\\Bin\\TripsDbUp\\" /O /X /E /H /K')
            }
        }

        stage('runDbMigratorFiles') {
            steps {
                bat('C:\\Bin\\TripsDbUp\\ProductivityTools.Trips.Api.DbUp.exe')
            }
        }

        stage('stopMeetingsOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd stop site /site.name:Trips')
            }
        }

        stage('deleteIisDir') {
            steps {
                retry(5) {
                    bat('if exist "C:\\Bin\\TripsApi" RMDIR /Q/S "C:\\Bin\\TripsApi"')
                }

            }
        }
        stage('copyIisFiles') {
            steps {
                bat('xcopy "c:\\Program Files (x86)\\Jenkins\\workspace\\Trips.Api\\ProductivityTools.Trips.Api\\bin\\Release\\net6.0\\publish" "C:\\Bin\\TripsApi\\" /O /X /E /H /K')
				                      
            }
        }

        stage('startMeetingsOnIis') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd start site /site.name:Trips')
            }
        }
        stage('byebye') {
            steps {
                // Get some code from a GitHub repository
                echo 'byebye1'
            }
        }
    }
	post {
		always {
            emailext body: "${currentBuild.currentResult}: Job ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n More info at: ${env.BUILD_URL}",
                recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
                subject: "Jenkins Build ${currentBuild.currentResult}: Job ${env.JOB_NAME}"
		}
	}
}