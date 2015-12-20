-- =============================================
-- Author:		mmudel
-- Create date: 20.12.2015
-- Description:	Podaje liczbe aktualnie wypozyczonych pozycji dla id dzialu z parametru pierwszego,
--				jesli ten parametr = 0 wypisuje sumaryczna ilosc wypozyczen
-- =============================================
CREATE PROCEDURE [dbo].[IleWypozyczonych] 
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
		FROM Pozycja
		WHERE Pozycja.wypozyczona=1
	ELSE
		SELECT COUNT(*)
		FROM Pozycja
		WHERE Pozycja.id_dzial=@id_dzial
		AND Pozycja.wypozyczona=1
END