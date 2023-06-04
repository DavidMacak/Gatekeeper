CREATE PROCEDURE [dbo].[spVehicles_Edit]
	@vehicleId INT,
	@licensePlate NVARCHAR(10)
AS
BEGIN
SET NOCOUNT ON;

	UPDATE dbo.Vehicles
	SET LicensePlate = @licensePlate
	WHERE Id = @vehicleId

END