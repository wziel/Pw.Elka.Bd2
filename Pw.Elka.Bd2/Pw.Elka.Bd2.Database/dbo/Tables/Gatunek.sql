CREATE TABLE [dbo].[Gatunek] (
    [id_gatunek] SMALLINT     NOT NULL IDENTITY,
    [nazwa]      VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Gatunek] PRIMARY KEY CLUSTERED ([id_gatunek] ASC)
);



