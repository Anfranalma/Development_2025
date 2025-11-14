
DELIMITER $$

CREATE PROCEDURE events_insert()
BEGIN


  insert ignore into dba.events_current_stat_filtered
  SELECT thread_id,
        event_id,
        end_event_id, 
        event_name,
        timer_start, 
        timer_end, 
        current_schema
  FROM performance_schema.events_statements_current;
    


END;
$$

DELIMITER ;

create definer=root event update_events
on schedule at CURRENT_TIMESTAMP + INTERVAL 20 SECOND
Do
    call threads_insert();

create definer='process_listing'@'localhost' event update_events
on SCHEDULE EVERY 60 SECOND
STARTS '2021-04-06 11:22:00'
ENDS '2022-04-06 11:22:00'
ON COMPLETION NOT PRESERVE ENABLE
Do
    call events_insert();

    SqlCcaq2017