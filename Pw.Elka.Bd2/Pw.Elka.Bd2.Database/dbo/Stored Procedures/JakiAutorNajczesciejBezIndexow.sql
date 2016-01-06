-- =============================================
-- Author:		mmudel
-- Create date: 06.01.2016
-- Description:	Pozycje jakiego autora były najczęściej wypożyczane od... do... Nie korzysta z indexow
-- =============================================
CREATE PROCEDURE [dbo].[JakiAutorNajczesciejBezIndexow]
	-- Add the parameters for the stored procedure here
	@data_poczatek date , 
	@data_koniec date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id_autor, nazwiska, imiona
	FROM autor WITH (INDEX(0))


END