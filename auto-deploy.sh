#!/bin/bash

if [ -z "$1" ]; then
  echo "Please provide the name argument for appsettings.json."
  exit 1
fi

if [ -z "$2" ]; then
  echo "Please provide the deployment environment (test or prod)."
  exit 1
fi

NAME="$1"
ENVIRONMENT="$2"

if [ "$ENVIRONMENT" != "test" ] && [ "$ENVIRONMENT" != "prod" ]; then
  echo "Invalid deployment environment. Only 'test' and 'prod' are supported."
  exit 1
fi

source secrets.sh

dotnet build ./WebApi/WebApi.csproj -c Release -o ./build
dotnet publish ./WebApi/WebApi.csproj -c Release -o ./publish

# Check if appsettings.name.json exists
if [ ! -e "./WebApi/appsettings.$NAME.json" ]; then
  echo "appsettings.$NAME.json does not exist."
  exit 1
fi

DEPLOY_PATH=$(cat ./WebApi/appsettings.$NAME.json | jq '.AutoDeploy.Folder' | tr -d '"')

# Establish connection and delete existing files in the remote directory
sftp $USERNAME@$SERVER << EOF
  rm $DEPLOY_PATH/*
  bye
EOF

# Copy local files to the remote server
scp -r ./publish/* $USERNAME@$SERVER:$DEPLOY_PATH/
scp ./Dockerfile $USERNAME@$SERVER:$DEPLOY_PATH/
scp ./docker-compose.yml $USERNAME@$SERVER:$DEPLOY_PATH/

# Connect to the server and run docker-compose up based on the environment
ssh $USERNAME@$SERVER << EOF
  cd $DEPLOY_PATH 
  mv ./appsettings.$NAME.json ./appsettings.json
  
  # Remove all appsettings.*.json files except for appsettings.json
  find . -maxdepth 1 -name 'appsettings.*.json' ! -name 'appsettings.json' -type f -exec rm {} \;

  docker-compose down
  docker-compose rm
  if [ "$ENVIRONMENT" == "test" ]; then
    docker-compose up --build -d test-vpn-rest 
  elif [ "$ENVIRONMENT" == "prod" ]; then
    docker-compose up --build -d  prod-vpn-rest 
  fi
EOF
