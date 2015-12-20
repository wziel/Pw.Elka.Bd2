-- =============================================
-- Author:		Kiedy_dostepna
-- Create date: 
-- Description:	Kiedy pozycja bedzie dostepna
-- =============================================
CREATE PROCEDURE [dbo].[Kiedy_dostepna] 
	-- Add the parameters for the stored procedure here
	@id_pozycja smallint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Pozycja.dostepna_od from Pozycja where Pozycja.id_pozycja = @id_pozycja 
END