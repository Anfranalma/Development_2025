
<#
.Synopsis
   Backup and restore database from production to the new SQL Version. 
.DESCRIPTION
    Phase - Migration 
    This Module will be call from workflow Module and it will return an object with 1 or 0 and the log of the result   

    Parent : Migration Workflow module \\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\WFPS\WFPS.psm1
    Child: Result is saved into Apex

    This module need also \\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\MIGUsersDatabase\MIGUsersDatabase.sql file. 

.EXAMPLE
    From Module (file.psm1)
    Import-Module ...YOUR PATH...\\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\MIGUsersDatabase\MIGUsersDatabase.psm1
    Step-MIGUsersDatabase -source_instance sqldev073 -Target_instance mtl-hq-s522 -source_database mig_test1 -Target_database mig_test1

.EXAMPLE
    Call this Module and see the output
    $a=Step-MIGUsersDatabase -source_instance sqldev073 -Target_instance mtl-hq-s522 -source_database mig_test1 -Target_database mig_test1
    $a.log
    $a.code

.INPUTS
    Source: Call from  WFPS 

.OUTPUTS
    Object with 2 Param Code and Log

.NOTES
    Author: Manuel E. Pineda
    Date:   2015-12-02
	
	Date:   2017-03-13
	Carlos Perez: Saves the user migration script to a file.

#>

Function Step-MIGUsersDatabase()
{


    Param
    (
        [CmdletBinding()]
        [Parameter(Mandatory=$True,Position=1)]
        [string]$source_instance,

        [Parameter(Mandatory=$True,Position=2)]
        [string]$Target_instance,       

        [Parameter(Mandatory=$True,Position=3)] 
        [string]$source_database,

        [Parameter(Mandatory=$True,Position=4)] 
        [string]$Target_database
                    
     )
      
     try
     { 
		set-Location C:
        $object = New-Object –TypeName PSObject
		# SET $backup_time for a specific format for naming of the backup
        $backup_time = get-date -Format "yyyyMMdd-hhmm"
        
		#Note: The original version of the script is: 
		#$inputfile = "\\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\MIGUsersDatabase\MIGUsersDatabase.sql"
		#Below is the version modified by Carlos Perez 
		[string]$query = ""
		[string]$cmd = ""
        $inputfile = "\\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\MIGUsersDatabase\MIGUsersDatabaseV2.sql"		
           $filelog = "\\mtlhqnasb\sqlappdevfiles\MIGSQL\Log\Log" + $backup_time  + ".txt"
		$filescript = "\\mtlhqnasb\sqlappdevfiles\MIGSQL\Log\Script_MigMUsersDatabase_" + $Source_instance + "_" + $Source_database + "_" + $backup_time  + ".sql"
        Write-Host "Executing MIGUsersDatabasev2.sql ......."
        
        $Result=invoke-sqlcmd -Inputfile $inputfile -Variable DatabaseName=$Source_database -ServerInstance $Source_instance -Database master
        Write-Host "Script to execute:"
		
		#"/* Script to generate Logins, Users and permissions as defined in database  " + $Source_database + " in instance [" + $Source_instance + "]*/" > $filelog
        foreach($item in $Result){
            $CMD = [string]$item.cmd
			Write-Host $CMD 
			$CMD -replace "PASSWORD \= .+ HASHED","PASSWORD = 'see oubliette'"  >>$filescript
			$query = $query + ' ' + $CMD            
						
			
            }
		$b = Invoke-sqlcmd -query $query -Verbose -ServerInstance $Target_instance -Database master >>$filelog
		#check for errors
		foreach($item in $b){
        $CMD = $item.cmd
		Write-Host $CMD			           
            }
		
        if ($b -notmatch "already" -And $b -notmatch "context")         
        {
            $object | Add-Member –MemberType NoteProperty –Name Code -Value 4475
            $object | Add-Member –MemberType NoteProperty –Name Log -Value 'Database User process in error...' 
            Write-Host "Database User process in error..." 
		
        }
        else
        {
            $object | Add-Member –MemberType NoteProperty –Name Code -Value 1
            $object | Add-Member –MemberType NoteProperty –Name Log -Value 'Database User transfered successfully...'      
            Write-Host "Database User transfered successfully...."               
        }
        
        return $object

    }
    Catch
    {
		if ($_ -match "Cannot open file because ")
		{
		Write-Host "Cannot write to file. Please run 'Set-Location c:' and execute the script again."
		}
		else		
		{
		Write-Host($_)
        Write-Host "++Database User process in error........"
		}
        $object | Add-Member –MemberType NoteProperty –Name Code -Value 4475 
        $object | Add-Member –MemberType NoteProperty –Name Log -Value 'Database User process in error...'   
        return $object
		
        
    }
	
}


