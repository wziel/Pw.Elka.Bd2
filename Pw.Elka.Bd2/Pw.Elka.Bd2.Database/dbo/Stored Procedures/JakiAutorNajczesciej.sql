-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	Pozycje jakiego autora były najczęściej wypożyczane od... do...
-- =============================================
CREATE PROCEDURE [dbo].[JakiAutorNajczesciej] 
	-- Add the parameters for the stored procedure here
	@data_poczatek date , 
	@data_koniec date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET ROWCOUNT 10
	SELECT COUNT(*) as liczba_wypozyczen, Autor.id_autor, Autor.imiona, Autor.nazwiska
	from Pozycja
	LEFT JOIN Pozycja_autor ON Pozycja_autor.id_pozycja = Pozycja.id_pozycja 
	LEFT JOIN Autor ON Pozycja_autor.id_autor = Autor.id_autor
	LEFT JOIN Rewers ON Rewers.id_pozycja=Pozycja.id_pozycja
	WHERE Rewers.data_od > @data_poczatek
	AND Rewers.data_do < @data_koniec
	GROUP BY Autor.id_autor, Autor.imiona, Autor.nazwiska
	ORDER BY liczba_wypozyczen DESC

END