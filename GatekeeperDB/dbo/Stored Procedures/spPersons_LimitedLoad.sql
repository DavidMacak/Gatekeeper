CREATE PROCEDURE [dbo].[spPersons_LimitedLoad]
	@personsCount INT
AS
BEGIN
SET NOCOUNT ON;

	SELECT TOP (@personsCount) [Id], [FirstName], [LastName]
	FROM dbo.Persons

END
