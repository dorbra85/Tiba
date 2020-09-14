CREATE DATABASE GitHub;
go

use GitHub

CREATE TABLE Repositories (
 	[Id] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[FullName] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Private] [bit] NOT NULL
);

CREATE TABLE Users (
	[UserName] [varchar](250) NOT NULL PRIMARY KEY,
	[FullName] [varchar](250) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[UserRole] [varchar](250) NOT NULL,
	[Token] [varchar](500) NULL,
);