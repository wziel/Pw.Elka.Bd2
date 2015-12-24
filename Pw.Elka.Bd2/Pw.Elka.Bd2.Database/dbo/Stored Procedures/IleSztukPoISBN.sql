-- Batch submitted through debugger: SQLQuery4.sql|15|0|C:\Users\Kamil\AppData\Local\Temp\~vsC158.sql
-- =============================================
-- Author:		kkacper1
-- Create date: 24.12.15
-- Description:	Ile jest pozycji w zasobach o danym ISBN
-- =============================================
CREATE PROCEDURE [dbo].[IleSztukPoISBN] 
	-- Add the parameters for the stored procedure here
	@isbn bigint 
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) 
	FROM  Pozycja
	WHERE Pozycja.isbn=@isbn 
END