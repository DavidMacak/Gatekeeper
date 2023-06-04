CREATE PROCEDURE [dbo].[spVehicles_FindByLicensePlate]
	@licensePlate NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;

	SELECT TOP 1 [Id], [LicensePlate]
	FROM dbo.Vehicles
	WHERE LicensePlate = @licensePlate

END
