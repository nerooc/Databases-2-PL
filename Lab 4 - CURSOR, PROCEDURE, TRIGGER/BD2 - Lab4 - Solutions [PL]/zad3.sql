-- Opracować przykład procedury składowanej z wykorzystaniem struktury
-- RAISERROR przesłania informacji o niemożliwości zrealizowania
-- określonego zadania w bazie danych AdvantureWorks.

USE AdventureWorks;
GO

IF OBJECT_ID('dbo.get_employee') IS NOT NULL
 DROP PROC dbo.get_employee;
GO

CREATE PROC dbo.get_employee
@emp_id AS sysname = NULL
AS
DECLARE @msg AS NVARCHAR(500);


IF @emp_id IS NULL
BEGIN
 SET @msg = N'You need to supply a value for parameter @emp_id.';
 RAISERROR(@msg, 16, 1);
 RETURN;
END

IF @emp_id < 1
BEGIN
 SET @msg = N'You need to supply a positive value for parameter @emp_id.';
 RAISERROR(@msg, 16, 1);
 RETURN;
END

SELECT * FROM HumanResources.Employee 
WHERE EmployeeID = @emp_id;
GO


EXEC dbo.get_employee @emp_id = -5;