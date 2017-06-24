CREATE TABLE Products (
    product_id int NOT NULL AUTO_INCREMENT,
    product_name varchar(255) NOT NULL,
    product_description varchar(255) NOT NULL,
    product_price DECIMAL NOT NULL,
    PRIMARY KEY (product_id)
);