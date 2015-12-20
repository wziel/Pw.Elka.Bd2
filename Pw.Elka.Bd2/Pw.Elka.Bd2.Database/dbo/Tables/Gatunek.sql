CREATE TABLE [dbo].[Gatunek] (
    [id_gatunek] SMALLINT     NOT NULL,
    [nazwa]      VARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Gatunek] PRIMARY KEY CLUSTERED ([id_gatunek] ASC)
);



