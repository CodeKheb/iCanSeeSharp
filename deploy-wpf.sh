#!/bin/bash

# deploy-wpf.sh — sync project to remote host and run
# Usage: ./deploy-wpf.sh <ssh-host> [release|debug]
#
# Set WPF_REMOTE_USER in your .zshrc:
#   export WPF_REMOTE_USER="Winbloat"

set -e

HOST="${1:?Usage: deploy-wpf.sh <ssh-host> [release|debug]}"
CONFIG="${2:-Release}"
REMOTE_USER="${WPF_REMOTE_USER}"
PROJECT_NAME="$(basename "$(pwd)")"
REMOTE_PATH="C:/Users/$REMOTE_USER/$PROJECT_NAME"
TASK_NAME="RunWpf_${PROJECT_NAME}"

echo "Syncing $PROJECT_NAME to $HOST..."

tar cz \
  --exclude='.git' \
  --exclude='bin' \
  --exclude='obj' \
  --exclude='*.user' \
  -C . . | \
  ssh "$HOST" "powershell -Command \"if (!(Test-Path '$REMOTE_PATH')) { New-Item -ItemType Directory -Path '$REMOTE_PATH' -Force | Out-Null }; tar xz -C '$REMOTE_PATH'\""

echo "Running on $HOST..."
ssh "$HOST" "schtasks /create /tn \"$TASK_NAME\" /tr \"cmd /c cd /d $REMOTE_PATH && dotnet run -c $CONFIG\" /sc once /st 00:00 /rl HIGHEST /f >nul 2>&1 && schtasks /run /tn \"$TASK_NAME\""

echo "Done! App should be running on $HOST."
