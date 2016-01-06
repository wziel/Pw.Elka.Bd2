-- =============================================
-- Author:		mmudel
-- Create date: 06.01.2016
-- Description:	Podaje liczbe aktualnie wypozyczonych pozycji dla id dzialu z parametru pierwszego,
--				jesli ten parametr = 0 wypisuje sumaryczna ilosc wypozyczen. Nie korzysta z indeksow
-- =============================================
CREATE PROCEDURE [dbo].[IleWypozyczonychBezIndexow]
	-- Add the parameters for the stored procedure here
	@id_dzial smallint = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @id_dzial=0
		SELECT COUNT(*)
		FROM Pozycja WITH (INDEX(0))
		WHERE Pozycja.wypozyczona=1
	ELSE
		SELECT COUNT(*)
		FROM Pozycja WITH (INDEX(0))
		WHERE Pozycja.id_dzial=@id_dzial
		AND Pozycja.wypozyczona=1
END