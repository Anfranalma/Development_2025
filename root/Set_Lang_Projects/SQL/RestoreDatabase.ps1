
<#
.Synopsis
   Restore database from source SQL Server to the new SQL Version. 
.DESCRIPTION
    Phase - Migration 
    This Module will be call from workflow Module and it will return an object with 1 or 0 and the log of the result   

    Parent : Migration Workflow module \\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\WFPS\WFPS.psm1
    Child: Result is saved into Apex

.EXAMPLE
    From Module (file.psm1)
    Import-Module ...YOUR PATH...\\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\MIGDatabase\MIGDatabase.psm1
    WFStep-MIGRestoreDatabase -source_EnvType "UAT" -source_server "MTL-HQ-S310" -source_database CPL -backupFile1 "CPL_20170127_1.bak" -backupFile2 '' -backupFile3 '' -target_server "MTL-HQ-S522" -target_database "CPL_TEMP" -data_dir "F:\SQLDATA" -log_dir "F:\SQLLOGS" -EXECID 1232

.EXAMPLE
    Call this Module and see the output
    $a=Step-MIGRestoreDatabase -source_EnvType "UAT" -source_server "MTL-HQ-S310" -source_database CPL -backupFile1 "CPL_20170127_1.bak" -backupFile2 '' -backupFile3 '' -target_server "MTL-HQ-S522" -target_database "CPL_TEMP" -data_dir "F:\SQLDATA" -log_dir "F:\SQLLOGS"
    $a.log
    $a.code

.INPUTS
    Source: Call from  WFPS 

.OUTPUTS
    Object with 2 Param Code and Log

.NOTES
    Author: Victoria Leon
    Date:   2017-03-07

#>

Function Step-MIGRestoreDatabase()
{
    Param
    (
        [CmdletBinding()]

        [Parameter(Mandatory=$True,Position=1)]
        [string]$target_server,

        [Parameter(Mandatory=$True,Position=2)]
        [string]$target_database,

        [Parameter(Mandatory=$True,Position=3)] 
        [string]$backup_Folder,

        [Parameter(Mandatory=$True,Position=4)]
        [string]$backup_File1,

        [Parameter(Mandatory=$False,Position=5)]
        [string]$backup_File2,

        [Parameter(Mandatory=$False,Position=6)]
        [string]$backup_File3                
                    
     )
          
     try
     {

    ######################################################################################
    # Variables for return code and logging
    ######################################################################################
    $object = New-Object –TypeName PSObject   
    
    Write-Host "Restoring Database...."
    

    #### DEV
    #$directorypath = 'C:\DBA\PRJ-MigContinous\PowerShell'    
    #$inputfile = $directorypath+"\SQL_dir\RestoreFromBackupFile.sql" 
    #### 


    $directorypath = '\\mtlhqnasb\sqlappdevfiles\MIGSQL'
     $inputfile = "\\mtlhqnasb\sqlappdevfiles\MIGSQL\CMD\MIGRestoreDatabase\RestoreFromBackupFile.sql"

    $script:directorypath = $directorypath

    $CurrentProgram = "MIGRestoreDatabase"
    $RunVersion = Get-Date -format "yyyyMMddHHmmss"
    $script:max_rc = 0

    $script:OutputLog = $script:directorypath + "\Refresh_logs\" + $CurrentProgram + "_" + $RunVersion + ".log"
    # Empty log file
    echo "" > $script:OutputLog
    Clear-content $script:OutputLog       
     
    
     $Refresh_script = $directorypath+"\Work_dir\"+$target_server+"_"+$RunVersion+".sql"          
         
     echo "" > $Refresh_script
     Clear-content $Refresh_script   
         
    ################################################
    ## Generate Restore script
    ################################################
        

      $Host.UI.RawUI.BufferSize = New-Object Management.Automation.Host.Size (100, 25)
      

      $backupPath1 = $backup_Folder + '\' + $backup_File1

      if ($backup_File2)
      {        
        $backupPath2 = $backup_Folder + '\' + $backup_File2
      }
      else 
      {        
        $backupPath2 = 'empty'
      }

      if ($backup_File3)
      {
        $backupPath3 = $backup_Folder + '\' + $backup_File3
      }
      else 
      {      
        $backupPath3 = 'empty'
      }

        Write-Host "Generating script to restore database...."

          # save current path, reset after invoke-sqlcmd
          $script:currentlocation = Get-location              


          write-output "" | Tee-object -Append -file $script:OutputLog | Out-Host
          write-output "Calling SQLRestoreParam script to generate restore script..." | Tee-object -Append -file $script:OutputLog | Out-Host          

          $MyArray = "Newdbname=$target_database", "backupPath1=$backupPath1" , "backupPath2=$backupPath2", "backupPath3=$backupPath3"
          
          
          (invoke-sqlcmd -Inputfile $inputfile -Variable $MyArray -ServerInstance $target_server -Database master  -Verbose  -Querytimeout 65000) 4> $Refresh_script 2>>$script:OutputLog

          #put back our path
          Set-location $script:currentlocation               


        ################################################
        ## Run Restore script
        ################################################
     
          cat $Refresh_script > $script:Refresh_script

          Write-Host "Restoring Database...."                 
          
          (Invoke-SqlCmd -InputFile "$Refresh_script" -ServerInstance "$target_server"  -Database "master" -Verbose -ErrorAction Stop -OutputSqlErrors $True -QueryTimeout 65000) 4>&1  | Tee-object -Append -file $script:OutputLog | Out-Host
       
           Write-Host "Restore done...."                   
                          
         $object | Add-Member –MemberType NoteProperty –Name Code -Value 1
         Write-Host "Restore successfully... see more details in Refresh_logs directory..." 
        $object | Add-Member –MemberType NoteProperty –Name Log -Value "Restore successfully... see more details in Refresh_logs directory..."                           

        return $object

    }
    Catch
    { 

        write-output "Error restoring database." | Tee-object -Append -file $script:OutputLog | Out-Host
        write-output ($error[0]) | Tee-object -Append -file $script:OutputLog | Out-Host
        $script:max_rc = 12       


        write-Host "Restore failed..... $_.Exception.Message "

        $object | Add-Member –MemberType NoteProperty –Name Code -Value 4475 
        $object | Add-Member –MemberType NoteProperty –Name Log -Value $_.Exception.Message       

        return $object
        
    }
}