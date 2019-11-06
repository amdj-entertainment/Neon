CREATE TABLE [dbo].[NeonUsers]
(
	[UserId]				UNIQUEIDENTIFIER CONSTRAINT [PK_NeonUsers] PRIMARY KEY CLUSTERED NOT NULL,
	[UserName]				NVARCHAR (255) NOT NULL,
	[Email]					NVARCHAR (150) NOT NULL,
	[EmailConfirmed]		BIT CONSTRAINT [DF_NeonUsers_EmailConfirmed] DEFAULT (0) NOT NULL,
	[PasswordHash]			NVARCHAR (MAX) NOT NULL,
	[PhoneNumber]			NVARCHAR (25) NULL,
	[PhoneNumberConfirmed]	BIT CONSTRAINT [DF_NeonUsers_PhoneNumberConfirmed] DEFAULT (0) NOT NULL,
	[TwoFactorEnabled]		BIT CONSTRAINT [DF_NeonUsers_TwoFactorEnabled] DEFAULT (0) NOT NULL,
	[LockoutEnabled]		BIT CONSTRAINT [DF_NeonUsers_LockoutEnabled] DEFAULT (1) NOT NULL,
	[LockoutEndDateUtc]		DATETIME2 NULL,
	[SecurityStamp]			NVARCHAR(MAX) NOT NULL,
	[AccessFailedCount]		INT CONSTRAINT [DF_NeonUsers_AccessFailedCount] NOT NULL,
	[Discriminator]			NVARCHAR (128) NOT NULL,
	[LastUpdate]			DATETIME2 CONSTRAINT [DF_NeonUsers_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]			DATETIME2 CONSTRAINT [DF_NeonUsers_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_NeonUsers_UserId]		UNIQUE ([UserId])
)
