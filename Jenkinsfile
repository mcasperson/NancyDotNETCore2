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
  - name: octo
    image: octopusdeploy/octo
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
					sh 'dotnet pack'
				}
            }
        }
		stage ('Publish') {
            steps {
				container('octo') {
					withCredentials([string(credentialsId: 'OctopusAPIKey', variable: 'APIKey')]) {
						timestamps {
							sh """
								octo push --package NancyFXKestrel/bin/Debug/NancyFXKestrel.1.0.0.nupkg --replace-existing --server https://master.octopushq.com --apiKey ${APIKey}
								octo create-release --progress --project=Jenkins --server https://master.octopushq.com --apiKey ${APIKey}
								octo deploy-release --progress --project=Jenkins --deployto=Java --version=latest --server https://master.octopushq.com --deploymenttimeout 10:00:00 --apiKey ${APIKey}
							"""
						}
					}
				}
            }
        }
    }
}