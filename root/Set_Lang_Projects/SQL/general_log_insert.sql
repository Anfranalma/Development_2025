DELIMITER $$

CREATE PROCEDURE dba.general_log_insert()
BEGIN

  insert into dba.gral_log
  select * from mysql.general_log;  


END;
$$

DELIMITER ;