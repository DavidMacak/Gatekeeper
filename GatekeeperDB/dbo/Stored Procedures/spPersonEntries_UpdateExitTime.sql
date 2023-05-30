CREATE PROCEDURE [dbo].[spPersonEntries_UpdateExitTime]
	@entryId INT,
	@exitTime DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.PersonEntries 
	SET ExitTime = @exitTime
	WHERE Id = @entryId

END
