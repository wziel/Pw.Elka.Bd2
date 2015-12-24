-- Batch submitted through debugger: SQLQuery12.sql|15|0|C:\Users\Kamil\AppData\Local\Temp\~vs8D6.sql
-- =============================================
-- Author:		kkacper1
-- Create date: 24.12.15
-- Description:	Ile jest w zasobach pozycji o danym issn
-- =============================================
CREATE PROCEDURE IleSztukPoISSN 
	-- Add the parameters for the stored procedure here
	@issn int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*)
	FROM Pozycja INNER JOIN Seria ON Pozycja.id_seria=Seria.id_seria
	WHERE Seria.issn=@issn
END