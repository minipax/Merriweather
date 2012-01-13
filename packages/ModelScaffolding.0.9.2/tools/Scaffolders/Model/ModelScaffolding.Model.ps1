[T4Scaffolding.Scaffolder(Description = "Creates model with properties (and optional controller). You can specify property types or can use conventions.")][CmdletBinding()]
param(
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$Model,
	[string[]]$Properties,
	[string]$Folder,
	[string]$DbContextType,
	[string]$Area,
	[string]$Layout,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false,
	[switch]$NoAnnotations = $false,
	[switch]$Controller = $false,
	[switch]$Repository = $false,
	[switch]$NoChildItems = $false,
	[switch]$NoTypeWarning = $false,
	[switch]$ReferenceScriptLibraries = $false
)

# Parses names like Name[99]? to {Name="Name"; MaxLength=99; Required=$false}
function ParseName([string]$name) {
	$result = @{Name = $name; MaxLength = 0; Required = $true; Type = ""; Reference=""}
	# parse reference if any
	if ($result.Name.EndsWith("+")) {
		$result.Name = $result.Name.Substring(0, $result.Name.Length - 1)
		$result.Reference = "!";
		Write-Verbose "Found reference switch for $name"
	}
	
	# parse nullable if any
	if ($result.Name.EndsWith("?"))	{
		$result.Name = $result.Name.Substring(0, $result.Name.Length - 1)
		$result.Required = $false;
		Write-Verbose "Found nullable switch for $name"
	}
	
	[int]$start = 0
	# parse length if any
	if ($result.Name.EndsWith("]")) {
		$start = $result.Name.IndexOf("[")
		if ($start -gt 0) {
			$lengthPart = $result.Name.Substring($start + 1, $result.Name.Length - $start - 2)
			$result.MaxLength = [System.Convert]::ToInt32($lengthPart)
			$result.Name = $result.Name.Substring(0, $start)
			Write-Verbose "Found max length for $name"
		}
	}
	
	# parse type if any
	$start = $result.Name.IndexOf(":")
	if ($start -gt 0) {
		$result.Type = $result.Name.Substring($start + 1, $result.Name.Length - $start - 1)
		$result.Name = $result.Name.Substring(0, $start)
	}
	
	if ($result.Reference) {
		if ($result.Name -imatch '^.*id$') {
			$result.Reference = $result.Name.Substring(0, $result.Name.Length-2)
			if ($result.Reference.EndsWith("_")) {
				$result.Reference = $result.Name.Substring(0, $result.Name.Length-1)
			}
		}
		else {
			$result.Reference = ""
			Write-Warning "Cannot extract reference property for $name"
		}	
	}
	
	($result)
}

if (!$Folder) {
	$modelsFolder = Get-ProjectFolder "Models" -Create
	if ($modelsFolder) {
		$Folder = "Models"
		Write-Verbose "Models folder used by default"
	}
}

$patterns = @()
$defaultProperties = @()
$defaultProjectLanguage = Get-ProjectLanguage

# TODO: in future try to cache and not use arrays but something else, because we can have many patterns (check real performance)
try { 
	$patternsFile = "TypePatterns." + $defaultProjectLanguage + ".t4"
	$patternsPath = Join-Path $TemplateFolders[0] $patternsFile
	Write-Verbose "Trying to process $patternsFile ..."
	
	Get-Content $patternsPath | Foreach-Object { 
		$items = $_.Split(' ')
		$type = $items[0]
		
		if ($type -eq "default") {
			Write-Verbose "Processing default properties: $_"
			if ($items.Length -gt 1) {
				for ($i = 1; $i -lt $items.Length; $i++) {
					$defaultProperties += $items[$i]
				}
			}	
		}
		else {
			Write-Verbose "Processing pattern type: $type"

			$typeInfo = ParseName($type)

			if ($items.Length -gt 1) {
				for ($i = 1; $i -lt $items.Length; $i++) {
					$patterns += @{ Type = $typeInfo.Name; Pattern = '^' + $items[$i] + '$'; MaxLength = $typeInfo.MaxLength; Reference = $typeInfo.Reference }
					# Write-Verbose "	Processed pattern: $($items[$i])"
				}
			}
		}
	}
	
	Write-Verbose "$patternsFile processed"
}
catch { Write-Warning "Type patterns was not loaded: $($_.Exception.Message)" }

