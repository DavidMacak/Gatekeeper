CREATE TABLE [dbo].[PersonEntries]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PersonId] INT NOT NULL,
	[EntryPurposeId] INT NOT NULL,
	[EntryTime] DATETIME NOT NULL,
	[ExitTime] DATETIME
)
