#Donnez un script PowerShell  qui affiche un menu contenant les options suivante:
#1) Afficher les noms des utilisateurs 
#2) Créer un nouvel utilisateur
#3) Ajouter un utilisateur au groupe Administrateurs
#4) Quitter
#•	L'utilisateur choisit ensuite un de ces options en insérant le numéro correspondant. 
#•	Le script assiste l'utilisateur pour terminer la tâche choisie puis réaffiche le menu. 
#•	Le script quitte seulement quand l'utilisateur choisit 4

$menu = @"
#####
Menu
#####

1) Afficher les noms des utilisateurs 
2) Creer un nouvel utilisateur
3) Ajouter un utilisateur au groupe Administrateurs
4) Quitter"
"@
clear-host
do { 
    write-host $menu
    $choix = Read-Host "`nquel sera votre choix (1-4)?"
    
    switch ($choix) {
        1 {
            #Afficher les noms des utilisateurs 
            write-host "utilisateurs: `n "
            Get-LocalUser | Format-Wide


            read-host "Tapez Entrer pour continuer..."
            clear-host
        }
        2 {
            #Creer un nouvel utilisateur
            $nomUtil = Read-Host "Quel est le nom de l'utilisateur à créer?"
            $nb = (Get-LocalUser $nomUtil -ErrorAction SilentlyContinue | measure-object).Count

            if ($nb -eq 1) {
                #utilisateur existe déjà
                Write-Host "utilisateur existe deja" -ForegroundColor Red
            }
            else {
                $utilisermdp = Read-Host "voulez-vous définir un mot de passe (O/N)?"
            
                if ($utilisermdp -eq "O") {
                    # avec mdp
                    $mdp = Read-Host "donner le nouveau mdp ?" -AsSecureString
                    New-localUser -Name $nomUtil -Password $mdp
                }
                else {
                    #sans password
                    New-LocalUser $nomUtil -NoPassword
                }
                write-host "utilisateur cree" -ForegroundColor Green
            }
            
    
            read-host "Tapez Entrer pour continuer..." 
            clear-host
        }
        3 {
            #Ajouter un utilisateur au groupe Administrateurs
            $nom = Read-host "Quel sera le nom de l'utilisateur à ajouter au groupe Administrateurs?"
            $nb1 = (Get-LocalUser $nom -ErrorAction SilentlyContinue | measure-object).Count

            if ($nb1 -eq 1) {
                Add-LocalGroupMember -Group "Administrateurs" -Member $nom
                write-host "utilisateur ajouté au groupe Administrateurs" -ForegroundColor Green
            }
            else {
                write-host "l'utilisteur n'existe pas!!" -ForegroundColor red
            }

            read-host "Tapez Entrer pour continuer..."
            clear-host
        }
        4 {
            #quitter
        }
        default {
            write-host "mauvais choix!!"

            read-host "Tapez Entrer pour continuer..."
            clear-host
        }
    
    }
} while ($choix -ne 4)