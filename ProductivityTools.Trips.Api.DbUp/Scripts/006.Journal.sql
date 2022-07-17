	CREATE TABLE [t].[Journal](
	[JournalId] [int] IDENTITY(1,1) NOT NULL,
	[TripId] [int] NOT NULL,
	[Notes] VARCHAR(MAX)
	CONSTRAINT PK_JournalId PRIMARY KEY ([JournalId]),
	CONSTRAINT FK_Journal_Trip FOREIGN KEY (TripId) REFERENCES [t].[Trip],
	)