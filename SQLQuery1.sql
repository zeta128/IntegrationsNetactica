﻿CREATE TABLE [dbo].[tblHotel]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL,
	[Descrption] VARCHAR(50) NOT NULL,
	[Phone] VARCHAR(20) NOT NULL,
	[Address] VARCHAR(20) NOT NULL,
	[Photo] VARCHAR(20) NOT NULL,
	[IdCity] INT NOT NULL
)
CREATE TABLE [dbo].[tblRoom]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[PriceNight] INT NOT NULL,
	[Description] VARCHAR(50) NOT NULL,
	[Photo] VARCHAR(20) NOT NULL,
	[IdType] INT NOT NULL,
	[IdHotel] INT NOT NULL
)
CREATE TABLE [dbo].[tblType]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL,
	[Description] VARCHAR(50) NOT NULL
)
