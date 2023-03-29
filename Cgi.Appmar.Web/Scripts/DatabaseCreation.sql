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

CREATE TABLE ActivitySubTypes(
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
)
GO

CREATE Table Users(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Email NVARCHAR(150) NOT NULL,
	PasswordHash NVARCHAR(150) NOT NULL,
	LastLogin DATETIME2 NULL,
	IsActive BIT NOT NULL,
	CreateDate DATETIME2 NOT NULL,
	CreatedBy INT NULL,
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
)
GO

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
)
GO

CREATE TABLE VersselStatus(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Dsc NVARCHAR(200) NULL,
)
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
	CONSTRAINT fk_vessels_vesselstatus FOREIGN KEY (VesselStatusId) REFERENCES VersselStatus(Id),
	CONSTRAINT fk_vessels_usersI FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
	CONSTRAINT fk_vessels_usersII FOREIGN KEY (UpdateBy) REFERENCES Users(Id)
)
GO

CREATE TABLE Activities(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	VesselId INT NOT NULL,
	RequestId INT NOT NULL,
	ActivityTypeId INT NOT NULL,
	ActivitySubtypeId INT NOT NULL, 
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
	CONSTRAINT fk_activities_activitiessubtypes FOREIGN KEY (ActivitySubtypeId) REFERENCES ActivitySubtypes(Id),
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

CREATE TABLE FeeGroups(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR NOT NULL,
	Dsc NVARCHAR NULL
)
GO

CREATE TABLE Feetypes(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR NOT NULL,
	Dsc NVARCHAR NULL
)
GO

CREATE TABLE FeeChargedStatus(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR NOT NULL,
	Dsc NVARCHAR NULL
)
GO

CREATE TABLE Feechaged(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FeeStatusId INT NOT NULL,
	CONSTRAINT fk_feechaged_feechargedstatus FOREIGN KEY (FeeStatusId) REFERENCES FeeChargedStatus(Id)
)
GO

CREATE TABLE Fees(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FeeGroupId INT NOT NULL,
	FeeTypeId INT NOT NULL,
	Value DECIMAL NOT NULL,
	CONSTRAINT fk_fees_feegroups FOREIGN KEY (FeeGroupId) REFERENCES FeeGroups(Id),
	CONSTRAINT fk_fees_feetyps FOREIGN KEY (FeeTypeId) REFERENCES FeeTypes(Id)
)
GO

CREATE TABLE Entities(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	Dsc NVARCHAR(200) NULL
)
GO

CREATE TABLE Approvals(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	EntityId INT NOT NULL,
	EntityTypeId INT NOT NULL,
	IsApproved BIT NOT NULL,
	IsParentApproval BIT NULL,
	Comment NVARCHAR(200) NULL,
	ApprovedBy INT NULL,
	ApprovedDate DATETIME2 NULL,

	CONSTRAINT fk_approvals_entitytypes FOREIGN KEY (EntityTypeId) REFERENCES EntityTypes(Id),
	CONSTRAINT fk_approvals_entities FOREIGN KEY (EntityId) REFERENCES Entities(Id),
	CONSTRAINT fk_approvals_users FOREIGN KEY (ApprovedBy) REFERENCES Users(Id)
)
GO

CREATE TABLE OrganizationTypes(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100),
	Dsc NVARCHAR(200)
)
GO

CREATE TABLE Organizations(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	OrganizationTypeId INT NOT NULL,
	Imo NVARCHAR(100) NULL,
	FiscalNumber NVARCHAR(100) NULL,
	Name NVARCHAR(100) NOT NULL,
	Dsc NVARCHAR(200) NOT NULL,
	CreatedBy INT NOT NULL,
	UpdateBy INT NULL,
	CONSTRAINT fk_organizations_usersI FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
	CONSTRAINT fk_organizations_usersII FOREIGN KEY (UpdateBy) REFERENCES Users(Id),
	CONSTRAINT fk_organizations_organizationtypes FOREIGN KEY (OrganizationTypeId) REFERENCES OrganizationTypes(Id),
)
GO

CREATE TABLE DocumentTypes(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	Dsc NVARCHAR(200) NULL
)
GO

CREATE TABLE Documents(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	VesselId INT NOT NULL,
	DocPath NVARCHAR(200) NULL,
	DocumentTypeId INT NULL,
	IsDraft BIT NOT NULL,
	IsValid BIT NOT NULL,
	IsNecessary BIT NOT NULL,
	UniqueTrackNumber NVARCHAR(100) NULL,
	ExpiryDate DATETIME2 NULL,
	EndDate DATETIME2 NULL,
	CreatedBy INT NOT NULL,
	CreatedDate DATETIME2 NULL,
	UpdatedBy INT NULL,
	UpdatedDate DATETIME2

	CONSTRAINT fk_documents_usersI FOREIGN KEY (CreatedBy) REFERENCES Users(Id),
	CONSTRAINT fk_documents_usersII FOREIGN KEY (UpdatedBy) REFERENCES Users(Id),
	CONSTRAINT fk_documents_documenttypes FOREIGN KEY (DocumentTypeId) REFERENCES DocumentTypes(Id),
	CONSTRAINT fk_documents_vessels FOREIGN KEY (VesselId) REFERENCES Vessels(Id)
)
GO

CREATE TABLE DocumentTypeVesselType(
	Id INT NULL,
	DocumentTypeId INT NOT NULL,
	VesselTypeId INT NOT NULL
	CONSTRAINT fk_documenttypeVesseltype_documenttype FOREIGN KEY (DocumentTypeId) REFERENCES DocumentTypes(Id),
	CONSTRAINT fk_documenttypeVesseltype_vesseltype FOREIGN KEY (VesselTypeId) REFERENCES VersselTypes(Id)
)
GO

CREATE TABLE Lookups(
	Id INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(200) NOT NULL,
	Dsc NVARCHAR(200) NULL,
	IsActive BIT NOT NULL
)
GO

CREATE TABLE LookupValues(
	Id INT IDENTITY(1, 1) PRIMARY KEY,
	LookupId INT NOT NULL,
	Value NVARCHAR(200) NULL,
	CONSTRAINT fk_lookupvalues_lookups FOREIGN KEY (LookupId) REFERENCES Lookups(Id)
)
GO

CREATE TABLE LookupEntityValues(
	Id INT NOT NULL PRIMARY KEY,
	Value NVARCHAR(100) NULL,
	EntityTypeId INT NOT NULL,
	EntityId INT NULL,
	CONSTRAINT fk_lookupentityvalues_entitytypes FOREIGN KEY (EntityTypeId) REFERENCES EntityTypes(Id)
)
GO