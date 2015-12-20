-- =============================================
-- Author:		mmudel
-- Create date: 20.12.2015
-- Description: Wyswietla id rezerwacji oraz nazwe pozycji ktorej rezerwacja jest gotowa do odebrania
-- =============================================
CREATE PROCEDURE [dbo].[JakieRezerwacjeGotoweDoOdebrania] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Rezerwacja.id_rezerwacja, Pozycja.id_pozycja, Pozycja.nazwa
	FROM Rezerwacja INNER JOIN Pozycja ON Rezerwacja.id_pozycja = Pozycja.id_pozycja
	WHERE Rezerwacja.gotowe_od IS NOT NULL
END