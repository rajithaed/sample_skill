SELECT
  T3.username,
  count(T3.username) NoOfOrders,
  AVG(T3.itemCount) avgItems,
  T3.AvgPrice AS avgPrice
FROM (SELECT
    T2.username,
    T2.userorder_id AS orderNumber,
  T2.price,
    COUNT(T2.userorder_id) AS itemCount,
    AVG(T2.price) AS AvgPrice
  FROM (SELECT
      user.username,
      T1.userorder_id,
      T1.price
    FROM user AS user
      INNER JOIN (SELECT
          userOrders.user_id,
          items.userorder_id,
          items.item_id,
          items.price
        FROM userorder AS userOrders
          INNER JOIN (SELECT
              item_id,
              userorder_id,
              price
            FROM item) AS items
            ON items.userorder_id = userOrders.userorder_id) AS T1
        ON T1.user_id = user.user_id) AS T2 
  GROUP BY T2.userorder_id) AS T3
GROUP BY T3.username