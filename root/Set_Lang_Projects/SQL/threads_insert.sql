DELIMITER $$

CREATE PROCEDURE dba.threads_insert()
BEGIN

  insert into dba.threads
  select thread_id, processlist_id, processlist_user, processlist_host, processlist_db 
  from performance_schema.threads;


END;
$$

DELIMITER ;