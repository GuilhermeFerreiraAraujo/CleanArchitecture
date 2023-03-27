
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

