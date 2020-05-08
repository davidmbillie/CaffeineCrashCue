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
                bat 'dotnet test ./CaffeineCrashProvider.Test/CaffeineCrashProvider.Test.csproj -c Release -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura -p:CoverletOutput=./test/coverage/coreCoverage.xml -p:Exclude="[xunit.*]*" -l:"JUnit;LogFilePath=$WORKSPACE/test/results/coreResults.xml" --no-restore --no-build'
            }
        }
	}
}