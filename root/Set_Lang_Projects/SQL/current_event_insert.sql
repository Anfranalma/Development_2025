DELIMITER $$

CREATE PROCEDURE dba.current_event_insert()
BEGIN

  insert into dba.current_event_stat_filtered
  select thread_id,event_id,event_name,timer_start,timer_end,current_schema 
  from performance_schema.events_statements_current;    


END;
$$

DELIMITER ;