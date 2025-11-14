
<#
.Synopsis
   Backup and restore database from production to the new SQL Version. 
.DESCRIPTION
    Phase - Migration 
    This Module will be call from workflow Module and it will return an object with 1 or 0 and the log of the result   
    
    Module : MIGBackupDatabase.psm1 
    Parent : Migration Workflow module \\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\WFPS\WFPS.psm1
    Child: Result is saved into Apex

.EXAMPLE
    From Module (file.psm1)
    Import-Module ...YOUR PATH...\\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\MIGBackupDatabase\MIGBackupDatabase.psm1
    Step-MIGBackupDatabase -source_instance mtl-hq-s58 -source_database PPS -target_EnvType "DEV"

.EXAMPLE
    Call this Module and see the output
    $a=Step-MIGBackupDatabase -source_instance mtl-hq-s58 -source_database PPS -target_EnvType "DEV"
    $a.log
    $a.code

.INPUTS
    Source: Call from  WFPS 

.OUTPUTS
    Object with 2 Param Code and Log

.NOTES
    Author: Manuel E. Pineda
    Date:   2015-12-02

#>

Function Step-MIGBackupDatabase()
{


    Param
    (
        [CmdletBinding()]
        [Parameter(Mandatory=$True,Position=1)]
        [string]$source_instance,

        [Parameter(Mandatory=$True,Position=2)]
        [string]$source_database,       

        [Parameter(Mandatory=$True,Position=3)] 
        [string]$target_EnvType

                    
     )
          
     try
     {
                   
        $object = New-Object –TypeName PSObject
        

       if($target_EnvType -eq "PROD")
        {
            $target_EnvType = "\\mtlsql-08\sql-replica"                 
        }
        else
        {
            $target_EnvType = "\\mtlsql-07\sql-non-replica"            
        }


      
        $query = "exec master.dbo.xp_create_subdir '$target_EnvType\$source_instance\sql_db_backup\$source_database'"
        $query = $query + " exec master.dbo.xp_create_subdir '$target_EnvType\$source_instance\sql_diff_backup\$source_database'"
        $query = $query + " exec master.dbo.xp_create_subdir '$target_EnvType\$source_instance\sql_log_backup\$source_database'"
     
                                
        Invoke-Sqlcmd -Query $query -ServerInstance $source_instance -Database $source_database -ErrorAction Stop


        # SET $backup_time for a specific format for naming of the backup
        $backup_time = get-date -Format "yyyyMMddhhmm"

        
        $query = 'Backup database '+ $source_database
        $query = $query + ' to Disk =  ''' + $target_EnvType + '\' + $source_instance + '\sql_db_backup\' + $source_database + '\' + $source_database + '_db_' + $backup_time + '_S1.bak'',' 
        $query = $query + ' Disk =  ''' + $target_EnvType + '\' + $source_instance + '\sql_db_backup\' + $source_database + '\' + $source_database + '_db_' + $backup_time + '_S2.bak'',' 
        $query = $query + ' Disk =  ''' + $target_EnvType + '\' + $source_instance + '\sql_db_backup\' + $source_database + '\' + $source_database + '_db_' + $backup_time + '_S3.bak''' 
        $query = $query + ' WITH NOFORMAT, NOINIT, NAME = N''' + $source_database + '-Full Database Backup'', SKIP, NOREWIND, NOUNLOAD , Buffercount = 30, MAXTRANSFERSIZE = 524288, STATS = 5'
               

        $b = Invoke-Sqlcmd -Query $query -ServerInstance $source_instance -Database 'master' -QueryTimeout 3600 -ErrorAction Stop

        Write-Host 'Backup database done for ' $source_database 
                   
        if ($b -match "rc: 12")         
        {
            $object | Add-Member –MemberType NoteProperty –Name Code -Value 4475
        }
        else
        {
                  
         $object | Add-Member –MemberType NoteProperty –Name Code -Value 1
        }
     
        $object | Add-Member –MemberType NoteProperty –Name Log -Value "Backup completed successfully..."                           

        return $object

    }
    Catch
    {
    
        write-Host "Restore failed..... $_.Exception.Message "

        $object | Add-Member –MemberType NoteProperty –Name Code -Value 4475 
        $object | Add-Member –MemberType NoteProperty –Name Log -Value $_.Exception.Message       
        return $object
        
    }
}