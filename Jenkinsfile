pipeline {
    agent any

    stages {

        stage("Build") {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage("Run-Unit-Tests") {
            steps {
                bat 'dotnet test ./CaffeineCrashProvider.Test/CaffeineCrashProvider.Test.csproj -c Release -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura -p:CoverletOutput=./test/coverage/providerCoverage.xml -p:Exclude="[xunit.*]*" -l:"JUnit;LogFilePath=$WORKSPACE/test/results/providerResults.xml" --no-restore --no-build'
                bat 'dotnet test ./CaffeineCrashCue.Test/CaffeineCrashCue.Test.csproj -c Release -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura -p:CoverletOutput=./test/coverage/cueCoverage.xml -p:Exclude="[xunit.*]*" -l:"JUnit;LogFilePath=$WORKSPACE/test/results/cueResults.xml" --no-restore --no-build'
            }
        }
	}
	post {
	    always {
	        junit '**/test/results/*.xml'
            cobertura coberturaReportFile: '**/test/coverage/*.xml'
	    }
	}
}