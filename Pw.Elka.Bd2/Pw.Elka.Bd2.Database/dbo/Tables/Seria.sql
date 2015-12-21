CREATE TABLE [dbo].[Seria] (
    [id_seria] INT          NOT NULL IDENTITY,
    [issn]     INT          NULL,
    [nazwa]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Seria] PRIMARY KEY CLUSTERED ([id_seria] ASC)
);






GO
CREATE NONCLUSTERED INDEX [INDEX_Seria_issn]
    ON [dbo].[Seria]([issn] ASC);

