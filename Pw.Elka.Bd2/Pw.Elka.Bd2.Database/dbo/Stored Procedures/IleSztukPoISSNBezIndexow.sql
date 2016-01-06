-- =============================================
-- Author:		mmudel
-- Create date: 06.01.2016
-- Description:	Ile jest w zasobach pozycji o danym issn. Nie korzysta z indeksow
-- =============================================
CREATE PROCEDURE [dbo].[IleSztukPoISSNBezIndexow] 
	-- Add the parameters for the stored procedure here
	@issn int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*)
	FROM Pozycja WITH (INDEX(0))
	INNER JOIN Seria WITH (INDEX(0))
	ON Pozycja.id_seria=Seria.id_seria
	WHERE Seria.issn=@issn
END