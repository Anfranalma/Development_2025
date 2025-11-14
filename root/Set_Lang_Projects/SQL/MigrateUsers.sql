/*
*************************************************************************************************************************************
Modified By Carlos Perez on Jan 05 2017
Changes:
               + Added a validation in output script to check if the login or user exists 
			     before creating it because sometimes the restore script is not able 
				 to remove all users/logins from the database.
		       + All scripts are now contained in one table #TMP_LOGIN_RIGHTS
			   + Added validations to skip the creation of orphan users (users without login).
               + All Permissions for skipped users will be commented in output script (to avoid errors).
			   + Old SQL users for SSRS in 2008 (CN\SVC-SQLPRDRS01-DSN, CN\SVC-SQLUATRS01-DSN, CN\SVC-SQLDEVRS01-DSN)
			     will be replaced for new SSRS users for 2014: cn\SVC-SSRSPRDG730-DSN, cn\svc-ssrsuatg730-DSN, cn\svc-ssrsdevg730-DSN
Modified By Carlos Perez on Mar 06 2017
			   + If any, the server level permissions are now scripted for users in the database using Victoria's script:
			\\mtl-hq-f07\hq5aw1\Databases\SQL Server\Projects\CB219045  - Windows and SQL EOL\_Documents & Templates\Scripts\ServerLevel_Permissions_Scripting.txt
			   + The script will warn if database already contains users that aren't on the list of logins to be created. i.e. the restore database script was unable delete the users from prod when restoring databases to different environments.
			
*************************************************************************************************************************************
*/
DECLARE @MANUAL_MODE INT = 0 --Change the value to 1 if you want to manually generate the script. The manual mode returns only one result set with all script statements instead multiple result sets as required by the powershell script.
DECLARE @DatabaseName NVARCHAR(255) = N'$(DatabaseName)'


SET NOCOUNT ON 
DECLARE @USERNAME VARCHAR(200) 
DECLARE @LOGINNAME VARCHAR(200)
DECLARE @SCHEMANAME VARCHAR(128)
DECLARE @CMD NVARCHAR(4000)
DECLARE @DB NVARCHAR(128) 


-- Temp Table to hold generated commands
CREATE TABLE #TMP_LOGIN_RIGHTS (RIGHTSID INT IDENTITY(1,1), RIGHTS_TEXT VARCHAR(MAX) )

----------------------------------------------------------------------------- 



SET NOCOUNT ON 

-- GET THE NAME OF ALL DATABASES
DECLARE ALLDATABASES CURSOR
FOR SELECT  NAME
FROM    [MASTER].[DBO].[SYSDATABASES] where name = @DatabaseName
OPEN ALLDATABASES
FETCH NEXT FROM ALLDATABASES INTO @DB

-- CREATE TABLE TO HOLD LIST OF USERS IN CURRENT DATABASE
CREATE TABLE #TMPUSERS
(
USERNAME VARCHAR(100),
GROUPNAME VARCHAR(100),
LOGINNAME VARCHAR(100),
DEFDBNAME VARCHAR(100),
USERID CHAR(10),
SCHEMANAME VARCHAR(100),
SUSERID SMALLINT,
ISINVALID BIT DEFAULT(0)
)
WHILE ( @@FETCH_STATUS = 0 )
BEGIN
	-- COMMAND TO RETURN ALL USERS IN DATABASE
	SET @CMD = '[' + @DB + ']' + '.[DBO].[SP_HELPUSER]'
	-- GET ALL USERS IN DATABASE INTO TEMPORARY TABLE
	INSERT  INTO #TMPUSERS (USERNAME,GROUPNAME,LOGINNAME,DEFDBNAME,
	USERID,SCHEMANAME,SUSERID)
	EXEC ( @CMD )	
	-- GET NEXT DATABASE
	FETCH NEXT FROM ALLDATABASES INTO @DB
END -- WHILE (@@FETCH_STATUS = 0)
-- CLOSE AND DEALLOCATE CURSOR OF DATABASES SO NEXT TIME AROUND NO ERROR OCCURS
CLOSE ALLDATABASES

--remove users not needed for migration
DELETE #TMPUSERS WHERE USERNAME IN ('dbo','guest','sys','INFORMATION_SCHEMA','sa')

INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*BEGIN OF SCRIPT*/'; 

--Verify if target database contain other users and warn user.
DECLARE @sqlstmt nvarchar(MAX) = ''
DECLARE @stmt nvarchar(MAX)
INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*DETECT OTHER USERS*/'; 

DECLARE ALLLOGINS CURSOR
FOR SELECT  distinct LOGINNAME
FROM    #TMPUSERS where LOGINNAME is not null  
OPEN ALLLOGINS
FETCH NEXT FROM ALLLOGINS INTO @LOGINNAME
WHILE ( @@FETCH_STATUS = 0 )
BEGIN
SET @sqlstmt = @sqlstmt + '''' +  @LOGINNAME + ''','
FETCH NEXT FROM ALLLOGINS INTO @LOGINNAME
END
CLOSE ALLLOGINS
DEALLOCATE ALLLOGINS
SET @stmt = 'USE ' + QUOTENAME(@DB) + '; /* Change context to the destination database */' +
 'SET NOCOUNT ON; DECLARE @usrname nvarchar(100);DECLARE @usrlist nvarchar(max)='''';SELECT name into #tmpusrs FROM sys.database_principals WHERE TYPE in (''U'',''G'',''S'') AND NAME NOT IN ' +
'(''dbo'',''sys'',''guest'',''INFORMATION_SCHEMA'',''CN\SVC-SSRSPRDG730-DSN'',''CN\SVC-SSRSUATG730-DSN'',''CN\SVC-SSRSDEVG730-DSN'',' + @sqlstmt + ''''');' +                      
'SELECT @usrname=MIN(name) from #tmpusrs;WHILE @usrname>'''' BEGIN; SET @usrlist = @usrlist + @usrname + '', ''; SELECT @usrname=MIN(name) from #tmpusrs where name>@usrname;END;' +
'IF LEN(@usrlist)>'''' PRINT ''****** WARNING *******: The destination database contain other users besides the users the script will create:'' +  LEFT(@usrlist,LEN(@usrlist)-1);' +
'DROP TABLE #tmpusrs;'

INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT @stmt
-----Create Login

INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*CREATE LOGINS*/'; 
INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) VALUES ('USE [MASTER]; /* Change context to master */')
DECLARE ALLLOGINS CURSOR
FOR SELECT  distinct LOGINNAME
FROM    #TMPUSERS where LOGINNAME is not null  
OPEN ALLLOGINS
FETCH NEXT FROM ALLLOGINS INTO @LOGINNAME


WHILE ( @@FETCH_STATUS = 0 )
BEGIN
	SELECT  @CMD = 
	  'IF NOT EXISTS(SELECT 1 FROM MASTER.SYS.SYSLOGINS WHERE NAME = ''' + P.NAME + ''')  CREATE LOGIN [' + P.NAME + '] ' + 
	  CASE WHEN P.TYPE IN('U','G') THEN 'FROM WINDOWS ' ELSE '' END +
	  'WITH ' +
	  CASE WHEN P.TYPE = 'S' THEN 'PASSWORD = ' + MASTER.SYS.FN_VARBINTOHEXSTR(L.PASSWORD_HASH) + ' HASHED, ' +
	  'SID = ' + MASTER.SYS.FN_VARBINTOHEXSTR(L.SID) + 
	  ', CHECK_EXPIRATION = ' + CASE WHEN L.IS_EXPIRATION_CHECKED > 0 THEN 'ON, ' ELSE 'OFF, ' END + 
	  'CHECK_POLICY = ' + CASE WHEN L.IS_POLICY_CHECKED > 0 THEN 'ON, ' ELSE 'OFF, ' END +
	  CASE WHEN L.CREDENTIAL_ID > 0 THEN 'CREDENTIAL = ' + C.NAME + ', ' ELSE '' END 
	  ELSE '' END +
	  'DEFAULT_DATABASE = [' + P.DEFAULT_DATABASE_NAME + '] ' +
	  CASE WHEN LEN(P.DEFAULT_LANGUAGE_NAME) > 0 THEN ', DEFAULT_LANGUAGE = ' + P.DEFAULT_LANGUAGE_NAME ELSE '' END + ' ELSE PRINT ''LOGIN [' +
      P.NAME +'] already exists.'''
	FROM SYS.SERVER_PRINCIPALS P 
	LEFT JOIN SYS.SQL_LOGINS L ON P.PRINCIPAL_ID = L.PRINCIPAL_ID 
	LEFT JOIN SYS.CREDENTIALS C ON  L.CREDENTIAL_ID = C.CREDENTIAL_ID	
	WHERE P.TYPE IN('S','U','G')
	AND P.NAME <> 'SA' and p.name = @LOGINNAME
	--SELECT @CMD as CMD
	INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) VALUES(@CMD)
	FETCH NEXT FROM ALLLOGINS INTO @LOGINNAME
