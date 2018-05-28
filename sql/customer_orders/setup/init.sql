CREATE DATABASE orders;
USE orders;

CREATE TABLE user
(
	user_id BIGINT NOT NULL AUTO_INCREMENT,
  username VARCHAR(64) NOT NULL,
  PRIMARY KEY (user_id)
);

INSERT INTO user (username) VALUES ('denver'); -- 1
INSERT INTO user (username) VALUES ('jon'); -- 2
INSERT INTO user (username) VALUES ('skullcrusher'); -- 3

CREATE TABLE userorder
(
	userorder_id BIGINT NOT NULL AUTO_INCREMENT,
	user_id BIGINT NOT NULL,
  order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (userorder_id),
	FOREIGN KEY (user_id) REFERENCES user(user_id)
);

INSERT INTO userorder (user_id) VALUES (1);
INSERT INTO userorder (user_id) VALUES (1);
INSERT INTO userorder (user_id) VALUES (1);
INSERT INTO userorder (user_id) VALUES (1);
INSERT INTO userorder (user_id) VALUES (2);
INSERT INTO userorder (user_id) VALUES (2);
INSERT INTO userorder (user_id) VALUES (3);
INSERT INTO userorder (user_id) VALUES (3);
INSERT INTO userorder (user_id) VALUES (3);

CREATE TABLE item
(
	item_id BIGINT NOT NULL AUTO_INCREMENT,
  userorder_id BIGINT NOT NULL,
	price DECIMAL(18, 3) NOT NULL,
  itemdesc VARCHAR(64),
  PRIMARY KEY (item_id),
	FOREIGN KEY (userorder_id) REFERENCES userorder(userorder_id)
);

INSERT INTO item (userorder_id, price, itemdesc) VALUES (1, 10.00, 'bacon crisps');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (1, 36.12, 'greggs sausage roll');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (1, 43, 'remote control pedalo');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (1, 7, 'pen on a string');

INSERT INTO item (userorder_id, price, itemdesc) VALUES (2, 12, 'instant coffee');

INSERT INTO item (userorder_id, price, itemdesc) VALUES (3, 4.12, 'stacks of green paper');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (3, 12.4, 'scary mask');

INSERT INTO item (userorder_id, price, itemdesc) VALUES (4, 88.8, 'carved wooden sculpture');

INSERT INTO item (userorder_id, price, itemdesc) VALUES (5, 123, 'live milipede');

INSERT INTO item (userorder_id, price, itemdesc) VALUES (6, 991, 'mind controlling wig');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (6, 18, 'bee hive, glass');

INSERT INTO item (userorder_id, price, itemdesc) VALUES (7, 18, 'best of the beatles LP');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (7, 1000.12, 'macbook dongle pack');

INSERT INTO item (userorder_id, price, itemdesc) VALUES (9, 7.1, 'skateboarding for the over 60');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (9, 1.3, 'coping with sugar');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (9, 1.4, 'best soviet foods guide');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (9, 5.4, 'pickles - one mans journey');
INSERT INTO item (userorder_id, price, itemdesc) VALUES (9, 66.3, 'mur mur mur mur mur');