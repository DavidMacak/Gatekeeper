CREATE TABLE [dbo].[VehicleEntries]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[VehicleId] INT NOT NULL,
	[PersonId] INT NOT NULL,
	[EntryPurposeId] INT NOT NULL,
	[EnterTime] DATETIME NOT NULL,
	[ExitTime] DATETIME
)
