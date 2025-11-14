DELIMITER $$

CREATE PROCEDURE gral_insert()
BEGIN

  insert ignore into dba.gral_log
    select * from mysql.general_log;
    


END;
$$

DELIMITER ;