-- Zadanie 2 
USE testCLR

GO
CREATE ASSEMBLY [Lab7.GreetUser] FROM 'c:\Users\Administrator\Documents\CLR2.dll';

GO
CREATE FUNCTION [dbo].[greetUser](@login NVARCHAR(max), @server NVARCHAR(max), @system NVARCHAR(max))
RETURNS NVARCHAR(max)
AS
EXTERNAL NAME
[Lab7.GreetUser].[LabCLR].[GreetUser];

GO
SELECT greeting=[dbo].[greetUser](CURRENT_USER, @@SERVERNAME, @@VERSION);