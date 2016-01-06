-- =============================================
-- Author:		mmudel
-- Create date: 06.01.2016
-- Description: Wyswietla id rezerwacji oraz nazwe pozycji ktorej rezerwacja jest gotowa do odebrania. Nie korzysta z indexow
-- =============================================
CREATE PROCEDURE JakieRezerwacjeGotoweDoOdebraniaBezIndexow
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Rezerwacja.id_rezerwacja, Pozycja.id_pozycja, Pozycja.nazwa
	FROM Rezerwacja WITH (INDEX(0)) INNER JOIN Pozycja WITH (INDEX(0)) ON Rezerwacja.id_pozycja = Pozycja.id_pozycja
	WHERE Rezerwacja.gotowe_od IS NOT NULL
END