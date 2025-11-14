DELIMITER $$

CREATE TRIGGER sales_del
AFTER DELETE ON sales
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
   WHERE product_name = OLD.product_name
    INTO @old_price_sum, @old_amount_sum, @old_price_avg
       , @old_amount_avg, @old_sales_cnt
  ;

  SET @new_price_sum = @old_price_sum - OLD.product_price;
  SET @new_amount_sum = @old_amount_sum - OLD.product_amount;
  SET @new_price_avg = @new_price_sum / @new_amount_sum;
  SET @new_sales_cnt = @old_sales_cnt - 1;
  SET @new_amount_avg = @new_amount_sum / @new_sales_cnt;

  REPLACE INTO sales_mv
  VALUES(OLD.product_name, @new_price_sum, @new_amount_sum
       , IFNULL(@new_price_avg, 0), IFNULL(@new_amount_avg, 0)
       , @new_sales_cnt)
  ;

END;
$$

DELIMITER ;