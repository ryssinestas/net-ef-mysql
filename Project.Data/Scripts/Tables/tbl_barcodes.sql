CREATE TABLE Barcodes (
    barcode_id int NOT NULL AUTO_INCREMENT,
    barcode_code varchar(255) NOT NULL,
    product_id int NOT NULL,
    PRIMARY KEY (barcode_id),
	FOREIGN KEY (product_id) REFERENCES Products(product_id)
);