#createion des fonctions dans powershell
# new-item est utilise, 

#Clear-Host
#
#New-Item function:Multiplication -value `
#{
#    $args[0] * $args[1]
#}
#
#Clear-Host

# un autre facon de declarer la fonction
clear-host

function Multiplication
{
    $args[0] * $args[1]
}

function Soustraction {
    Param([int]$operante1=0, [int]$operante2 =0)
    $operante1 - $operante2
}

Clear-Host


function Nouveau-group {
    Param([string]$nombre='')
    New-LocalGroup $nombre
}

$f=Get-Item function:Nouveau-group

$f.Source

#pur changer la defnition de un futnciotn

set-item Function:\Nouveau-group{

.....

}

#voile,c'est comment ca

function get-length{
    Param([Parameter(ValueFromPipeline)][string]$string)
    $string.Length
    
}

get-length -string "Hola Majes"

$eso="Quijuepputa" 
$eso | get-length


#Paramter(ValueFromPipeline) permettra de passer des valuers dans le pipeline


"notepad" | Stop-Process -Confirm $true

#pour verifier que le paramet accept le pipeline

