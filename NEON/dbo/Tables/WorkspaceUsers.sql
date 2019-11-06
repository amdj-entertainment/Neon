CREATE TABLE [dbo].[WorkspaceUsers]
(
	[Id]			BIGINT IDENTITY (1,1) CONSTRAINT [PK_WorkspaceUsers] PRIMARY KEY NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER CONSTRAINT [DF_WorkspaceUsers_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[UserId]		UNIQUEIDENTIFIER NOT NULL,
	[WorkspaceId]	BIGINT NOT NULL,
	[LastUpdate]	DATETIME2 CONSTRAINT [DF_WorkspaceUsers_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]	DATETIME2 CONSTRAINT [DF_WorkspaceUsers_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_WorkspaceUsers_UniqueId]		UNIQUE ([UniqueId]),
	CONSTRAINT [FK_WorkspaceUsers_UserId]		FOREIGN KEY ([UserId]) REFERENCES [dbo].[NeonUsers] ([UserId]),
	CONSTRAINT [FK_WorkspaceUsers_WorkspaceId]	FOREIGN KEY ([WorkspaceId]) REFERENCES [dbo].[Workspaces] ([Id])
)
