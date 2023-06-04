CREATE PROCEDURE [dbo].[spVehicles_Create]
	@licensePlate NVARCHAR(10)
AS
BEGIN
SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM dbo.Vehicles WHERE LicensePlate = @licensePlate)
		BEGIN
		INSERT INTO dbo.Vehicles (LicensePlate)
		VALUES (@licensePlate)
		END
	
END