END
CLOSE ALLLOGINS
DEALLOCATE ALLLOGINS

--- CREATE USER
INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*CREATE USERS*/'; 
INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT 'USE ' + QUOTENAME(@DB) + '; /* Change context again to destination db*/'
DECLARE @OLDUSERNAME NVARCHAR(100)
DECLARE ALLUSERS CURSOR
FOR SELECT distinct USERNAME,LOGINNAME,USERID
FROM #TMPUSERS


OPEN ALLUSERS
FETCH NEXT FROM ALLUSERS INTO @USERNAME,@LOGINNAME,@SCHEMANAME


WHILE ( @@FETCH_STATUS = 0 )
BEGIN	
	IF (@SCHEMANAME IS NULL and @LOGINNAME IS NOT NULL )
	BEGIN
		INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) 
		SELECT 'IF NOT EXISTS (SELECT 1 FROM sys.database_principals where name='''+ @USERNAME +''' AND type_desc IN (''SQL_USER'',''WINDOWS_GROUP'',''WINDOWS_USER'')) CREATE USER ['+ @USERNAME +'] FOR LOGIN ['+ @LOGINNAME + '] ELSE PRINT ''USER [' + @USERNAME + '] already exists.''' as CMD
	END
	ELSE IF (@LOGINNAME IS NULL)
	BEGIN
		INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) 
		SELECT '/* This user ['+@USERNAME+ '] is an orphan (the login doesn''t exist on the source). It won''t be created. */ ' as CMD 
		UPDATE #TMPUSERS SET IsInvalid = 1 WHERE USERNAME=@USERNAME
	END
	ELSE
	BEGIN
		INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) 
		SELECT 'IF NOT EXISTS (SELECT 1 FROM sys.database_principals where name='''+ @USERNAME +''' AND type_desc IN (''SQL_USER'',''WINDOWS_GROUP'',''WINDOWS_USER'')) CREATE USER ['+ @USERNAME +'] FOR LOGIN ['+ @LOGINNAME + '] WITH DEFAULT_SCHEMA=[' + RTRIM(@SCHEMANAME)+ '] ELSE PRINT ''USER [' + @USERNAME + '] already exists.''' as CMD		 
	END
	FETCH NEXT FROM ALLUSERS INTO @USERNAME,@LOGINNAME,@SCHEMANAME
END 
CLOSE ALLUSERS 
DEALLOCATE ALLUSERS

--------------------------------------------------------------------------------
INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*CREATE ROLES*/'; 

