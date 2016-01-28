Param(
    [string]$SourceDirectory = ""
)

function Get-ScriptDirectory { 
    Split-Path $script:MyInvocation.MyCommand.Path
}

function GetDeploymentDirectory {
  $scriptPath = Get-ScriptDirectory;
  $configFile = "$scriptPath\..\App.config";

  [xml]$fileContents = Get-Content -Path $configFile
  return $fileContents.configuration.deploypath + "\Umbraco\ucommerce\Apps\" + $fileContents.configuration.appname;
}

function FileExtensionBlackList {
  return "*.cd", 
  "*.cs", 
  "*.dll", 
  "*.xml",
  "*.pdb",
  "*.csproj*", 
  "*.cache";  
}

function GetFileExtensionBlackList {
  $scriptPath = Get-ScriptDirectory;
  $configFile = "$scriptPath\..\App.config";

  [xml]$fileContents = Get-Content -Path $configFile
  $option = [System.StringSplitOptions]::RemoveEmptyEntries
  return $fileContents.configuration.excludefiles.Split(",", $option) + (FileExtensionBlackList);
}

function DllExtensionBlackList {
  return "UCommerce.*",
    "Castle.Core.dll",
    "Castle.Windsor.dll",
    "ClientDependency.Core.dll",
    "Esent.Interop.dll",
    "FluentNHibernate.dll",
    "ICSharpCode.NRefactory.dll",
    "ICSharpCode.NRefactory.CSharp.dll",
    "Iesi.Collections.dll",
    "Jint.Raven.dll",
    "log4net.dll",
    "Lucene.Net.dll",
    "Lucene.Net.Contrib.Spatial.NTS.dll",
    "Microsoft.CompilerServices.AsyncTargetingPack.Net4.dll",
    "Microsoft.WindowsAzure.Storage.dll",
    "NHibernate.dll",
    "Raven.Abstractions.dll",
    "Raven.Client.Embedded.dll",
    "Raven.Client.Lightweight.dll",
    "Raven.Database.dll",
    "ServiceStack.Common.dll";
    "ServiceStack.dll",
    "ServiceStack.Interfaces.dll",
    "ServiceStack.ServiceInterface.dll",
    "ServiceStack.Text.dll",
    "Spatial4n.Core.NTS.dll";  
}

function GetDllExtensionBlacklist {
  $scriptPath = Get-ScriptDirectory;
  $configFile = "$scriptPath\..\App.config";

  [xml]$fileContents = Get-Content -Path $configFile
  $option = [System.StringSplitOptions]::RemoveEmptyEntries
  return $fileContents.configuration.excludedlls.Split(",", $option) + (DllExtensionBlackList);
}

function GetFilesToCopy($path){
	return Get-ChildItem $path -name -recurse -include *.* -exclude (GetFileExtensionBlackList);
}

function CopyFiles ($targetDirectory) {
	$filesToCopy = GetFilesToCopy($SourceDirectory);
	
	if(!$filesToCopy)
	{
		return;
	}

	foreach($fileToCopy in $filesToCopy)
	{
        if($fileToCopy -notlike '*bin*' -And $fileToCopy -notlike '*obj*')
		{
			$sourceFile = $SourceDirectory + "\" + $fileToCopy;
			$targetFile = $targetDirectory + "\" + $fileToCopy;
		
			# Create the folder structure and empty destination file,
			New-Item -ItemType File -Path $targetFile -Force
		
			Copy-Item $sourceFile $targetFile -Force
		}
	}
}


function GetDllesToCopy($path){
	return Get-ChildItem $path -name -recurse -include "*.dll*","*.pdb*"  -exclude (GetDllExtensionBlacklist);
}

function CopyDllToBin ($targetDirectory) {
	$filesToCopy = GetDllesToCopy($SourceDirectory + "\bin");

	if(!$filesToCopy)
	{
		return;
	}

	foreach($fileToCopy in $filesToCopy)
	{
        if($fileToCopy -notlike '*roslyn*')
		{
		    $sourceFile = $SourceDirectory + "\bin\" + $fileToCopy;
		    $targetFile = $targetDirectory + "\bin\" + $fileToCopy;	
            
		    New-Item -ItemType File -Path $targetFile -Force	
		
		    Copy-Item $sourceFile $targetFile -Force
        }
	}
}

function Run-It {
    $targetDirectory = GetDeploymentDirectory;
    
	Remove-Item $targetDirectory -Force -Recurse

	CopyFiles($targetDirectory);
	CopyDllToBin($targetDirectory);
    
    write-host 'Extracted app to' $targetDirectory;   
}

Run-It
