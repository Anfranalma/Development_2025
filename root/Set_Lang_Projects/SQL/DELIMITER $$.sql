DELIMITER $$

CREATE PROCEDURE ccaq_insert_sleep_proc()
BEGIN

  insert ignore into dba.ccaq_sleep_proc
  select a.user_host, b.db, 
    date_format(a.event_time, '%Y-%m-%d') as 'Date', 
    count(a.event_time) 
    from dba.ccaq_audit_logs a 
      inner join information_schema.processlist b 
        on a.thread_id=b.id and b.command='Sleep' group by 1,2,3;
    


END;
$$

DELIMITER ;