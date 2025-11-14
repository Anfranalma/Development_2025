import os
from charset_normalizer import detect

template_job = """
USE [msdb]
GO

/****** Object:  Job [DBA_RAP_DpaCreationDpaParPeriode]    Script Date: 11/26/2024 3:31:04 PM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [[Uncategorized (Local)]]    Script Date: 11/26/2024 3:31:04 PM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'{}', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'No description available.', 
		@category_name=N'[Uncategorized (Local)]', 
		@owner_login_name=N'sa', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Grab_Data]    Script Date: 11/26/2024 3:31:04 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Grab_Data', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'use bof;

exec {};', 
		@database_name=N'master', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'job_test', 
		@enabled=1, 
		@freq_type=4, 
		@freq_interval=1, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20241119, 
		@active_end_date=99991231, 
		@active_start_time=90000, 
		@active_end_time=235959, 
		@schedule_uid=N'e13f7b84-a441-4d92-a45d-d2b4f8ba4bb6'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:
GO



""".format("angel","albanez")

template_powershell = """
    # Parameters
$serverName = "FADEVSQLBOF01"
$databaseName = "bof"
$sqlFilePath = "\\fondaction.local\Prod\SQLDumpP\Rapports\Hebdomadaire\ActionnaireCompteEnLigne.sql"
$timestamp = Get-Date -Format "yyyy-MM-dd_HHmm"  # Formats as YYYY-MM-DD_HHMM
# Load the SQL query from the file
if (Test-Path -Path $sqlFilePath) {
    $query = Get-Content -Path $sqlFilePath -Raw
    $command.CommandText = $query
} else {
    Write-Host "The file path $sqlFilePath does not exist."
    exit
}


# Excel output file path
$excelFilePath = "\\fondaction\partages\Fondaction\Rapports Octopus\Test_dev_preprod\rapport_ActionnaireCompteEnLigne_$timestamp.xlsx"

# Create the SQL connection and command
$connectionString = "Server=$serverName;Database=$databaseName;Integrated Security=True;"
$connection = New-Object System.Data.SqlClient.SqlConnection
$connection.ConnectionString = $connectionString
$command = $connection.CreateCommand()
$command.CommandText = $query

# Create a DataTable to hold the data
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter $command
$dataTable = New-Object System.Data.DataTable

# Fill the DataTable with data from the query
$adapter.Fill($dataTable) | Out-Null

# Close the connection
$connection.Close()

# Export data to Excel with custom table style and basic formatting
$filteredDataTable = $dataTable | Select-Object -Property * -ExcludeProperty RowError, RowState, Table, ItemArray, HasErrors
$filteredDataTable | Export-Excel -Path $excelFilePath -WorksheetName "DatabaseData" -AutoSize -BoldTopRow -Title "Database Query Results" -TableStyle Medium2 -FreezeTopRow -Show

Write-Host "Data exported to Excel successfully at $excelFilePath"


"""

base_target="\\fondaction\\partages\\Fondaction\\Rapports Octopus\\Test_dev_preprod\\"
source_target = "C:\\Users\\Albaneza\\OneDrive - FONDACTION (CSN)\\Bureau\\Rapports\\"
source_sql=["Hebdomadaire","Mensuelles"]
source_ps = ""

for i in template_job:
    print(template_job.format(i,'angel'))


target_script_location = "C:\\Users\\Albaneza\\OneDrive - FONDACTION (CSN)\\Bureau\\Rapports\\script.txt"
target_script_powershell = "C:\\Users\\Albaneza\\OneDrive - FONDACTION (CSN)\\Bureau\\Rapports\\files.txt"

# Open the file and process it
with open(target_script_location, "r", encoding='utf-16') as data:
    # Read all lines and split each line by commas
    content = [line.strip().split(",") for line in data]

# Print the resulting 2D array
for row in content:
    print(row)

with open(target_script_powershell, "r", encoding='utf-16') as data:
    # Read all lines and split each line by commas
   files = [line.strip() for line in data]

# Print the resulting 2D array
for row in range(len(files)):
    print(files[row])




