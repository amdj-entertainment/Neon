CREATE TABLE [dbo].[Requests]
(
	[Id]			BIGINT IDENTITY (1,1)	CONSTRAINT [PK_Requests]			PRIMARY KEY NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER		CONSTRAINT [DF_Request_UniqueId]	DEFAULT (NEWID()) NOT NULL,
	[EventId]		BIGINT NOT NULL,
	[TrackId]		BIGINT NOT NULL,
	[WasPlayed]		BIT						CONSTRAINT [DF_Requests_WasPlayed]	DEFAULT (0) NOT NULL,
	[Amount]		BIGINT					CONSTRAINT [DF_Requests_Amount]		DEFAULT (0) NOT NULL,
	[Archived]		BIT						CONSTRAINT [DF_Requests_Archived]	DEFAULT (0) NOT NULL,
	[LastUpdate]	DATETIME2				CONSTRAINT [DF_Requests_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]	DATETIME2				CONSTRAINT [DF_Requests_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_Requests_UniqueId]	UNIQUE ([UniqueId]),
	CONSTRAINT [FK_Requests_EventId]	FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([Id]),
	CONSTRAINT [FK_Requests_TrackId]	FOREIGN KEY ([TrackId]) REFERENCES [dbo].[Tracks] ([Id])
)
