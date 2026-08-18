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

