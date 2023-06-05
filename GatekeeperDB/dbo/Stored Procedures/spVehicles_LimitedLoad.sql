CREATE PROCEDURE [dbo].[spVehicles_LimitedLoad]
	@vehicleCount INT
AS
BEGIN
SET NOCOUNT ON;

	SELECT TOP (@vehicleCount) [Id], [LicensePlate]
	FROM dbo.Vehicles

END