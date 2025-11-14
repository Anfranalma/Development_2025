## $list5 = get-childitem C:\Windows\System32 -File | Select-Object -First 5

## while
$list5 = Get-ChildItem C:\Windows\System32 -File
for($i=0; $i -lt 5; $i=$i+1){
    $list5[$i]
}


$liste_fichiers = Get-ChildItem C:\Windows\System32 -file

foreach($fichier in $liste_fichiers){
    if($fichier.Name -like "*.??"){
        Write-Host $fichier
        }
    }


do {
$ip = Read-Host "donner l'address IP:"
$hote = Read-Host "donner le nom d'hote"

$ligne = $ip + " " + $hote
Add-Content -Path C:\Windows\System32\drivers\etc\hosts -Value $ligne
$reponse = Read-Host "voulez vous inserer un autre ligne dans le fichier (O/N)"
} while ($reponse -notlike "o*")