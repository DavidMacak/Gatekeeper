CREATE PROCEDURE [dbo].[spPersonEntries_Create]
	@personId int,
	@entryTime DATETIME
AS
BEGIN
SET NOCOUNT ON

	INSERT INTO dbo.PersonEntries (PersonId, EntryTime)
	VALUES (@personId, @entryTime)

END
