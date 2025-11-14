DELIMITER $$

CREATE PROCEDURE dba.info_processlist_sleep_insert()
BEGIN

  insert into dba.info_process_sleep
  select a.user_host, b.db, date_format(a.event_time, '%Y-%m-%d') as 'Date', count(a.event_time) from dba.gral_log a 
    inner join information_schema.processlist b on a.thread_id=b.id and b.command='Sleep';


END;
$$

DELIMITER ;