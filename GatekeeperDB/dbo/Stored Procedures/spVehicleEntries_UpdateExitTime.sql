CREATE PROCEDURE [dbo].[spVehicleEntries_UpdateExitTime]
	@entryId INT,
	@exitTime DATETIME
AS
BEGIN
SET NOCOUNT ON;

	UPDATE dbo.VehicleEntries
	SET ExitTime = @exitTime
	WHERE Id = @entryId

END
