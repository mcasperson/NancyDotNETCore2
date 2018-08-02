pipeline {
    agent {
		kubernetes {
			label 'mypod'
			yaml """
apiVersion: v1
kind: Pod
metadata:
spec:
  containers:
  - name: dotnet
    image: microsoft/dotnet
    command:
    - cat
    tty: true
"""
		}
	}
    stages {
        stage ('Build') {
            steps {
				container('dotnet') {
					sh 'dotnet restore'
					sh 'dotnet build'
				}
            }
        }
    }
}