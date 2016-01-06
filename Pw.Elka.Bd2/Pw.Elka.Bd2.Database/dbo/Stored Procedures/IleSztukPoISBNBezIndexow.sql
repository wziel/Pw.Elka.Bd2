-- =============================================
-- Author:		mmudel
-- Create date: 06.01.2016
-- Description:	Ile jest pozycji w zasobach o danym ISBN. Nie korzysta z indexow
-- =============================================
CREATE PROCEDURE [dbo].[IleSztukPoISBNBezIndexow]
	-- Add the parameters for the stored procedure here
	@isbn bigint 
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) 
	FROM  Pozycja WITH(INDEX(0))
	WHERE Pozycja.isbn=@isbn 
END