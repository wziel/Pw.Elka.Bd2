-- =============================================
-- Author:		mmudel
-- Create date: 06.01.2016
-- Description:	Wyswietla pozycje ktore byly najczesciej wypozyczane w okreslonym przez parametry okresie. Nie korzysta z indexow
-- =============================================
CREATE PROCEDURE [dbo].[JakiePozycjeNajczesciejWypozyczaneBezIndexow]
	-- Add the parameters for the stored procedure here
	@od date, 
	@do date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET ROWCOUNT 1
	SELECT Pozycja.id_pozycja, Pozycja.nazwa, COUNT(*) AS liczba_wypozyczen
	FROM Pozycja WITH (INDEX(0)) LEFT JOIN Rewers WITH (INDEX(0)) ON Rewers.id_pozycja=Pozycja.id_pozycja
	WHERE Rewers.data_od > @od
	AND Rewers.data_do < @do
	GROUP BY Pozycja.id_pozycja, Pozycja.nazwa
	ORDER BY liczba_wypozyczen DESC
END