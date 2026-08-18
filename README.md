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

