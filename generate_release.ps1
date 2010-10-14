New-Item Release -type directory -force
$EFfile = resolve-path "EntityFrameworkFieldsWrapper.EF1\bin\Release\EFExtensions.EFWRappableFields.EF1.dll"
$asm = [System.Reflection.Assembly]::Loadfile($EFfile)
$version = $asm.GetName().version.ToString()
$newfilename = (resolve-path "Release\").ToString() + [System.IO.Path]::GetFileNameWithoutExtension($EFfile) + "-" + $version + ".dll"
[System.IO.File]::Delete($newfilename)
[System.IO.File]::Copy($EFfile, $newfilename)

$EFfile = resolve-path "EntityFrameworkFieldsWrapper.EF4\bin\Release\EFExtensions.EFWRappableFields.EF4.dll"
$newfilename = (resolve-path "Release\").ToString() + [System.IO.Path]::GetFileNameWithoutExtension($EFfile) + "-" + $version + ".dll"
[System.IO.File]::Delete($newfilename)
[System.IO.File]::Copy($EFfile, $newfilename)

