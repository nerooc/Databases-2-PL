IF OBJECT_ID('dbo.get_user_orders') IS NOT NULL
 DROP FUNCTION dbo.get_user_orders;
GO

CREATE FUNCTION dbo.get_user_orders(@name NCHAR(40))
RETURNS TABLE AS
RETURN
WITH SubsCTE
AS
(
	SELECT * FROM
	( SELECT customer.CustomerId as customer, person.FirstName, person.LastName  FROM Person.Person person, Sales.Customer customer WHERE person.BusinessEntityID = customer.PersonID AND LastName = @name) AS a,
	( SELECT * FROM Sales.SalesOrderHeader ) AS b
	WHERE a.customer = b.CustomerId
) SELECT * FROM SubsCTE;

GO
SELECT * FROM dbo.get_user_orders('Alexander');

