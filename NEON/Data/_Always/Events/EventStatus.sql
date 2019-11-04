IF OBJECT_ID('[NEON].[dbo].[EventStatus]', 'U') IS NOT NULL
BEGIN
	SET IDENTITY_INSERT [dbo].[EventStatus] ON;
	
	MERGE INTO [dbo].[EventStatus] as TARGET
		USING(
			VALUES
				(1, 'Active', ''),
				(2, 'Postponed', ''),
				(3, 'Rescheduled', ''),
				(4, 'Cancelled', '')
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

	SET IDENTITY_INSERT [dbo].[EventStatus] OFF;
END