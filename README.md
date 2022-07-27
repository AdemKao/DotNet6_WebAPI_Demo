# DotNet6_WebAPI_Demo **CRUD**

## Install Package
	-	Microsoft.EntityFrameworkCore.Design
	-	Microsoft.EntityFrameworkCore.SqlServer
	-	dotnet-ef
		```
		PM> dotnet tool uninstall --global dotnet-ef
		PM> dotnet tool install --global dotnet-ef
		```
## dotnet EF Migration
	Server Simulater must be stoped.
	```
	PM> cd DotNet6_WebAPI_Demo

	PM> dotnet ef migrations add CreateInitial
	Build started...
	Build succeeded.
	info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
    Entity Framework Core 6.0.7 initialized 'DataContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.7' with options: None
	Done. To undo this action, use 'ef migrations remove'
	```
	Then create database
	```
	PM> dotnet ef database update
    Build started...
    Build succeeded.
    info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
          Entity Framework Core 6.0.7 initialized 'DataContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.7' with options: None
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (735ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
          CREATE DATABASE [superherodb];
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (140ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
          IF SERVERPROPERTY('EngineEdition') <> 5
          BEGIN
              ALTER DATABASE [superherodb] SET READ_COMMITTED_SNAPSHOT ON;
          END;
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (21ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
          SELECT 1
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (391ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
          CREATE TABLE [__EFMigrationsHistory] (
              [MigrationId] nvarchar(150) NOT NULL,
              [ProductVersion] nvarchar(32) NOT NULL,
              CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
          );
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
          SELECT 1
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (21ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
          SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (8ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
          SELECT [MigrationId], [ProductVersion]
          FROM [__EFMigrationsHistory]
          ORDER BY [MigrationId];
    info: Microsoft.EntityFrameworkCore.Migrations[20402]
          Applying migration '20220727121341_CreateInitial'.
    Applying migration '20220727121341_CreateInitial'.
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (117ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
          CREATE TABLE [SuperHeroes] (
              [Id] int NOT NULL IDENTITY,
              [Name] nvarchar(max) NOT NULL,
              [FirstName] nvarchar(max) NOT NULL,
              [LastName] nvarchar(max) NOT NULL,
              [Place] nvarchar(max) NOT NULL,
              CONSTRAINT [PK_SuperHeroes] PRIMARY KEY ([Id])
          );
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
          Executed DbCommand (43ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
          INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
          VALUES (N'20220727121341_CreateInitial', N'6.0.7');
    Done.
	```
