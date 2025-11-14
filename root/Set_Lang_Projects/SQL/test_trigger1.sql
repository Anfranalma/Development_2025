CREATE TRIGGER general_log_insert
AFTER INSERT ON general_log
FOR EACH ROW
BEGIN

  SET @old_price_sum = 0;
  SET @old_amount_sum = 0;
  SET @old_price_avg = 0;
  SET @old_amount_avg = 0;
  SET @old_sales_cnt = 0;

  SELECT IFNULL(price_sum, 0), IFNULL(amount_sum, 0), IFNULL(price_avg, 0)
       , IFNULL(amount_avg, 0), IFNULL(sales_cnt, 0)
    FROM sales_mv
   WHERE product_name = NEW.product_name
    INTO @old_price_sum, @old_amount_sum, @old_price_avg
       , @old_amount_avg, @old_sales_cnt
  ;

  SET @new_price_sum = @old_price_sum + NEW.product_price;
  SET @new_amount_sum = @old_amount_sum + NEW.product_amount;
  SET @new_sales_cnt = @old_sales_cnt + 1;
  SET @new_price_avg = @new_price_sum / @new_sales_cnt;
  SET @new_amount_avg = @new_amount_sum / @new_sales_cnt;




  REPLACE INTO sales_mv
  VALUES(NEW.product_name, @new_price_sum, @new_amount_sum, @new_price_avg
       , @new_amount_avg, @new_sales_cnt)
  ;

END;
$$

DELIMITER ;




select id,user,host,db  from information_schema.processlist;

select event_time,user_host,thread_id from mysql.general_log;

select thread_id,current_schema from performance_schema.events_statements_current;

select thread_id,name,processlist_id,processlist_user,processlist_host,processlist_db from performance_schema.threads;



