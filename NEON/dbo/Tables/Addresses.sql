CREATE TABLE [dbo].[Addresses]
(
	[Id]				BIGINT IDENTITY (1,1) CONSTRAINT [PK_Addresses] PRIMARY KEY NOT NULL,
	[UniqueId]			UNIQUEIDENTIFIER CONSTRAINT [DF_Addresses_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[CountryId]			BIGINT NOT NULL,
	[PrimaryAddress]	NVARCHAR (255) NULL,
	[SecondAddress]		NVARCHAR (255) NULL,
	[City]				NVARCHAR (255) NULL,
	[StateId]			BIGINT NULL,
	[Province]			NVARCHAR (255) NULL,
	[PostalCode]		NVARCHAR (500) NULL,
	[LastUpdate]		DATETIME2 CONSTRAINT [DF_Addresses_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]		DATETIME2 CONSTRAINT [DF_Addresses_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_Addresses_UniqueId]	UNIQUE ([UniqueId]),
	CONSTRAINT [FK_Addresses_CountryId] FOREIGN KEY ([CountryId])	REFERENCES [dbo].[Countries] ([Id]),
	CONSTRAINT [FK_Addresses_StateId]	FOREIGN KEY ([StateId])		REFERENCES [dbo].[State] ([Id])
)
