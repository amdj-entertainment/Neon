IF OBJECT_ID('[NEON].[dbo].[Countries]', 'U') IS NOT NULL
BEGIN
	SET IDENTITY_INSERT [dbo].[Countries] ON;
	
	MERGE INTO [dbo].[Countries] as TARGET
		USING(
			VALUES
				(1, 'United States')
		)
		AS SOURCE ([Id], [Name])
		ON TARGET.Id = SOURCE.Id
	WHEN MATCHED THEN
		UPDATE SET 
			[Name] = SOURCE.[Name]

	WHEN NOT MATCHED BY TARGET THEN
		INSERT ([Id], [Name])
		VALUES (SOURCE.[Id], SOURCE.[Name])

	WHEN NOT MATCHED BY SOURCE THEN DELETE;

	SET IDENTITY_INSERT [dbo].[Countries] OFF;
END