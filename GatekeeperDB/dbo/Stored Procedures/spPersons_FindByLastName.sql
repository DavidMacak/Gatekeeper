CREATE PROCEDURE [dbo].[spPersons_FindByLastName]
	@lastName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON
		SELECT [Id], [FirstName], [LastName] FROM dbo.Persons 
		WHERE LastName = @lastName;
END
