
IF NOT EXISTS(SELECT TOP 1 * FROM OrganizationTypes WHERE ID IN( 1, 2, 3, 4, 5, 6, 7, 8))
BEGIN
	INSERT INTO OrganizationTypes(Id, Name, Dsc)
	VALUES (1, 'Vessel Chartere(s)', '');

	INSERT INTO OrganizationTypes(Id, Name, Dsc)
	VALUES (2, 'Requesting Organization', '');

	INSERT INTO OrganizationTypes(Id, Name, Dsc)
	VALUES (3, 'Others', '');
	
	INSERT INTO OrganizationTypes(Id, Name, Dsc)
	VALUES (4, 'ISM Organization', '');
	
	INSERT INTO OrganizationTypes(Id, Name, Dsc)
	VALUES (5, 'Isurer Company', '');
	
	INSERT INTO OrganizationTypes(Id, Name, Dsc)
	VALUES (6, 'Carrier Company', '');
	
	INSERT INTO OrganizationTypes(Id, Name, Dsc)
	VALUES (7, 'Vessel Owner(s)', '');
	
	INSERT INTO OrganizationTypes(Id, Name, Dsc)
	VALUES (8, 'Local Representative', '');
	
END
GO



IF NOT EXISTS(SELECT TOP 1 * FROM OcurrenceTypes)
BEGIN
	
	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (1, 'PSC Detention');

	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (2, 'PSC Deficiencies');

	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (3, 'Contravention');

	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (4, 'Insp flag');

	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (5, 'Info NC');

	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (6, 'Casuality');

	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (7, 'Exemption');

	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (8, 'Condition w/cert');

	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (9, 'Condition');

	INSERT INTO OcurrenceTypes(Id, Name)
	VALUES (10, 'Comp. Under Observation');

END
GO


IF NOT EXISTS(SELECT TOP 1 * FROM Lookups)
BEGIN

	INSERT INTO Lookups(NAME, NAMEKEY, Id, IsActive)
	VALUES ('Vessel Type', 'VesselType', 1, 1);

	INSERT INTO Lookups(NAME, NAMEKEY, Id, IsActive)
	VALUES ('Vessel Status For Temporary Registration', 'VesselStatusForTemporaryRegistration', 2, 1);

	INSERT INTO Lookups(NAME, NAMEKEY, Id, IsActive)
	VALUES ('Hull Material', 'HullMaterial', 3, 1);

	INSERT INTO Lookups(NAME, NAMEKEY,Id, IsActive)
	VALUES ('Radio Accounting Authority(AAIC)', 'RadioAccountingAuthority', 4, 1);

	INSERT INTO Lookups(NAME, NAMEKEY,Id, IsActive)
	VALUES ('Class Society', 'ClassSociety', 5, 1);

	INSERT INTO Lookups(NAME, NAMEKEY,Id, IsActive)
	VALUES ('Vessel Status For Ownership Registration', 'VesselStatusForOwnershipRegistration', 6, 1);

	INSERT INTO Lookups(NAME, NAMEKEY, Id,IsActive)
	VALUES ('Authorization for Temporary Registration', 'AuthorizationForTemporaryRegistration', 7, 1);

	INSERT INTO Lookups(NAME, NAMEKEY, Id,IsActive)
	VALUES ('Registration Port', 'RegistrationPort', 8, 1);

	INSERT INTO Lookups(NAME, NAMEKEY,Id, IsActive)
	VALUES ('SSL Equipment', 'SSLEquipment', 9, 1);

	INSERT INTO Lookups(NAME, NAMEKEY, Id,IsActive)
	VALUES ('TC Members', 'TCMembers', 10, 1);

	INSERT INTO Lookups(NAME, NAMEKEY, Id,IsActive)
	VALUES ('DMLC TITLE', 'DMCLTITLE', 11, 1);

END
GO

IF NOT EXISTS(SELECT TOP 1 * FROM ActivityTypes)
BEGIN
	
	INSERT INTO ActivityTypes(Id, Name,IsActive)
	VALUES (1, '', 1)


END
GO