if ($defaultProperties.Length -eq 0) {
	$defaultProperties = @("Id", "Name")
}

$defaultSpace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value

if ($Properties -eq $null) {
		$Properties = $defaultProperties
	}

if (!$Folder) {
	$outputPath = $Model
	$space = $defaultSpace
}
else {
	$outputPath = Join-Path $Folder $Model
	$space = $defaultSpace + "." + $Folder.Replace("\", ".")
}

$props = @()
[int]$typedCount = 0

foreach ($property in $Properties) {
	$nameInfo = ParseName($property)
	$type = $nameInfo.Type
	
	# try to find some attributes from TypePatterns
	if ($type.Length -eq 0) {
		for ($i = 0; $i -lt $patterns.Length; $i++) {
			$p = $patterns[$i]
			if ($nameInfo.Name -cmatch $p.Pattern) {
				$type = $p.Type
				if ($nameInfo.MaxLength -eq 0 ) { $nameInfo.MaxLength = $p.MaxLength }
				if (!$nameInfo.Reference) { $nameInfo.Reference = $p.Reference }
				break
			}
		}
	}
	else {
		$typedCount++
	}

	if (!$type) { $type = "string" }
	
	# create reference class if not any
	$referenceType = ""
	if ($nameInfo.Reference) {
		$reference = Get-ProjectType $nameInfo.Reference 2>null
		
		if (!$reference) {
			$idType = $nameInfo.Type.ToLower()
			$newModel = $nameInfo.Reference
			Write-Host "Scaffolding new model $newModel"
			Scaffold ModelScaffolding.Model -Model $newModel Id:$idType,Name -Folder $Folder -Project $Project -CodeLanguage $CodeLanguage `
				-Controller:$Controller -Force:$Force -NoAnnotations:$NoAnnotations -NoTypeWarning `
				-DbContextType $DbContextType -Repository:$Repository -Area $Area -Layout $Layout -NoChildItems:$NoChildItems -ReferenceScriptLibraries:$ReferenceScriptLibraries
			$referenceType = $space + "." + $nameInfo.Reference
		}
		else {
			$refNamespace = $reference.Namespace.Name
			if ($space -ne $refNamespace -and !$space.StartsWith($refNamespace + ".")) {
				if ($refNamespace.StartsWith($space + ".")) {
					$refNamespace = $refNamespace.Substring($space.Length + 1)
				}
				$referenceType = $refNamespace + "." + $reference.Name
			}
		}
	}
	
	# add processed property
	$props += @{Name = $nameInfo.Name; Type = $type; MaxLength = $nameInfo.MaxLength; Required = $nameInfo.Required; Reference = $nameInfo.Reference; ReferenceType = $referenceType}
}

if ($typedCount -gt 0 -and $typedCount -lt $Properties.Length -and !$NoTypeWarning) {
	Write-Warning "Types were not specified for all properties. Types for such properties were assigned automatically."
	}

Add-ProjectItemViaTemplate $outputPath -Template TypeTemplate `
	-Model @{ Namespace = $space; TypeName = $Model; Properties = $props; Annotations = !$NoAnnotations } `
	-SuccessMessage "Added $Model at {0}" `
	-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

if ($Controller) {
	$controllerName = Get-PluralizedWord $Model
	
	Scaffold Controller -ControllerName $controllerName -ModelType $Model -Project $Project -CodeLanguage $CodeLanguage `
		-Force:$Force -DbContextType $DbContextType -Repository:$Repository -Area $Area -Layout $Layout -NoChildItems:$NoChildItems -ReferenceScriptLibraries:$ReferenceScriptLibraries
}