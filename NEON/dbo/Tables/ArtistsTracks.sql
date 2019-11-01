CREATE TABLE [dbo].[ArtistsTracks]
(
	[Id]			BIGINT IDENTITY (1,1) CONSTRAINT [PK_ArtistsTracks] PRIMARY KEY NOT NULL,
	[UniqueId]		UNIQUEIDENTIFIER CONSTRAINT [DF_ArtistsTracks_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[ArtistId]		BIGINT NOT NULL,
	[TrackId]		BIGINT NOT NULL,
	[LastUpdate]	DATETIME2 CONSTRAINT [DF_ArtistsTracks_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]	DATETIME2 CONSTRAINT [DF_ArtistsTracks_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_ArtistsTracks_UniqueId] UNIQUE ([UniqueId]),
	CONSTRAINT [FK_ArtistsTracks_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artists] ([Id])
)
