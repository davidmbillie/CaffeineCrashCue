pipeline {
    agent any

    stages {

        stage("Build") {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }
		
	}
	post {
	    always {
	        //junit '**/test/results/*.xml'
            //cobertura coberturaReportFile: '**/test/coverage/*.xml'
            //codometer 'teamName', 'projectName'
            step([$class: 'CodometerBuildStep', programName: 'program', projectName: 'project', teamName: 'team'])
	    }
	}
}