OPEN ALLDATABASES
FETCH NEXT FROM ALLDATABASES INTO @DB
WHILE ( @@FETCH_STATUS = 0 )
BEGIN	

	INSERT  INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT)
	SELECT DISTINCT CASE WHEN A.ISINVALID = 1 THEN ' /*' ELSE '' END +
	'IF IS_ROLEMEMBER(' + QUOTENAME(RTRIM(A.GROUPNAME),'''') + ',' + QUOTENAME(RTRIM(USERNAME),'''') + ') = 1 PRINT ''ROLE ' + RTRIM(A.GROUPNAME) + ' already exists for user ' + RTRIM(USERNAME) + '''' +  
	' EXECUTE [' + @DB + '].[DBO].[SP_ADDROLEMEMBER] ''' 
	+ RTRIM(A.GROUPNAME) + ''',''' + RTRIM(USERNAME) + '''' + CASE WHEN A.ISINVALID = 1 THEN '*/ ' ELSE '' END AS RIGHTS_TEXT 
	FROM    #TMPUSERS A
	WHERE   A.GROUPNAME <> 'PUBLIC'
	-- GET NEXT DATABASE
	FETCH NEXT FROM ALLDATABASES INTO @DB
END -- WHILE (@@FETCH_STATUS = 0)
CLOSE ALLDATABASES

-------------------------------------------------------------------------------
-- CREATE TEMPORARY TABLE TO HOLD INFORMATION ABOUT OBJECTS PERMISSIONS
CREATE TABLE #TMPPROTECT
(
OWNER VARCHAR(100),
OBJECT VARCHAR(100),
GRANTEE VARCHAR(100),
GRANTOR VARCHAR(100),
PROTECTTYPE CHAR(10),
ACTION VARCHAR(30),
COLUMNX VARCHAR(100)
)

OPEN ALLDATABASES
FETCH NEXT FROM ALLDATABASES INTO @DB
WHILE ( @@FETCH_STATUS = 0 )
BEGIN
	-- GENERATE COMMAND TO GET OBJECT PERMISSIONS FOR CURRENT DATABASE
	SET @CMD = '[' + @DB + '].[DBO].[SP_HELPROTECT]'
	-- GET OBJECT PERMISSIONS INTO TEMPORARY TABLE
	INSERT  INTO #TMPPROTECT
	EXEC ( @CMD )
			
	-- GENERATE COMMANDS TO GRANT OBJECTS PERMISSIONS FOR REFERENCES, SELECT, UPDATE TO @NEWUSER
	INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*GRANT OBJECTS PERMISSIONS FOR REFERENCES, SELECT, UPDATE*/'; 
	INSERT  INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT)
	SELECT  CASE WHEN RTRIM(PROTECTTYPE) = 'GRANT_WGO'
	THEN CASE WHEN U.ISINVALID = 1 THEN ' /*' ELSE '' END +
	'GRANT ' + ACTION + ' ON ['
	+ @DB + '].[' + OWNER + '].['
	+ OBJECT + '] TO ['
	+ RTRIM(U.USERNAME) + ']'
	+ ' WITH GRANT OPTION'
	ELSE 'GRANT ' + ACTION + ' ON ['
	+ @DB + '].[' + OWNER + '].['
	+ OBJECT + '] TO ['
	+ RTRIM(U.USERNAME) + ']' + CASE WHEN U.ISINVALID = 1 THEN '*/ ' ELSE '' END
	END AS RIGHTS_TEXT
	FROM    #TMPPROTECT,#TMPUSERS U  
	WHERE   GRANTEE = U.Username
	AND OBJECT <> '.'
	AND COLUMNX = '(ALL+NEW)'

	-- GRANT COLUMN PERMISSION ON OBJECTS
	INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*GRANT COLUMN PERMISSION ON OBJECTS*/'; 
	INSERT  INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT)
	SELECT  CASE WHEN RTRIM(PROTECTTYPE) = 'GRANT_WGO'
	THEN CASE WHEN U.ISINVALID = 1 THEN ' /*' ELSE '' END +
	'GRANT ' + ACTION + ' ON ['
	+ @DB + '].[' + OWNER + '].['
	+ OBJECT + ']([' + COLUMNX
	+ '])' + ' TO ['
	+ RTRIM(U.USERNAME) + ']'
	+ ' WITH GRANT OPTION'
	ELSE 'GRANT ' + ACTION + ' ON ['
	+ @DB + '].[' + OWNER + '].['
	+ OBJECT + ']([' + COLUMNX
	+ '])' + ' TO ['
	+ RTRIM(U.USERNAME) + ']' + CASE WHEN U.ISINVALID = 1 THEN '*/ ' ELSE '' END
	END AS RIGHTS_TEXT
	FROM    #TMPPROTECT,#TMPUSERS U
	WHERE   GRANTEE = U.username AND GRANTEE NOT IN ('dbo','guest','sys','INFORMATION_SCHEMA')
	AND OBJECT <> '.'
	AND COLUMNX <> '(ALL+NEW)'
	AND COLUMNX <> '.'

	-- GRANT INSERT, DELETE, AND EXECUTE PERMISSION ON OBJECTS
	INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*GRANT INSERT, DELETE, AND EXECUTE PERMISSION ON OBJECTS*/'; 
	INSERT  INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT)
	SELECT  CASE WHEN RTRIM(PROTECTTYPE) = 'GRANT_WGO'
	THEN CASE WHEN U.ISINVALID = 1 THEN '/*' ELSE '' END + ' GRANT ' + ACTION + ' ON ['
	+ @DB + '].[' + OWNER + '].['
	+ OBJECT + '] TO ['
	+ RTRIM(U.USERNAME) + ']'
	+ ' WITH GRANT OPTION'
	ELSE 'GRANT ' + ACTION + ' ON ['
	+ @DB + '].[' + OWNER + '].['
	+ OBJECT + '] TO ['
	+ RTRIM(U.USERNAME) + ']' + CASE WHEN U.ISINVALID = 1 THEN '*/ ' ELSE '' END
	END AS RIGHTS_TEXT
	FROM    #TMPPROTECT,#TMPUSERS U
	WHERE   GRANTEE = U.username
	AND OBJECT <> '.'
	AND ACTION IN ( 'INSERT', 'DELETE',
	'EXECUTE' )
	AND COLUMNX = '.'

	-- GRANT STATEMENT PERMISSIONS
	INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*GRANT GRANT STATEMENT PERMISSIONS*/';
	INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT 'DECLARE @Result int = 0';
	INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT)
	SELECT CASE WHEN U.ISINVALID = 1 THEN ' /*' ELSE '' END +
	' EXEC @result = dbo.sp_helprotect @name = ' + QUOTENAME(RTRIM(ACTION),'''') + ', @username = ' + QUOTENAME(RTRIM(U.USERNAME),'''') + '; IF @result = 1 '+
	'GRANT ' + ACTION + ' TO ['
	+ RTRIM(U.USERNAME) + '] ELSE PRINT ''GRANT ' + RTRIM(ACTION) + ' already exists for user ' + RTRIM(U.USERNAME) + '''' +	CASE WHEN U.ISINVALID = 1 THEN '*/ ' ELSE '' END AS RIGHTS_TEXT
	FROM #TMPPROTECT,#TMPUSERS U
	WHERE GRANTEE = U.username 
	AND ACTION<> 'CONNECT' --Connect action is scripted later.
	AND OBJECT = '.'
	-- REMOVE RECORDS FOR TEMPORARY TABLE IN PREPARATION FOR THE NEXT DATABASE TO BE PROCESSES
	TRUNCATE TABLE #TMPPROTECT
	
	-- GET NEXT DATABASE TO PROCESS
	FETCH NEXT FROM ALLDATABASES INTO @DB
