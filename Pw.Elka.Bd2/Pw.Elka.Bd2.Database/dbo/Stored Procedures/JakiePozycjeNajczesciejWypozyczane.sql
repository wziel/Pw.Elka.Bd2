-- =============================================
-- Author:		mmudel
-- Create date: 20.12.2015
-- Description:	Wyswietla pozycje ktore byly najczesciej wypozyczane w okreslonym przez parametry okresie
-- =============================================
CREATE PROCEDURE [dbo].[JakiePozycjeNajczesciejWypozyczane] 
	-- Add the parameters for the stored procedure here
	@od date, 
	@do date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT Pozycja.id_pozycja, Pozycja.nazwa, COUNT(*) AS liczba_wypozyczen
	FROM Pozycja LEFT JOIN Rewers ON Rewers.id_pozycja=Pozycja.id_pozycja
	WHERE Rewers.data_od > @od
	AND Rewers.data_do < @do
	GROUP BY Pozycja.id_pozycja, Pozycja.nazwa

END