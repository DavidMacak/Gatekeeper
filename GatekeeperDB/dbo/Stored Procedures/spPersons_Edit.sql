CREATE PROCEDURE [dbo].[spPersons_Edit]
	@id int,
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.Persons
	SET FirstName = @firstName, LastName = @lastName
	WHERE Id = @id

END
