----- tables 

CREATE TABLE `tblAudit` (
[INDENT]`AuditId` int(8) NOT NULL auto_increment,
`UserName` varchar(50) NOT NULL,
`TableName` varchar(50) NOT NULL,
`FieldName` varchar(50) NOT NULL,
`OldValue` longtext,
`NewValue` longtext,
`DTAdded` timestamp NOT NULL default CURRENT_TIMESTAMP,
PRIMARY KEY  (`AuditId`)[/INDENT]
);

----- FUNCTION 
CREATE PROCEDURE `add_tblAudit`(IN pUserId VARCHAR(50), IN pTableName VARCHAR(50), IN pFieldName VARCHAR(50), IN pOldValue LONGTEXT, IN pNewValue LONGTEXT)
BEGIN
[INDENT]INSERT INTO `tblAudit` (`UserName`, `TableName`, `FieldName`, `OldValue`, `NewValue`)
VALUES (pUserName, pTableName, pFieldName, pOldValue, pNewValue);
RETURN LAST_INSERT_ID() AS `AuditId`;[/INDENT]
END;$$

------------- table for test

CREATE TABLE `tblTest` (
[INDENT]`TestId` int(8) NOT NULL DEFAULT auto_increment,
`TestVarchar` varchar(50),
`TestNumber` int(4) NOT NULL default '0',
`TestDate` DATE NOT NULL default CURRENT_DATE,
PRIMARY KEY (`TestId`)[/INDENT]
);

------------trigger

CREATE TRIGGER [I]trigger_name[/I] [I]trigger_time[/I] [I]trigger_event[/I] ON [I]table_name[/I]
FOR EACH ROW [I]trigger_statement[/I]


-----trigger details

-- Create INSERT event for tblTest
CREATE OR REPLACE trigger_insert_tblTest AFTER INSERT ON tblTest
FOR EACH ROW
[INDENT]BEGIN
		
IF (NEW.TestVarchar <> '') OR (NEW.TestVarchar IS NOT NULL) THEN
[INDENT]CALL add_tblAudit (USER(), "tblTest", "TestVarchar", "--new record--", NEW.TestVarchar);[/INDENT]
END IF;

IF (NEW.TestNumber <> 0) THEN
[INDENT]CALL add_tblAudit (USER(), "tblTest", "TestNumber", "--new record--", NEW.TestNumber);[/INDENT]
END IF;

IF (NEW.TestDate <> '') OR (NEW.TestDate IS NOT NULL) THEN
[INDENT]CALL add_tblAudit (USER(), "tblTest", "TestDate", "--new record--", NEW.TestDate);[/INDENT]
END IF;[/INDENT]

END;$$

-- Create UPDATE event for tblTest
CREATE OR REPLACE trigger_update_tblTest AFTER UPDATE ON tblTest
FOR EACH ROW
[INDENT]BEGIN
		
IF (NEW.TestVarchar <> OLD.TextVarchar) OR (NEW.TestVarchar IS NOT NULL AND OLD.TextVarchar IS NULL) OR (NEW.TestVarchar IS NULL AND OLD.TextVarchar IS NOT NULL) THEN
[INDENT]CALL add_tblAudit (USER(), "tblTest", "TestVarchar", OLD.TestVarchar, NEW.TestVarchar);[/INDENT]
END IF;

IF (NEW.TestNumber <> OLD.TestNumber) THEN
[INDENT]CALL add_tblAudit (USER(), "tblTest", "TestNumber", OLD.TestNumber, NEW.TestNumber);[/INDENT]
END IF;

IF (NEW.TestDate <> OLD.TestDate) OR (NEW.TestDate IS NOT NULL AND OLD.TestDate IS NULL) OR (NEW.TestDate IS NULL AND OLD.TestDate IS NOT NULL) THEN
[INDENT]CALL add_tblAudit (USER(), "tblTest", "TestDate", OLD.TestDate, NEW.TestDate);[/INDENT]
END IF;[/INDENT]
		
END;$$

-- Create DELETE event for tblTest
CREATE OR REPLACE trigger_update_tblTest AFTER DELETE ON tblTest
FOR EACH ROW
[INDENT]BEGIN
		
CALL add_tblAudit (USER(), "tblTest", "TestVarchar", OLD.TestVarchar, "--deleted record--");
CALL add_tblAudit (USER(), "tblTest", "TestNumber", OLD.TestNumber, "--deleted record--");
CALL add_tblAudit (USER(), "tblTest", "TestDate", OLD.TestDate, "--deleted record--);
[/INDENT]		
END;$$




