$nugetVersions = @{}
$nuspecPath = @{}

Write-Output $path
Get-ChildItem -Path $path -Filter *.csproj -Recurse | ForEach-Object {
    Write-Output $_.FullName

    try {
        $match = Select-String -Pattern '\<LibraryProjectZip Include="Jars\\\D+-((\d+\.*)+).(jar|aar)\" \/\>' -Path $_.FullName
        $versionNumber = $match.Matches[0].Groups[1].Value

        // Huawei always sets version number to 300 something
        // I will use 400 something to give me a chance to fix the bindings
        // Ex. .301 can give => 401 or 411 or 421 depending on the number of times I fix the problems.
        $versionNumber = $versionNumber.Replace(".30", ".40")

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