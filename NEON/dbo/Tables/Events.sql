CREATE TABLE [dbo].[Events]
(
	[Id]				BIGINT IDENTITY (1,1) CONSTRAINT [PK_Events] PRIMARY KEY NOT NULL,
	[UniqueId]			UNIQUEIDENTIFIER CONSTRAINT [DF_Events_UniqueId] DEFAULT (NEWID()) NOT NULL,
	[WorkspaceId]		BIGINT NOT NULL,
	[Title]				NVARCHAR (255) NOT NULL,
	[Description]		NVARCHAR (4000) NOT NULL, 
	[StatusId]			BIGINT NOT NULL,
	[AddressId]			BIGINT NULL,
	[VenueId]			BIGINT NULL,
	[StartDate]			DATETIME2 NOT NULL,
	[EndDate]			DATETIME2 NOT NULL,
	[RequestOpenDate]	DATETIME2 NOT NULL,
	[RequestCloseDate]	DATETIME2 NOT NULL,
	[LastUpdate]		DATETIME2 CONSTRAINT [DF_Events_LastUpdate] DEFAULT (GETDATE()) NOT NULL,
	[CreateDate]		DATETIME2 CONSTRAINT [DF_Events_CreateDate] DEFAULT (GETDATE()) NOT NULL,
	CONSTRAINT [UK_Events_UniqueId]		UNIQUE ([UniqueId]),
	CONSTRAINT [FK_Events_WorkspaceId]	FOREIGN KEY ([WorkspaceId]) REFERENCES [dbo].[Workspaces] ([Id]),
	CONSTRAINT [FK_Events_StatusId]		FOREIGN KEY ([StatusId])	REFERENCES [dbo].[EventStatus] ([Id]),
	CONSTRAINT [FK_Events_AddressId]	FOREIGN KEY ([AddressId])	REFERENCES [dbo].[Addresses] ([Id]),
	CONSTRAINT [FK_Events_VenueId]		FOREIGN KEY ([VenueId])		REFERENCES [dbo].[Venues] ([Id])
)
