IF OBJECT_ID('[NEON].[dbo].[State]', 'U') IS NOT NULL
BEGIN
	SET IDENTITY_INSERT [dbo].[State] ON;
	
	MERGE INTO [dbo].[State] as TARGET
		USING(
			VALUES
				(1, 'Alabama'),
				(2, 'Alaska'),
				(3, 'Arizona'),
				(4, 'Arkansas'),
				(5, 'California'),
				(6, 'Colorado'),
				(7, 'Connecticut'),
				(8, 'Delaware'),
				(9, 'Florida'),
				(10, 'Georgia'),
				(11, 'Hawaii'),
				(12, 'Idaho'),
				(13, 'Illinois'),
				(14, 'Indiana'),
				(15, 'Iowa'),
				(16, 'Kansas'),
				(17, 'Kentucky'),
				(18, 'Louisiana'),
				(19, 'Maine'),
				(20, 'Maryland'),
				(21, 'Massachusetts'),
				(22, 'Michigan'),
				(23, 'Minnesota'),
				(24, 'Mississippi'),
				(25, 'Missouri'),
				(26, 'Montana'),
				(27, 'Nebraska'),
				(28, 'Nevada'),
				(29, 'New Hampshire'),
				(30, 'New Jersey'),
				(31, 'New Mexico'),
				(32, 'New York'),
				(33, 'North Carolina'),
				(34, 'North Dakota'),
				(35, 'Ohio'),
				(36, 'Oklahoma'),
				(37, 'Oregon'),
				(38, 'Pennsylvania'),
				(39, 'Rhode Island'),
				(40, 'South Carolina'),
				(41, 'South Dakota'),
				(42, 'Tennessee'),
				(43, 'Texas'),
				(44, 'Utah'),
				(45, 'Vermont'),
				(46, 'Virginia'),
				(47, 'Washington'),
				(48, 'West Virginia'),
				(49, 'Wisconsin'),
				(50, 'Wyoming')
		)
		AS SOURCE ([Id], [Name], [Description])
		ON TARGET.Id = SOURCE.Id
	WHEN MATCHED THEN
		UPDATE SET 
			[Name] = SOURCE.[Name]

	WHEN NOT MATCHED BY TARGET THEN
		INSERT ([Id], [Name], [Description])
		VALUES (SOURCE.[Id], SOURCE.[Name], SOURCE.[Description])

	WHEN NOT MATCHED BY SOURCE THEN DELETE;

	SET IDENTITY_INSERT [dbo].[State] OFF;
END