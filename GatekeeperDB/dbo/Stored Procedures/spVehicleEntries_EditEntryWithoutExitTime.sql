CREATE PROCEDURE [dbo].[spVehicleEntries_EditEntryWithoutExitTime]
	@entryId INT,
	@personId INT,
	@vehicleId INT,
	@entryTime DATETIME
AS
BEGIN
SET NOCOUNT ON;

	UPDATE dbo.VehicleEntries
	SET PersonId = @personId, VehicleId = @vehicleId, EnterTime = @entryTime
	WHERE Id = @entryId

END
