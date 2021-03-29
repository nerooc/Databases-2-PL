IF OBJECT_ID('dbo.get_person_from_beID') IS NOT NULL
 DROP FUNCTION dbo.get_person_from_beID;
GO

CREATE FUNCTION dbo.get_person_from_beID(@BusinessEntityID INT)
    RETURNS NCHAR(500)
    AS
    BEGIN
        DECLARE @personFirstName AS NCHAR(30);
        DECLARE @personLastName AS NCHAR(30);
        DECLARE @personEmail AS NCHAR(30);
        DECLARE @personAddress AS NCHAR(60);
        
        SELECT @personFirstName = FirstName FROM Person.Person WHERE BusinessEntityID = @BusinessEntityID;
        SELECT @personLastName = LastName FROM Person.Person WHERE BusinessEntityID = @BusinessEntityID;
        SELECT @personAddress = AddressLine1 FROM Person.Address WHERE AddressID = @BusinessEntityID;
        SELECT @personEmail = EmailAddress FROM Person.EmailAddress WHERE BusinessEntityID = @BusinessEntityID;
    RETURN (@personLastName + ';' + @personFirstName + ';' + @personAddress + ';' + @personEmail);
END;

GO
SELECT dbo.get_person_from_beID(13);