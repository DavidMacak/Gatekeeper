CREATE PROCEDURE [dbo].[spPersons_Create]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON
	IF NOT EXISTS (SELECT 1 FROM dbo.Persons WHERE FirstName = @firstName AND LastName = @lastName)
		BEGIN
			INSERT INTO dbo.Persons (FirstName,LastName)
			VALUES (@firstName, @lastName)
		END
END
