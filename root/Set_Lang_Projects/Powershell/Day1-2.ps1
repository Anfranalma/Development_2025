## get-member nous donne les propiete de qulqeu chose

for($i=1; $i -le 100; $i++)
{
    "$i Bonjour, ceci est un fichier de test." | Add-Content -Path C:\Users\User\Documents\ProjectsNDevelopment\Powershell\fichier1.txt
    }


foreach($e in $list2){
    Write-Host $e
    }

[int] $var=read-host "donne un valeur inferieur ou egal a 100"
if ($var -eq 100){
write-host "Effectivement, le valuer est inferiour"}
else{
write-host "le valeur est plus grande"}

$list3 = "rouge","bleu","vert"

$couleur = read-host "donner un couleur"
if($list3 -contains $couleur){
Write-Host "cetter couleur exite dans la liste"}
else{
write-host "cette couleur n'existe pas dans la liste"
}


$liste =Get-LocalUser | select -ExcludeProperty name
$user = Read-Host "donne un nom d'utilisateur"
if($liste -contains $user){
write-host "il existe"}
else{
write-host "il n'existe pas"}



$svc = read-host "donner le nos d'un service"

if ((Get-Service $svc | Measure-Object).Count -gt 0){
write-host "ce service existe"}
else
{write-host "ce service n'existe pas"}


$reponse = read-host "voleovous cintinuer (o/n)?"

switch -Wildcard($reponse){
"o*" {
    Write-Host "on continue"
    }
"n*" {
    write-host "on arrete"
    }
default{
    echo "mauvaise reponse"
    }
}


$list4 = (Get-ChildItem -Path C:\Windows)
foreach ($fichier in $list4){
Write-Host $fichier.Name
}

Get-ChildItem -path C:\Windows | ForEach-Object {$_.name}

$list_gr = Get-LocalGroup

foreach($group in $list_gr){
    if($group.name -like "Performan*")
    { Write-Host $group.name $group.sid}}

Get-LocalGroup | ForEach-Object {
    if($_.name -like "Admin*"){
        Write-Host $_.name $_.Sid
        }
    }

for ($i=1; $i -lt 6; $i=$i+1){
    $nom-"f"+$i+


$choix = "o"
$i=0
while ($choix -eq "o"){
$i++
Write-Host $i
$choix = Read-Host "voulez vous continuer(o/n)"
}


