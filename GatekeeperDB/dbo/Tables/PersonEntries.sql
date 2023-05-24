﻿CREATE TABLE [dbo].[PersonEntries]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PersonId] INT NOT NULL,
	[EntryPurposeId] INT NOT NULL,
	[EntryTime] DATETIME NOT NULL,
	[ExitTime] DATETIME, 
    CONSTRAINT [FK_PersonEntries_Persons] FOREIGN KEY (PersonId) REFERENCES Persons(Id), 
    CONSTRAINT [FK_PersonEntries_EntryPurpose] FOREIGN KEY (EntryPurposeId) REFERENCES EntryPurpose(Id)
)
