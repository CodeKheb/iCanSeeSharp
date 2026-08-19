# C# larp on Arch
Install dotnet via pacman
```
sudo pacman -S dotnet-sdk
```
Install roslyn lsp
```
dotnet tool install --global roslyn-language-server --prerelease
```

# C# larp on Windows (For Compiling in VM)
Install git via winget
```
winget install --id Git.Git -e --source winget
```
Install dotnet via winget
```
winget install --id Microsoft.DotNet.SDK.10 -e --source winget
```
# OpenSSH on powershell
Search
``` 
Get-WindowsCapability -Online | Where-Object Name -like 'OpenSSH.Server*'
```
Install using local system 
```
DISM.exe /Online /Add-Capability /CapabilityName:OpenSSH.Server~~~~0.0.1.0
```
Start
```
Start-Service sshd
```
On Startup
```
Set-Service -Name sshd -StartupType Automatic
```
TCP Port 22 Firewall
```
New-NetFirewallRule -Name "OpenSSH-Inbound" -DisplayName "OpenSSH" -Direction Inbound -Action Allow -Protocol TCP -LocalPort 22
```
Add arch to authorized_keys
```
New-Item -ItemType Directory -Force -Path $env:USERPROFILE\.ssh; Set-Content -Path $env:USERPROFILE\.ssh\authorized_keys -Value 'Arch_SSH_key'
```
Add to administrators_authorized_keys
```
Set-Content -Path C:\ProgramData\ssh\administrators_authorized_keys -Value 'Arch_SSH_key'
```
Grant permissions
```
icacls %USERPROFILE%\.ssh\authorized_keys /inheritance:r /grant %USERNAME%:F /grant SYSTEM:F
icacls %PROGRAMDATA%\ssh\administrators_authorized_keys /inheritance:r /grant BUILTIN\Administrators:F /grant SYSTEM:F
```

# VirtualBox config
Forward port 2222 to 22 in vm
```
# Running
VBoxManage controlvm "Winbloat" natpf1 "guestssh,tcp,,2222,,22"
```
```
# Not Running
VBoxManage modifyvm "Winbloat" --natpf1 "guestssh,tcp,,2222,,22"

```
# Script to ssh
Copy to binary folder
```
sudo cp deploy-wpf.sh /usr/local/bin/deploy-wpf
```

Deploy WPF app on windows 11 through ssh
``` bash 
./deploy-wpf.sh <ssh-name>
```
Debug
``` bash
./deploy-wpf.sh <ssh-name> debug
```

## Dotnet commands
Project templates
```
dotnet new list 
```
Run
```
dotnet run
```


## Get Started with [Microsoft C#](https://learn.microsoft.com/en-us/training/paths/get-started-c-sharp-part-1/)

