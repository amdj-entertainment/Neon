CREATE TABLE [dbo].[NeonUserRole]
(
	[Id]			BIGINT IDENTITY (1,1),
	[UniqueId]		UNIQUEIDENTIFIER		CONSTRAINT [DF_NeonUserRole_UniqueId]	DEFAULT (NEWID()) NOT NULL,
	[UserId]		UNIQUEIDENTIFIER NOT NULL,
	[RoleId]		UNIQUEIDENTIFIER NOT NULL,
	[GuidUser_Id]	UNIQUEIDENTIFIER NOT NULL,
	[CreateDate]	DATETIME2				CONSTRAINT [DF_NeonUserRole_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_NeonUserRole_UniqueId]		UNIQUE ([UniqueId]),
	CONSTRAINT [PK_NeonUserRole_UserId_RoleId]	PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
	CONSTRAINT [FK_NeonUserRole_RoleId]			FOREIGN KEY ([RoleId]) REFERENCES [dbo].[NeonRole] ([UniqueId]) ON DELETE CASCADE,
	CONSTRAINT [FK_NeonUserRole_UserId]			FOREIGN KEY ([UserId]) REFERENCES [dbo].[NeonUsers] ([UserId]),
	CONSTRAINT [FK_NeonUserRole_GuidUserId]		FOREIGN KEY ([GuidUser_Id]) REFERENCES [dbo].[NeonUsers] ([UserId])
);
GO
CREATE NONCLUSTERED INDEX [GuidUserIndex]
	ON [dbo].[NeonUserRole] ([GuidUser_Id] ASC);