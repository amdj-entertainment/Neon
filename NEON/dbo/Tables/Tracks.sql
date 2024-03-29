﻿CREATE TABLE [dbo].[Tracks]
(
	[Id]			BIGINT IDENTITY (1,1) CONSTRAINT [PK_Tracks] PRIMARY KEY NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER CONSTRAINT [DF_Tracks_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[SpotifyId]		BIGINT NULL,
	[Title]			NVARCHAR (256) NOT NULL,
	[Explicit]		BIT NOT NULL,
	[LastUpdate]	DATETIME2 CONSTRAINT [DF_Tracks_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]	DATETIME2 CONSTRAINT [DF_Tracks_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_Tracks_UniqueId]		UNIQUE ([UniqueId]),
	CONSTRAINT [FK_Tracks_SpotifyId]	FOREIGN KEY ([SpotifyId]) REFERENCES [dbo].[Spotify] ([Id])
)
