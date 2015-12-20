CREATE TABLE [dbo].[Seria] (
    [id_seria] INT          NOT NULL,
    [issn]     INT          NULL,
    [nazwa]    VARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Seria] PRIMARY KEY CLUSTERED ([id_seria] ASC)
);






GO
CREATE NONCLUSTERED INDEX [INDEX_Seria_issn]
    ON [dbo].[Seria]([issn] ASC);

