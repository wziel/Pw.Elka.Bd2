-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	Pozycje jakiego autora były najczęściej wypożyczane od... do...
-- =============================================
CREATE PROCEDURE Jaki_autor_najczesciej 
	-- Add the parameters for the stored procedure here
	@data_poczatek date , 
	@data_koniec date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id_autor, nazwiska, imiona  from autor


END