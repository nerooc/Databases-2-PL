-- Opracować przykład wyzwalacza typu DML dla dowolnego obiektu (tabeli
-- lub widoku) w bazie danych AdvantureWorks. 

USE AdventureWorks;
GO

IF OBJECT_ID('EmployeeLog') IS NOT NULL
 DROP TABLE EmployeeLog;
GO

-- Tworzymy tabelę do której wrzucimy logi zapisane przez trigger

CREATE TABLE EmployeeLog (EmployeeID int, ModifiedDate DATETIME);
GO

-- Tworzymy trigger DML, który spisuje logi modyfikacji:

CREATE TRIGGER employee_logger ON HumanResources.Employee
FOR UPDATE
NOT FOR REPLICATION
AS BEGIN
	INSERT INTO EmployeeLog
	SELECT EmployeeID, getdate()
	FROM inserted
END

-- Testujemy działanie triggera:

UPDATE HumanResources.Employee
SET SickLeaveHours = 44
WHERE EmployeeID = 15;

-- Sprawdzamy czy udało mu się zalogować zmiany

SELECT * FROM EmployeeLog;