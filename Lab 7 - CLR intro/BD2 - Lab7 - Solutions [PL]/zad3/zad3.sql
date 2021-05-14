-- Zadanie 3 
USE AdventureWorks;

GO
DROP PROCEDURE search_email;

GO
CREATE PROCEDURE search_email(@text varchar(max))
AS
SELECT EmailAddress FROM HumanResources.Employee e
	JOIN Person.Contact c ON e.ContactID = .ContactID
	WHERE EmailAddress LIKE '%' + @text + '%';

GO
EXEC search_email @text ='russel';