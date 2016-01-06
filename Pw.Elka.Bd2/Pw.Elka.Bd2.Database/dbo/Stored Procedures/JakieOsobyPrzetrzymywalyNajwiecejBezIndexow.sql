-- =============================================
-- Author:		mmudel
-- Create date: 06.01.2016
-- Description:	jakie osoby przetrzymywaly pozycje najwieksza liczbe dni od ... do. Nie korzysta z indexow
-- =============================================
CREATE PROCEDURE [dbo].[JakieOsobyPrzetrzymywalyNajwiecejBezIndexow] 
	-- Add the parameters for the stored procedure here
	@od date  ,
	@do date  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET ROWCOUNT 10
	SELECT Klient.id_klient , Klient.imiona , Klient.nazwiska , SUM( Dluznicy.Przetrzymanie ) AS Suma_przetrzymanych_dni
	FROM 
	(
		SELECT * , DATEDIFF( day , PotencjalniDluznicy.data_do , PotencjalniDluznicy.data_zwrotu ) AS Przetrzymanie
		FROM 
		(
			SELECT * 
			FROM Rewers WITH (INDEX(0))
			WHERE Rewers.data_zwrotu > @od AND Rewers.data_do < @do
		) AS PotencjalniDluznicy
		WHERE PotencjalniDluznicy.data_zwrotu > PotencjalniDluznicy.data_do 
	) AS Dluznicy INNER JOIN Klient WITH (INDEX(0)) ON Klient.id_klient=Dluznicy.id_klient
	GROUP BY Klient.id_klient , Klient.imiona , Klient.nazwiska , Dluznicy.Przetrzymanie
	ORDER BY Dluznicy.Przetrzymanie DESC
END