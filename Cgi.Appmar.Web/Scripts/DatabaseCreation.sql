
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'APPMAR')
DROP DATABASE APPMAR;
GO

CREATE DATABASE APPMAR;
GO

USE APPMAR;
GO

CREATE TABLE ActivityTypes(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	Dsc NVARCHAR(200) NULL,
	IsActive BIT NOT NULL
)
GO

CREATE TABLE ActivityStatus(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100),
	Dsc NVARCHAR(200)
)
GO

CREATE TABLE EntityTypes(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	Dsc NVARCHAR(200) NULL
)
GO

CREATE TABLE ContactTypes(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Dsc NVARCHAR(200) NULL,
	IsActive BIT NOT NULL
);
GO

CREATE Table Users(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Email NVARCHAR(150) NOT NULL,
	PasswordHash NVARCHAR(150) NOT NULL,
	LastLogin DATETIME2 NULL,
	IsActive BIT NOT NULL,
	CreateDate DATETIME2 NOT NULL,
	CreatedBy INT NOT NULL,
	UpdateDate DATETIME2 NULL,
	UpdateBy INT NULL,
	CONSTRAINT fk_users_usersI FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
	CONSTRAINT fk_users_usersII FOREIGN KEY (UpdateBy) REFERENCES Users(Id),
)
GO

CREATE TABLE Countries(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE Addresses(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	EntityId INT NOT NULL,
	EntityTypeId INT NOT NULL,
	Address1 NVARCHAR(200) NOT NULL,
	Address2 NVARCHAR(200) NULL,
	Address3 NVARCHAR(200) NULL,
	CountryId INT NOT NULL,
	City NVARCHAR(100),
	PostalCode NVARCHAR(100),
	IsMainAddress BIT NOT NULL,
	CreateDate DATETIME2 NOT NULL,
	CreatedBy INT NOT NULL,
	UpdateDate DATETIME2 NULL,
	UpdateBy INT NULL

	CONSTRAINT fk_addresses_countries FOREIGN KEY (CountryId) REFERENCES Countries(iD),
	CONSTRAINT fk_addresses_usersI FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
	CONSTRAINT fk_addresses_usersII FOREIGN KEY (UpdateBy) REFERENCES Users(Id),
);

CREATE Table Contacts(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	EntityId INT NOT NULL,
	EntityTypeId INT NOT NULL,
	ContactTypeId INT NOT NULL,
	Value NVARCHAR(150)NOT NULL,
	IsMainContact BIT NOT NULL,
	CreateDate DATETIME2 NOT NULL,
	CreatedBy INT NOT NULL,
	UpdateDate DATETIME2 NULL,
	UpdateBy INT NULL,
	CONSTRAINT fk_contacts_contacttypes FOREIGN KEY (ContactTypeId) REFERENCES ContactTypes(Id),
	CONSTRAINT fk_contacts_usersI FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
	CONSTRAINT fk_contacts_usersII FOREIGN KEY (UpdateBy) REFERENCES Users(Id),
)
GO

CREATE TABLE VersselTypes(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Dsc NVARCHAR(200) NULL,
	IsActive BIT NOT NULL
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
	Former NVARCHAR(200) NULL,

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

	CreateDate DATETIME2 NOT NULL,
	CreatedBy INT NOT NULL,
	UpdateDate DATETIME2 NULL,
	UpdateBy INT NULL

	CONSTRAINT fk_vessels_vesseltypes FOREIGN KEY (VesselTypeId) REFERENCES VersselTypes(Id),
	CONSTRAINT fk_vessels_vesselstatus FOREIGN KEY (VesselStatusId) REFERENCES VersselStatus(Id)
)
GO



CREATE TABLE Activities(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	VesselId INT NOT NULL,
	RequestId INT NOT NULL,
	ActivityTypeId INT NOT NULL,
	ActivityStatusId INT NOT NULL,
	CsrDocNum NVARCHAR(200) NULL,
	RejectDesc NVARCHAR(200) NULL,
	RequestedOrgId INT NULL,
	CreatedBy INT NOT NULL,
	CreatedDate DATETIME2 NOT NULL,
	UpdateBy INT NULL,
	UbdatedDate DATETIME2 NULL,
	ClosedBy INT NULL,
	EndDate DATETIME2 NULL,

	CONSTRAINT fk_activities_vessels FOREIGN KEY (VesselId) REFERENCES Vessels(Id),
	CONSTRAINT fk_activities_activitytype FOREIGN KEY (ActivityTypeId) REFERENCES ActivityTypes(Id),
	CONSTRAINT fk_activities_usersI FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
	CONSTRAINT fk_activities_usersII FOREIGN KEY (UpdateBy) REFERENCES Users(Id),
)
GO


CREATE Table Roles(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Dsc NVARCHAR(200) NULL
)
GO

CREATE Table Categories(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	Dsc NVARCHAR(200) NULL
)
GO

CREATE Table Permissions(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Dsc NVARCHAR(200) NULL,
	CategoryId INT NOT NULL,
	CONSTRAINT fk_permissions_categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)
GO


CREATE TABLE RolesPermissions(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	RoleId INT NOT NULL,
	PermissionId INT NOT NULL,
	CONSTRAINT fk_rolespermissions_roles FOREIGN KEY (RoleId) REFERENCES Roles(Id),
	CONSTRAINT fk_rolespermissions_permissions FOREIGN KEY (PermissionId) REFERENCES Permissions(Id)
)
GO



