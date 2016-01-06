-- =============================================
-- Author:		mmudel
-- Create date: 06.01.2016
-- Description:	Kiedy pozycja bedzie dostepna. Nie korzysta z indexow
-- =============================================
CREATE PROCEDURE KiedyDostepnaBezIndexow 
	-- Add the parameters for the stored procedure here
	@id_pozycja int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Pozycja.nazwa, Pozycja.dostepna_od 
	FROM Pozycja WITH (INDEX(0))
	WHERE Pozycja.id_pozycja = @id_pozycja 
END