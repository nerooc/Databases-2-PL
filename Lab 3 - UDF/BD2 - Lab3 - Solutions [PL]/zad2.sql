IF OBJECT_ID('dbo.get_person_table_by_rows') IS NOT NULL
 DROP FUNCTION dbo.get_person_table_by_rows;
GO

CREATE FUNCTION dbo.get_person_table_by_rows(@firstRow INT, @lastRow INT)
RETURNS @data TABLE
(
	firstName NCHAR(60),
	lastName NCHAR(60),
	email NCHAR(60),
	address NCHAR(60)
)
AS
BEGIN
	DECLARE @temp TABLE
	(
		firstName NCHAR(60),
		lastName NCHAR(60),
		email NCHAR(60),
		address NCHAR(60),
		row_number INT
	)
	INSERT INTO @temp(firstName, lastName, email, address, row_number)
	SELECT x.FirstName, x.LastName, x.EmailAddress, y.AddressLine1, Row_Number() OVER (ORDER BY x.LastName,x.FirstName,y.AddressLine1) AS row_number 
	FROM (SELECT x.BusinessEntityID, FirstName, LastName, EmailAddress FROM Person.Person x, Person.EmailAddress y WHERE x.BusinessEntityID = y.BusinessEntityID) AS x,
	(SELECT y.BusinessEntityID, x.AddressLine1 FROM Person.Address x INNER JOIN Person.BusinessEntityAddress y ON x.AddressID = y.AddressID) As y 
	WHERE x.BusinessEntityID = y.BusinessEntityID
	ORDER BY x.LastName, x.FirstName,y.AddressLine1;

	INSERT INTO @data(firstName, lastName,email, address)
	SELECT firstName, lastName, address, email FROM @temp WHERE row_number BETWEEN @firstRow AND @lastRow;
RETURN
END;

GO
SELECT * FROM dbo.get_person_table_by_rows(50, 70);