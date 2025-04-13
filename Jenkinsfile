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
                git branch: 'main',
                url: 'https://github.com/ProductivityTools-Trips/ProductivityTools.Trips.Api.git'
            }
        }
        stage('Build PTTrips') {
            steps {
                bat(script: "dotnet publish ProductivityTools.Trips.Api.sln -c Release ", returnStdout: true)
            }
        }
        stage('Delete DB Migration directory') {
            steps {
                bat('if exist "C:\\Bin\\DbMigration\\PTTrips.Api" RMDIR /Q/S "C:\\Bin\\DbMigration\\PTTrips.Api"')
            }
        }
        stage('Copy DB Migration Files') {
            steps {
                bat('xcopy "ProductivityTools.Trips.Api.DbUp\\bin\\Release\\net9.0\\publish" "C:\\Bin\\DbMigration\\PTTrips.Api\\" /O /X /E /H /K')
            }
        }

        stage('Run DB Migration files') {
            steps {
                bat('C:\\Bin\\DbMigration\\PTTrips.Api\\ProductivityTools.Trips.Api.DbUp.exe')
            }
        }

        stage('Create PTTrips IIS Page') {
            steps {
                powershell('''
                function CheckIfExist($Name){
                    cd $env:SystemRoot\\system32\\inetsrv
                    $exists = (.\\appcmd.exe list sites /name:$Name) -ne $null
                    Write-Host $exists
                    return  $exists
                }
                
                function Create($Name,$HttpbBnding,$PhysicalPath){
                    $exists=CheckIfExist $Name
                    if ($exists){
                        write-host "Web page already existing"
                    }
                    else
                    {
                        write-host "Creating app pool"
                        .\\appcmd.exe add apppool /name:$Name /managedRuntimeVersion:"v4.0" /managedPipelineMode:"Integrated"
                        write-host "Creating webage"
                        .\\appcmd.exe add site /name:$Name /bindings:http://$HttpbBnding /physicalpath:$PhysicalPath
                        write-host "assign app pool to the website"
                        .\\appcmd.exe set app "$Name/" /applicationPool:"$Name"


                    }
                }
                Create "PTTrips" "*:8002"  "C:\\Bin\\IIS\\PTTrips\\"                
                ''')
            }
        }

        stage('Stop PTTrips on IIS') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd stop site /site.name:PTTrips')
            }
        }

        stage('Delete PTTrips IIS directory') {
            steps {
              powershell('''
                if ( Test-Path "C:\\Bin\\IIS\\PTTrips")
                {
                    while($true) {
                        if ( (Remove-Item "C:\\Bin\\IIS\\PTTrips" -Recurse *>&1) -ne $null)
                        {  
                            write-output "removing faild we should wait"
                        }
                        else 
                        {
                            break 
                        } 
                    }
                  }
              ''')

            }
        }

        // stage('deleteIisDir') {
        //     steps {
                
        //         retry(5) {
        //             bat('if exist "C:\\Bin\\IIS\\PTTrips" RMDIR /Q/S "C:\\Bin\\IIS\\PTTrips"')
        //         }

        //     }
        // }
        stage('Copy PTTrips Data') {
            steps {
                bat('xcopy "ProductivityTools.Trips.Api\\bin\\Release\\net9.0\\publish" "C:\\Bin\\IIS\\PTTrips\\" /O /X /E /H /K')
				                      
            }
        }

        stage('Start PT Trips site on IIS') {
            steps {
                bat('%windir%\\system32\\inetsrv\\appcmd start site /site.name:PTTrips')
            }
        }

        stage ('Get User'){
            steps{
                bat('whoami')
            }
        }
        stage('Create Login PTTrips on SQL2022') {
             steps {
                 bat('sqlcmd -S ".\\SQL2022" -q "CREATE LOGIN [IIS APPPOOL\\PTTrips] FROM WINDOWS;"')
             }
         }
		
        stage('byebye') {
            steps {
                // Get some code from a GitHub repository
                //				#Add-SqlLogin -ServerInstance ".\\sql2022" -LoginName "IIS APPPOOL\\PTTrips" -LoginType "WindowsUser" -DefaultDatabase "PTTrips"
                //	If(-not(Get-InstalledModule SQLServer -ErrorAction silentlycontinue)){
				//	Install-Module SQLServer -Confirm:$False -Force -AllowClobber 
				//}
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
