
/*-------------------------------------------------------------------------------------

Script Name 	: 	RestoreFromBackupFile.sql

Author Name	:	Victoria Leon


Description 	:	build the script to restore from backup files.

Version	:	1.0 Initial VL

--------------------------------------------------------------------------------------*/

SET NOCOUNT ON

DECLARE @PathLog VARCHAR(255)
DECLARE @PathData VARCHAR(255)
DECLARE @TempPath VARCHAR(255) 

DECLARE @new_db_name Varchar(100), 

	@BackupPath1 Varchar(500),
	@BackupPath2 Varchar(500),
	@BackupPath3 Varchar(500),		
        @cmd nvarchar(max) ,
        @logicalname Varchar(255) ,
        @PhysicalFileName Varchar(max) ,
        @type Varchar(5)


SET @new_db_name = '$(Newdbname)' 
SET @BackupPath1 = '$(backupPath1)'
SET 	@BackupPath2 = NULL
SET	@BackupPath3 = NULL

IF '$(backupPath2)' != 'empty' 
	SET @BackupPath2 = '$(backupPath2)'
IF '$(backupPath3)' != 'empty'
	SET @BackupPath3 = '$(backupPath3)'


/***********************************************************/
/*** Get the logical names from the backup file          ***/
/***********************************************************/

CREATE TABLE  #filelist (

   LogicalName VARCHAR(255),

   PhysicalName VARCHAR(500),

   [Type] VARCHAR(1),

   FileGroupName VARCHAR(64),

   Size DECIMAL(20, 0),

   MaxSize DECIMAL(25,0),

   FileID bigint,

   CreateLSN DECIMAL(25,0),

   DropLSN DECIMAL(25,0),

   UniqueID UNIQUEIDENTIFIER,

   ReadOnlyLSN DECIMAL(25,0),

   ReadWriteLSN DECIMAL(25,0),

   BackupSizeInBytes DECIMAL(25,0),

   SourceBlockSize INT,

   filegroupid INT,

   loggroupguid UNIQUEIDENTIFIER,

   differentialbaseLSN DECIMAL(25,0),

   differentialbaseGUID UNIQUEIDENTIFIER,

   isreadonly BIT,

   ispresent BIT  ,

   TDEThumbprint Varchar(255))


SET @cmd = 'RESTORE FILELISTONLY FROM  DISK= N'''+ @BackupPath1 +''''
IF @BackupPath2 IS NOT NULL 
	set @cmd = @cmd + ',DISK= N'''+ @BackupPath2 +''''
IF @BackupPath3 IS NOT NULL 
set @cmd = @cmd + ' ,DISK= N'''+ @BackupPath3 +''''

INSERT INTO  #filelist
EXEC (@cmd)		
            

/***********************************************************/
/*** Script to create directories                        ***/
/***********************************************************/

-- Locate Data path

SELECT TOP 1 @TempPath = LEFT(physical_name, LEN(physical_name) - CHARINDEX( '\', REVERSE(physical_name)))
FROM sys.master_files 
WHERE db_name(database_id) = 'DBA_STATS'
AND type_desc = 'ROWS'

SELECT @PathData = SUBSTRING(@TempPath, 1, LEN(@TempPath) - CHARINDEX('DBA_Stats', @TempPath) + 2) + '\' + @new_db_name

-- Locate log path

SELECT @TempPath = LEFT(physical_name, LEN(physical_name) - CHARINDEX( '\', REVERSE(physical_name)))
FROM sys.master_files 
where db_name(database_id) = 'DBA_STATS'
AND type_desc = 'LOG'

SELECT @PathLog = SUBSTRING(@TempPath, 1, LEN(@TempPath) - CHARINDEX('DBA_Stats', @TempPath) + 2) + '\' + @new_db_name


PRINT 'use [master] '
PRINT 'GO'
PRINT 'exec master.dbo.xp_create_subdir ''' + @PathData + ''''
PRINT 'exec master.dbo.xp_create_subdir ''' + @PathLog + ''''
PRINT ' '              


/***********************************************************/
/*** Script to restore database                          ***/
/***********************************************************/


PRINT 'RESTORE DATABASE ['+ @new_db_name +']  FROM '
PRINT 'DISK = '''+ @BackupPath1 +'''' 
IF @BackupPath2 IS NOT NULL 
	PRINT ' ,DISK = N'''+ @BackupPath2 +'''' 
IF @BackupPath2 IS NOT NULL 
	PRINT ',DISK = N'''+ @BackupPath3 +''' ' 
PRINT ' WITH  FILE = 1 , '						

DECLARE file_list cursor for

SELECT LogicalName, PhysicalName, Type FROM #filelist ORDER BY  type

OPEN file_list

FETCH NEXT  FROM  file_list into @LogicalName, @PhysicalFileName, @type

WHILE @@fetch_status = 0

    BEGIN

        -- If it is data file move to data file location.

        IF @type = 'D'
	   PRINT 'MOVE ''' + @LogicalName + '''' + ' TO ''' + @PathData +'\'+   Substring(@PhysicalFileName , LEN(@PhysicalFileName)-CHARINDEX('\' , REVERSE(@PhysicalFileName))+2 , CHARINDEX('\' , REVERSE(@PhysicalFileName))) + ''','

        ELSE

        -- Log files move to log file location.
                        
	PRINT 'MOVE  ''' + @LogicalName + '''' + ' TO  ''' + @PathLOG  + '\'+  Substring(@PhysicalFileName , LEN(@PhysicalFileName)-CHARINDEX('\' , REVERSE(@PhysicalFileName))+2 , CHARINDEX('\' , REVERSE(@PhysicalFileName))) + ''''
              

FETCH NEXT  FROM  file_list into @LogicalName, @PhysicalFileName, @type     

END

CLOSE file_list  

DEALLOCATE file_list

truncate table  #filelist

PRINT ' ,NOUNLOAD,  REPLACE,  STATS = 10 '
PRINT 'GO '

/***********************************************************/
/*** Scripts to initialize database                      ***/
/***********************************************************/

PRINT ' '
PRINT 'ALTER DATABASE [' + @new_db_name + '] SET RECOVERY SIMPLE '
PRINT 'USE [' + @new_db_name + '] '
PRINT 'GO '

SELECT TOP 1 @LogicalName = LogicalName FROM #filelist WHERE [Type] = 'L'

PRINT 'DBCC SHRINKFILE (''' + @LogicalName + ''', 10) '
PRINT 'GO '
PRINT 'USE [' + @new_db_name + '] '
PRINT 'GO '
PRINT 'EXEC sp_changedbowner ''sa'' '
PRINT 'GO'
PRINT 'ALTER DATABASE ['+ @new_db_name +'] SET COMPATIBILITY_LEVEL = 120'
PRINT 'GO'
PRINT 'ALTER DATABASE '+ @new_db_name +' SET PAGE_VERIFY CHECKSUM  WITH NO_WAIT'
PRINT 'GO'