END -- WHILE (@@FETCH_STATUS = 0)
CLOSE ALLDATABASES
DEALLOCATE ALLDATABASES










---Server level permissions
/* Generate statements to create server permissions for SQL logins, Windows Logins, and Groups */ 


INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*ADD SERVER LEVEL PERMISSIONS*/'; 
INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT 'USE ' + QUOTENAME('MASTER') + ' /* Change context again to Master */'




 
DECLARE ALLLOGINS CURSOR
FOR SELECT  distinct LOGINNAME
FROM    #TMPUSERS where LOGINNAME is not null  
OPEN ALLLOGINS
FETCH NEXT FROM ALLLOGINS INTO @LOGINNAME

WHILE ( @@FETCH_STATUS = 0 )
BEGIN


-- Role Members 

INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) 
SELECT  'IF IS_SRVROLEMEMBER(' + QUOTENAME(usr1.name, '''') + ',' + QUOTENAME(usr2.name, '''') +  ')=0 EXEC sp_addsrvrolemember @rolename =' + SPACE(1) + QUOTENAME(usr1.name, '''') + ', @loginame =' + SPACE(1) + QUOTENAME(usr2.name, '''') + ' ELSE PRINT ''USER ' + usr2.name + ' Already has role ' + usr1.name + ''''
FROM    sys.server_principals AS usr1
        INNER JOIN sys.server_role_members AS rm ON usr1.principal_id = rm.role_principal_id
        INNER JOIN sys.server_principals AS usr2 ON rm.member_principal_id = usr2.principal_id
WHERE usr2.name = @LOGINNAME and usr2.name<>'sa'
ORDER BY rm.role_principal_id ASC; 

-- Permissions 
INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) 
SELECT 'IF EXISTS(SELECT 1 FROM sys.server_permissions AS server_permissions WITH (NOLOCK) INNER JOIN sys.server_principals AS server_principals WITH (NOLOCK) ON server_permissions.grantee_principal_id = server_principals.principal_id WHERE server_permissions.state_desc = ' 
+ QUOTENAME(server_permissions.state_desc , '''') + ' AND server_principals.name = ' + QUOTENAME(server_principals.name , '''') + ' AND server_permissions.permission_name = ' + QUOTENAME(server_permissions.permission_name , '''') + ') ' 
+ server_permissions.state_desc COLLATE SQL_Latin1_General_CP1_CI_AS + ' ' + server_permissions.permission_name COLLATE SQL_Latin1_General_CP1_CI_AS
        + ' TO [' + server_principals.name COLLATE SQL_Latin1_General_CP1_CI_AS + ']' + ' ELSE PRINT ''USER ' + server_principals.name + ' already has permission ' + server_permissions.state_desc COLLATE SQL_Latin1_General_CP1_CI_AS + ' ' + server_permissions.permission_name COLLATE SQL_Latin1_General_CP1_CI_AS + ''''
FROM    sys.server_permissions AS server_permissions WITH (NOLOCK)
        INNER JOIN sys.server_principals AS server_principals WITH (NOLOCK) ON server_permissions.grantee_principal_id = server_principals.principal_id
WHERE   server_principals.type IN ('S', 'U', 'G')
AND server_principals.name = @LOGINNAME 
	AND server_principals.name<>'sa' 
ORDER BY server_principals.name ,
        server_permissions.state_desc ,
        server_permissions.permission_name;


-- GET NEXT USER TO PROCESS
FETCH NEXT FROM ALLLOGINS INTO @LOGINNAME
END -- WHILE (@@FETCH_STATUS = 0)
CLOSE ALLLOGINS
DEALLOCATE ALLLOGINS



INSERT INTO #TMP_LOGIN_RIGHTS(RIGHTS_TEXT) SELECT '/*END OF SCRIPT*/'; 






-- DROP TEMPORARY TABLE THAT HELD OBJECT PERMISSIONS
DROP TABLE #TMPPROTECT
---------------------------------------------------------------------------------
--Update old 2008 SSRS Accounts with new SSRS 2014 accounts
UPDATE #TMP_LOGIN_RIGHTS SET RIGHTS_TEXT=REPLACE(REPLACE(REPLACE(RIGHTS_TEXT,'CN\SVC-SQLPRDRS01-DSN','CN\SVC-SSRSPRDG730-DSN'),'CN\SVC-SQLUATRS01-DSN','CN\SVC-SSRSUATG730-DSN'),'CN\SVC-SQLDEVRS01-DSN','CN\SVC-SSRSDEVG730-DSN' )

-- GET ALL THE GENERATED COMMANDS

IF @MANUAL_MODE = 0 
BEGIN
	DECLARE @ID INT
	DECLARE COMMANDS CURSOR
	FOR SELECT RIGHTS_TEXT
	FROM #TMP_LOGIN_RIGHTS GROUP BY RIGHTS_TEXT ORDER BY MIN(RIGHTSID)
	OPEN COMMANDS
	FETCH NEXT FROM COMMANDS INTO @CMD
	WHILE ( @@FETCH_STATUS = 0 )
	BEGIN
		SELECT @CMD as CMD
		FETCH NEXT FROM COMMANDS INTO @CMD
	END 
	CLOSE COMMANDS
	DEALLOCATE COMMANDS
	END
ELSE
BEGIN
	SELECT RIGHTS_TEXT FROM #TMP_LOGIN_RIGHTS GROUP BY RIGHTS_TEXT ORDER BY MIN(RIGHTSID)
END
DROP TABLE #TMP_LOGIN_RIGHTS
DROP TABLE #TMPUSERS




