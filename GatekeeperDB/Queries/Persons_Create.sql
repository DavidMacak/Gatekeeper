
AS
BEGIN
SET NOCOUNT ON

DECLARE	@firstName NVARCHAR(50) = 'Dominik',
	@lastName NVARCHAR(50) = 'Mrázek'

	IF NOT EXISTS (SELECT 1 FROM dbo.Persons WHERE FirstName = @firstName AND LastName = @lastName)
		BEGIN
			INSERT INTO dbo.Persons (FirstName,LastName)
			VALUES (@firstName, @lastName)
		END
END

