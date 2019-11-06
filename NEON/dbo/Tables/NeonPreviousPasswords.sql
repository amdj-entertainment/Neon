CREATE TABLE [dbo].[NeonPreviousPasswords]
(
	[Id]			BIGINT IDENTITY (1,1)	CONSTRAINT [PK_NeonPreviousPasswords]			PRIMARY KEY NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER		CONSTRAINT [DF_NeonPreviousPasswords_UniqueId]	DEFAULT (NEWID()) NOT NULL,
	[UserId]		UNIQUEIDENTIFIER		NOT NULL,
	[PasswordHash]	NVARCHAR (128)			NOT NULL,
	[CreateDate]	DATETIME2				CONSTRAINT [DF_NeonPreviousPasswords_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_NeonPreviousPasswords_UniqueId]	UNIQUE ([UniqueId]),
	CONSTRAINT [FK_NeonPreviousPasswords_UserId]	FOREIGN KEY ([UserId]) REFERENCES [dbo].[NeonUsers] ([UserId])
)
