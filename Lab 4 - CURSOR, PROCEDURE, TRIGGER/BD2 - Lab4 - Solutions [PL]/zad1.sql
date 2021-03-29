-- Opracować przykład procedury składowanej z wykorzystaniem kursora
-- tworzący wydruk z dowolnej tabeli w bazie danych AdvantureWorks w
-- określonym formacie.

USE AdventureWorks;
GO

IF OBJECT_ID('dbo.print_data') IS NOT NULL
 DROP PROC dbo.print_data;
GO

CREATE PROC dbo.print_data
AS BEGIN
	DECLARE @emp_id int, @vac_hrs int
	DECLARE empcur CURSOR FOR
	SELECT	EmployeeID, VacationHours FROM HumanResources.Employee WHERE EmployeeID <= 30;
	OPEN empcur
		FETCH NEXT FROM empcur INTO @emp_id, @vac_hrs;
		WHILE @@FETCH_STATUS = 0
		BEGIN
			print 'Employee with id ' + cast(@emp_id as varchar) + ' currently has ' + cast(@vac_hrs as varchar) + ' vacation hours.';
			FETCH NEXT FROM empcur INTO @emp_id, @vac_hrs;
		END
	CLOSE empcur
	DEALLOCATE empcur
END

GO
EXECUTE dbo.print_data;