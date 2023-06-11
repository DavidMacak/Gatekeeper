CREATE PROCEDURE [dbo].[spVehicleEntries_EditEntry]
	@entryId INT,
	@personId INT,
	@vehicleId INT,
	@entryTime DATETIME,
	@exitTime DATETIME
AS
BEGIN
SET NOCOUNT ON;

	UPDATE dbo.VehicleEntries
	SET PersonId = @personId, VehicleId = @vehicleId, EnterTime = @entryTime, ExitTime = @exitTime
	WHERE Id = @entryId

END
