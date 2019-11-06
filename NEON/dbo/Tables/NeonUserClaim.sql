CREATE TABLE [dbo].[NeonUserClaim]
(
	[Id]			BIGINT IDENTITY (1,1) NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER		CONSTRAINT [DF_NeonUserClaim_UniqueId]	DEFAULT (NEWID()) NOT NULL,
	[UserId]		UNIQUEIDENTIFIER NOT NULL,
	[ClaimType]		NVARCHAR (MAX) NULL,
	[ClaimValue]	NVARCHAR (MAX) NULL,
	[GuidUser_Id]	UNIQUEIDENTIFIER NULL,
	[CreateDate]	DATETIME2				CONSTRAINT [DF_NeonUserClaim_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [PK_NeonUserClaim]				PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [UK_NeonUserClaim_UniqueId]		UNIQUE ([UniqueId]),
	CONSTRAINT [FK_NeonUserClaim_GuidUser_Id]	FOREIGN KEY ([GuidUser_Id]) REFERENCES [dbo].[NeonUsers] ([UserId])
)
GO
CREATE NONCLUSTERED INDEX [GuidUserIndex]
	ON [dbo].[NeonUserClaim] ([GuidUser_Id] ASC);
