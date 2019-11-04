CREATE TABLE [dbo].[Users]
(
	[Id]					BIGINT IDENTITY (1,1) CONSTRAINT [PK_Users] PRIMARY KEY NOT NULL,
	[UniqueId]				UNIQUEIDENTIFIER CONSTRAINT [DF_Users_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[UserName]				NVARCHAR (255) NOT NULL,
	[Email]					NVARCHAR (150) NOT NULL,
	[EmailConfirmed]		BIT CONSTRAINT [DF_Users_EmailConfirmed] DEFAULT (0) NOT NULL,
	[PasswordHash]			NVARCHAR (MAX) NOT NULL,
	[PhoneNumber]			NVARCHAR (25) NULL,
	[PhoneNumberConfirmed]	BIT CONSTRAINT [DF_Users_PhoneNumberConfirmed] DEFAULT (0) NOT NULL,
	[TwoFactorEnabled]		BIT CONSTRAINT [DF_Users_TwoFactorEnabled] DEFAULT (0) NOT NULL,
	[LockoutEnabled]		BIT CONSTRAINT [DF_Users_LockoutEnabled] DEFAULT (1) NOT NULL,
	[LockoutEndDateUtc]		DATETIME2 NULL,
	[SecurityStamp]			UNIQUEIDENTIFIER NOT NULL,
	[AccessFailedCount]		INT CONSTRAINT [DF_Users_AccessFailedCount] NOT NULL,
	[LastUpdate]			DATETIME2 CONSTRAINT [DF_Users_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]			DATETIME2 CONSTRAINT [DF_Users_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_Users_UniqueId]		UNIQUE ([UniqueId])
)
