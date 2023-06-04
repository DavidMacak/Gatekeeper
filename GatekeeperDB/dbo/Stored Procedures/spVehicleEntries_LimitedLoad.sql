CREATE PROCEDURE [dbo].[spVehicleEntries_LimitedLoad]
	@entriesCount INT
AS
BEGIN
SET NOCOUNT ON;

	SELECT TOP (@entriesCount) e.Id, e.VehicleId, v.LicensePlate, e.PersonId, p.FirstName, p.LastName, e.EnterTime, e.ExitTime
	FROM dbo.VehicleEntries e
	INNER JOIN dbo.Vehicles v ON e.VehicleId = v.Id
	INNER JOIN dbo.Persons p ON e.PersonId = p.Id

END
