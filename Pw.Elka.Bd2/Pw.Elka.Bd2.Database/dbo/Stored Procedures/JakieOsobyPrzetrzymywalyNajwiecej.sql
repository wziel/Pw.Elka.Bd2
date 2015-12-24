-- Batch submitted through debugger: SQLQuery13.sql|15|0|C:\Users\Kamil\AppData\Local\Temp\~vsB912.sql
-- =============================================
-- Author:		kkacper1
-- Create date: 24.12.15
-- Description:	jakie osoby przetrzymywaly pozycje najwieksza liczbe dni od ... do
-- =============================================
CREATE PROCEDURE JakieOsobyPrzetrzymywalyNajwiecej 
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
			FROM Rewers
			WHERE Rewers.data_zwrotu > @od AND Rewers.data_do < @do
		) AS PotencjalniDluznicy
		WHERE PotencjalniDluznicy.data_zwrotu > PotencjalniDluznicy.data_do 
	) AS Dluznicy INNER JOIN Klient ON Klient.id_klient=Dluznicy.id_klient
	GROUP BY Klient.id_klient , Klient.imiona , Klient.nazwiska , Dluznicy.Przetrzymanie
	ORDER BY Dluznicy.Przetrzymanie DESC
END