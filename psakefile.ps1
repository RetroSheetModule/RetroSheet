Properties {
 $moduleName = "RetroSheet"
 $orgName = "RetrosheetPOSH"
 $Github = "https://github.com/$($orgName)/$($moduleName)"
 $PoshGallery = "https://www.powershellgallery.com/packages/$($moduleName)"
 $Nuget = "https://www.nuget.org/packages/$($moduleName)/"
 $DiscordChannel = "https://discord.com/channels/1044305359021555793/1122983144342171809"
}
Task default -depends UpdateReadme

Task UpdateReadme -Description "Update the README file" -depends CleanProject, BuildProject -Action {
 $readMe = Get-Item .\README.md

 $TableHeaders = "| Latest Version | Nuget Gallery | Issues | License | Discord |"
 $Columns = "|-----------------|----------------|----------------|----------------|----------------|"
 $VersionBadge = "[![Latest Version](https://img.shields.io/github/v/tag/$($orgName)/$($moduleName))](https://github.com/$($orgName)/$($moduleName)/tags)"
 $GalleryBadge = "[![Nuget Gallery](https://img.shields.io/nuget/dt/$($moduleName))](https://www.nuget.org/packages/$($moduleName)/)"
 $IssueBadge   = "[![GitHub issues](https://img.shields.io/github/issues/$($orgName)/$($moduleName))](https://github.com/$($orgName)/$($moduleName)/issues)"
 $LicenseBadge = "[![GitHub license](https://img.shields.io/github/license/$($orgName)/$($moduleName))](https://github.com/$($orgName)/$($moduleName)/blob/main/LICENSE)"
 $DiscordBadge = "[![Discord Server](https://assets-global.website-files.com/6257adef93867e50d84d30e2/636e0b5493894cf60b300587_full_logo_white_RGB.svg)]($($DiscordChannel))"

 Write-Output $TableHeaders | Out-File $readMe.FullName -Force
 Write-Output $Columns | Out-File $readMe.FullName -Append
 Write-Output "| $($VersionBadge) | $($GalleryBadge) | $($IssueBadge) | $($LicenseBadge) | $($DiscordBadge) |" | Out-File $readMe.FullName -Append
}

Task NewTaggedRelease -Description "Create a tagged release" -depends CleanProject, BuildProject -Action {
 if (!(Get-Module -Name $moduleName )) { Import-Module -Name ".\Module\$($moduleName).psd1" }
 $Version = (Get-Module -Name $moduleName | Select-Object -Property Version).Version.ToString()
 git tag -a v$version -m "$($moduleName) Version $($Version)"
 git push origin v$version
}

Task Post2Discord -Description "Post a message to discord" -Action {
 $project = [xml](Get-Content RetroSheet.csproj)
 $version = $project.Project.PropertyGroup.Version
 $Discord = Get-Content ..\discord.retrosheet | ConvertFrom-Json
 $Discord.message.content = "Version $($version) of $($moduleName) released. Please visit Github ($($Github)) or PowershellGallery ($($PoshGallery)) to download."
 Invoke-RestMethod -Uri $Discord.uri -Body ($Discord.message | ConvertTo-Json -Compress) -Method Post -ContentType 'application/json; charset=UTF-8'
}

Task CleanProject -Description "Clean the project before building" -Action {
 dotnet clean .\RetroSheet.csproj
}

Task BuildProject -Description "Build the project" -Action {
 dotnet build .\RetroSheet.csproj -c Release
}

Task NugetPush -Description "Push nuget to PowerShell Gallery" -Action {
 $config = [xml](Get-Content ..\nuget.config)
 nuget push bin\Release\*.nupkg -NonInteractive -ApiKey "$($config.configuration.apikeys.add.value)" -ConfigFile ..\nuget.config
}
