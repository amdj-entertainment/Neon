IF OBJECT_ID('[NEON].[dbo].[NeonRole]', 'U') IS NOT NULL
BEGIN
	MERGE INTO [dbo].[NeonRole] as TARGET
		USING(
			VALUES
				(NEWID(), 'SystemAdministrator'),
				(NEWID(), 'SystemModerator'),
				(NEWID(), 'SystemEditor'),
				(NEWID(), 'SystemSupport'),
				(NEWID(), 'StandardUser')
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
END