CREATE PROCEDURE [dbo].[spVehicleEntries_Create]
	@vehicleId INT,
	@personId INT,
	@entryTime DATETIME
AS
BEGIN
SET NOCOUNT ON;

	INSERT INTO dbo.VehicleEntries (VehicleId, PersonId, EnterTime)
	VALUES (@vehicleId, @personId, @entryTime)


END
