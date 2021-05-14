-- Dla bezpieczenstwa query rozdzielic na dwa uzycia

-- PIERWSZE QUERY - tworzymy baze, jezeli istniala to usuwamy

IF EXISTS(select * from sys.databases where name='Lab6db')
DROP DATABASE Lab6db;

CREATE DATABASE Lab6db;

-- DRUGIE QUERY - tworzymy login, usera i dajemy mu role db_owner dla nowej bazy

USE Lab6db;
GO

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'Lab6user')
DROP LOGIN [Lab6user]

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'Lab6user')
DROP USER [Lab6user]

CREATE LOGIN [Lab6user] WITH PASSWORD=N'Testowe123',
DEFAULT_DATABASE=[Lab6db], DEFAULT_LANGUAGE=[polski]
GO
ALTER LOGIN [Lab6user] DISABLE

CREATE USER [Lab6user] FOR LOGIN [Lab6user]
EXEC sp_addrolemember @rolename=db_owner, @membername=[Lab6user];

-- Sprawdzamy jacy uzytkownicy sa db_ownerami
SELECT user_name(member_principal_id)
FROM   sys.database_role_members
WHERE  user_name(role_principal_id) = 'db_owner'
