-- Zadanie 1
USE testCLR

GO
CREATE ASSEMBLY [Lab7.GetSystemTime] FROM 'c:\Users\Administrator\Documents\CLR1.dll';

GO
CREATE FUNCTION [dbo].[getSystemTime]()
RETURNS [datetime]
AS
EXTERNAL NAME
[Lab7.GetSystemTime].[LabCLR].[GetSystemTime];

GO
SELECT SqlCLRSystemTime=[dbo].[getSystemTime]();