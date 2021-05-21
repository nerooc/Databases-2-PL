USE testCLR;
GO

CREATE TABLE test1 (
	el int
);

CREATE TABLE logs (
	log_id INT IDENTITY PRIMARY KEY,
	insertion_date DATETIME NOT NULL DEFAULT (getDate()),
	user VARCHAR(30) NOT NULL,
	content VARCHAR(30) NOT NULL,
);

INSERT INTO test1 VALUES(1);
