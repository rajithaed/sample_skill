# customer_orders

## Task

The query in `query.sql` is supposed to output the average number of items, and average sale price of customer orders by username, but it doesn't. Fix it.

```
AS A
    Sales Person
WHEN I
    View the User sales report
I WANT
    To be able to see each customer's average number of items per order and average sale price
SO THAT
    I can try and sell them more stuff
```

## Validation

* The values are now correct.
* The query reads well.

## Setup

Insert the contents of `setup/init.sql` into a MySQL database. If you use Docker, you can do this with the following command (assumes MacOS / Linux, adjust for Windows):

```bash
docker run --rm --name customer_orders -p 3306:3306 -v "`pwd`/setup/:/docker-entrypoint-initdb.d/" -v "`pwd`/query.sql:/query.sql" -e MYSQL_ROOT_PASSWORD=password mysql:5.6
```

If you use Docker, once your database is up and running, you can run the query with:

```bash
docker exec customer_orders /bin/bash -c '/usr/bin/mysql -u root -ppassword orders </query.sql'
```

The output will be something like this (until you've fixed it).

```
userorder_id    user_id order_date
1       1       2018-02-11 22:40:17
2       1       2018-02-11 22:40:17
3       1       2018-02-11 22:40:17
4       1       2018-02-11 22:40:17
5       2       2018-02-11 22:40:17
6       2       2018-02-11 22:40:17
7       3       2018-02-11 22:40:17
8       3       2018-02-11 22:40:17
9       3       2018-02-11 22:40:17
```
