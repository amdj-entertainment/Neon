CREATE TABLE [dbo].[UsersProfiles]
(
	[Id]			BIGINT IDENTITY (1,1) NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER CONSTRAINT [DF_UsersProfiles_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[UserId]		UNIQUEIDENTIFIER CONSTRAINT [PK_UsersProfiles] PRIMARY KEY NOT NULL,
	[FirstName]		NVARCHAR (100) NOT NULL,
	[LastName]		NVARCHAR (255) NOT NULL,
	[AvatarUrl]		NVARCHAR(MAX) NULL,
	[AddressId]		BIGINT NULL,
	[PhoneNumber]	NVARCHAR (50) NULL,
	[Email]	NVARCHAR (100) NULL,
	[LastUpdate]	DATETIME2 CONSTRAINT [DF_UsersProfiles_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]	DATETIME2 CONSTRAINT [DF_UsersProfiles_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_UsersProfiles_UniqueId]	UNIQUE ([UniqueId]),
	CONSTRAINT [UK_UsersProfiles_UserId]	UNIQUE ([UserId]),
	CONSTRAINT [CK_UsersProfiles_UniqueId]	CHECK ([UniqueId] != '00000000-0000-0000-0000-000000000000'),
	CONSTRAINT [FK_UsersProfiles_UserId]	FOREIGN KEY ([UserId])		REFERENCES [dbo].[NeonUsers] ([UserId]) ON DELETE CASCADE,
	CONSTRAINT [FK_UsersProfiles_AddressId] FOREIGN KEY ([AddressId])	REFERENCES [dbo].[Addresses] ([Id]) ON DELETE CASCADE
)
