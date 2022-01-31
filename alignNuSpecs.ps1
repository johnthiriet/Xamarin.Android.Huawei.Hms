$nugetVersions = @{}
$nuspecPath = @{}

Write-Output $path
Get-ChildItem -Path $path -Filter *.csproj -Recurse | ForEach-Object {
    Write-Output $_.FullName

    try {
        $match = Select-String -Pattern '\<LibraryProjectZip Include="Jars\\\D+-((\d+\.*)+).(jar|aar)\" \/\>' -Path $_.FullName
        $versionNumber = $match.Matches[0].Groups[1].Value

        Get-ChildItem -Path $_.Directory.FullName -Filter *.nuspec | ForEach-Object {
            $nuspecFullName = $_.FullName
            $idMatches = Select-String -Pattern '\<id\>(.+)\<\/id\>' -Path $nuspecFullName

            if ($idMatches) {    
                $nugetId = $idMatches.Matches[0].Groups[1].Value

                $nugetVersions[$nugetId] = $versionNumber
                $nuspecPath[$nugetId] = $nuspecFullName

            (Get-Content $nuspecFullName) -Replace '<version>.*</version>$', "<version>$versionNumber</version>" | Out-File $nuspecFullName
            }
        }
    }
    catch {

    }
}


$nugetVersions.Keys | ForEach-Object {
    $id = $_
    $nuspecFullName = $nuspecPath[$id]

    $regexMatches = Select-String -Pattern 'dependency id=\"(.*)\" version=\"((\d+\.*)+)\"' -Path $nuspecFullName

    if ($regexMatches) {
        $regexMatches | ForEach-Object {
            $groups = $_.Matches[0].Groups
            $key = $groups[1].Value
            $actualVersion = $nugetVersions[$key]

            if (-not ([string]::IsNullOrEmpty($actualVersion))) {
                $content = Get-Content $nuspecFullName
                $pattern = "dependency id=`"$($key)`" version=`"((\d+\.*)+)`""
                $replaceWith = "dependency id=`"$($key)`" version=`"$($actualVersion)`""
                $content -Replace $pattern, $replaceWith | Out-File -FilePath $nuspecFullName
            }
        }
    }
}