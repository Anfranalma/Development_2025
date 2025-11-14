DELIMITER $$

CREATE PROCEDURE dba.cleanup()
BEGIN

  drop table dba.current_event_stat_filtered;
  drop table dba.general_log;
  drop table dba.info_processlist;
  drop table dba.threads;

  create table dba.current_event_stat_filtered(
thread_id bigint(20) unsigned,
event_id bigint(20) unsigned,
event_name varchar(128),
timer_start bigint(20) unsigned,
timer_end bigint(20) unsigned,
current_schema varchar(64));

create table dba.threads( thread_id bigint(20) unsigned, processlist_id bigint(20) unsigned, processlist_user varchar(128), processlist_host varchar(60), processlist_db varchar(64));

create table dba.gral_log like mysql.general_log;

create table dba.info_processlist(id bigint(4), user varchar(128), host varchar(64), db varchar(64));

    


END;
$$

DELIMITER ;