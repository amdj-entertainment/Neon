CREATE TABLE [dbo].[NeonUserLogin]
(
	[LoginProvider] NVARCHAR (128) NOT NULL,
	[ProviderKey]	NVARCHAR (128) NOT NULL,
	[UserId]		UNIQUEIDENTIFIER NOT NULL,
	[GuidUser_Id]	UNIQUEIDENTIFIER NOT NULL,
	[CreateDate]	DATETIME2 CONSTRAINT [DF_NeonUserLogin_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [PK_NeonUserLogin] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [UserId] ASC),
	CONSTRAINT [FK_NeonUserLogin_GuidUser_Id] FOREIGN KEY ([GuidUser_Id]) REFERENCES [dbo].[NeonUsers] ([UserId])
);
GO
CREATE NONCLUSTERED INDEX [GuidUserInex]
	ON [dbo].[NeonUserLogin] ([GuidUser_Id] ASC);
