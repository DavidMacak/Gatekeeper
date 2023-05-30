CREATE PROCEDURE [dbo].[spPersonEntries_LimitedLoad]
	@entriesCount INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP (@entriesCount) e.Id, e.PersonId, e.EntryTime, e.ExitTime,
				p.FirstName, p.LastName
	FROM dbo.PersonEntries e
		INNER JOIN dbo.Persons p ON e.PersonId = p.Id
END
