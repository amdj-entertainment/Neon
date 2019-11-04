﻿CREATE TABLE [dbo].[Roles]
(
	[Id]			BIGINT IDENTITY (1,1) CONSTRAINT [PK_Roles] PRIMARY KEY NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER CONSTRAINT [DF_Roles_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[Name]			NVARCHAR(255) NOT NULL,
	[LastUpdated]	DATETIME2 CONSTRAINT [DF_Roles_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]	DATETIME2 CONSTRAINT [DF_Roles_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_Roles_UniqueId] UNIQUE ([UniqueId]),
)
