CREATE TABLE [dbo].[Users]
(
	[Id]				BIGINT IDENTITY (1,1) CONSTRAINT [PK_Users] PRIMARY KEY NOT NULL,
	[UniqueId]			UNIQUEIDENTIFIER CONSTRAINT [DF_Users_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[WorkspaceId]		BIGINT NOT NULL,
	[UserName]			NVARCHAR (255) NOT NULL,
	[EmailAddress]		NVARCHAR (150) NOT NULL,
	[ConfirmedEmail]	BIT CONSTRAINT [DF_Users_ConfirmEmail] DEFAULT (0) NOT NULL,
	[HashedPassword]	NVARCHAR (MAX) NOT NULL,
	[LastUpdate]		DATETIME2 CONSTRAINT [DF_Users_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]		DATETIME2 CONSTRAINT [DF_Users_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_Users_UniqueId]		UNIQUE ([UniqueId]),
	CONSTRAINT [FK_Users_Workspaces]	FOREIGN KEY ([WorkspaceId]) REFERENCES [dbo].[Workspaces] ([Id])
)
