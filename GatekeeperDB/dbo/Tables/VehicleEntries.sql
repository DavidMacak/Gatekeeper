CREATE TABLE [dbo].[VehicleEntries]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[VehicleId] INT NOT NULL,
	[PersonId] INT NOT NULL,
	[EnterTime] DATETIME NOT NULL,
	[ExitTime] DATETIME, 
    CONSTRAINT [FK_VehicleEntries_Persons] FOREIGN KEY (PersonId) REFERENCES [dbo].[Persons](Id), 
    CONSTRAINT [FK_VehicleEntries_Vehicles] FOREIGN KEY (VehicleId) REFERENCES [dbo].[Vehicles](Id)
)
