CREATE TABLE [dbo].[Venues]
(
	[Id]			BIGINT IDENTITY (1,1) CONSTRAINT [PK_Venues] PRIMARY KEY NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER CONSTRAINT [DF_Venues_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[WorkspaceId]	BIGINT NOT NULL,
	[Name]			NVARCHAR (100) NOT NULL,
	[AddressId]		BIGINT NOT NULL,
	[Rating]		INT NULL,
	[ContactUserId]	BIGINT NULL,
	[LastUpdate]	DATETIME2 CONSTRAINT [DF_Venues_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]	DATETIME2 CONSTRAINT [DF_Venues_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_Venues_UniqueId]			UNIQUE ([UniqueId]),
	CONSTRAINT [FK_Venues_WorkspaceId]		FOREIGN KEY ([WorkspaceId])		REFERENCES [dbo].[Workspaces] ([Id]),
	CONSTRAINT [FK_Venues_AddressId]		FOREIGN KEY ([AddressId])		REFERENCES [dbo].[Addresses] ([Id]),
	CONSTRAINT [FK_Venues_ContactUserId]	FOREIGN KEY ([ContactUserId])	REFERENCES [dbo].[UsersProfiles] ([Id])
)
