
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'APPMAR')
DROP DATABASE APPMAR;
GO

CREATE DATABASE APPMAR;
GO

USE APPMAR;
GO

CREATE TABLE VersselTypes(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Dsc NVARCHAR(200) NULL,
	Former NVARCHAR(200) NULL
);
GO

CREATE TABLE VersselStatus(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Dsc NVARCHAR(200) NULL,
);
GO

CREATE TABLE Vessels(
	Id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	VesselTypeId INT NULL,
	RegistrationDate DATETIME2 NULL,
	VesselStatusId INT NULL,

	PreviousFlag NVARCHAR(100) NULL,
	FromRegistry NVARCHAR(100) NULL,
	PretendedAreaOfNavigation NVARCHAR(100),
	RegistrationPort NVARCHAR(200),
	RegistryNumber NVARCHAR(100) NULL,

	YearBuilt INT NULL,
	CountryBuilt INT NULL,
	PlaceBuilt NVARCHAR(100) NULL,
	HullMaterial NVARCHAR(100) NULL,
	HullIdentificationNumber NVARCHAR(100) NULL,
	MainEngineBuilder NVARCHAR(200) NULL,
	NoAndTypeOfEngine NVARCHAR(200) NULL,
	TotalPowerKw NVARCHAR(100) NULL,
	MainEnginesStrokeType NVARCHAR(100) NULL,
	MainEngineFuelType NVARCHAR(100) NULL,
	NumberOfWinchesFore INT NULL,
	NumberOfWinchesAft INT NULL,
	NumberOfSelfTensionWinchesFore INT NULL,
	NumberOfSelfTensionWinchesAft INT NULL,
	DeadWeightTons DECIMAL NULL,
	GrossTonnage DECIMAL NULL,
	NegTonnage DECIMAL NULL,
	LengthOvehal DECIMAL NULL,
	LengthItc DECIMAL NULL,
	BreadthItc DECIMAL NULL,
	DepthItc DECIMAL NULL,
	FullLoadDisplacement NVARCHAR(100) NULL,
	LightShipDisplacement NVARCHAR(100) NULL,
	Notes NVARCHAR(500) NULL,
	Remarks NVARCHAR(500) NULL,

	CONSTRAINT fk_vessels_vesseltypes FOREIGN KEY (VesselTypeId) REFERENCES VersselTypes(Id),
	CONSTRAINT fk_vessels_vesselstatus FOREIGN KEY (VesselStatusId) REFERENCES VersselStatus(Id)
);
GO

CREATE Table Users(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Email NVARCHAR(150) NOT NULL,
	PasswordHash NVARCHAR(150) NOT NULL
)
GO

CREATE Table Roles(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Dsc NVARCHAR(200) NULL
);
GO

CREATE Table Permissions(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Dsc NVARCHAR(200) NULL
);
GO