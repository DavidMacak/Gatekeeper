CREATE PROCEDURE [dbo].[spVehicles_LimitedLoad]
	@entriesCount INT
AS
BEGIN
SET NOCOUNT ON;

	SELECT TOP (@entriesCount) [Id], [LicensePlate]
	FROM dbo.Vehicles

END