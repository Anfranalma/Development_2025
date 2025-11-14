/* Queries I don't understand */

select origin, id,
  (select count(*)
  from flights f
  
  where f.id < flights.id
  and f.origin=flights.origin) +1
  as flight_sequence_number
from flights;

/*

Generalizations
Congratulations! You’ve just learned about non-correlated and correlated subqueries in SQL. What can we generalize so far?

- Subqueries are used to complete an SQL transformation by nesting one query within another query.

- A non-correlated subquery is a subquery that can be run independently of the outer query and can be used to complete a multi-step transformation.

- A correlated subquery is a subquery that cannot be run independently of the outer query. The order of operations in a correlated subquery is as follows:

1. A row is processed in the outer query.

2. Then, for that particular row in the outer query, the subquery is executed.

*/

select id,avg(a.sale_price) from (
select id,sale_price from order_items
union all
select id,sale_price from order_items_historic)
as a
group by id;


select category from new_products
intersect
select category from legacy_products;

select category from legacy_products
except
select category from new_products;

/* Generalizations
Congratulations! We just learned about Set Operations in SQL. What can we generalize so far?

The UNION clause allows us to utilize information from multiple tables in our queries.
The UNION ALL clause allows us to utilize information from multiple tables in our queries, including duplicate values.
INTERSECT is used to combine two SELECT statements, but returns rows only from the first SELECT statement that are identical to a row in the second SELECT statement.
EXCEPT returns distinct rows from the first SELECT statement that aren’t output by the second SELECT statement

*/


SELECT
    CASE
        WHEN elevation < 250 THEN 'Low'
        WHEN elevation between 250 and 1749 then 'Medium'
        WHEN elevation > 1750 THEN 'High'
    END AS elevation_tier
    , COUNT(*)
FROM airports
GROUP BY 1;