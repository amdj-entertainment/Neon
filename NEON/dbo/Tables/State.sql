﻿CREATE TABLE [dbo].[State]
(
	[Id]			BIGINT IDENTITY (1,1) CONSTRAINT [PK_State] PRIMARY KEY NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER CONSTRAINT [DF_State_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[Name]			NVARCHAR (255) NOT NULL,
	[LastUpdate]	DATETIME2 CONSTRAINT [DF_State_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]	DATETIME2 CONSTRAINT [DF_State_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_State_UniqueId] UNIQUE ([UniqueId])
)
