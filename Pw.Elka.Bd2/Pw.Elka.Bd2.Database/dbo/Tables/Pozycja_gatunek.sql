CREATE TABLE [dbo].[Pozycja_gatunek] (
    [id_pozycja] INT      NOT NULL,
    [id_gatunek] SMALLINT NOT NULL,
    CONSTRAINT [PK_Pozycja_gatunek] PRIMARY KEY CLUSTERED ([id_pozycja] ASC, [id_gatunek] ASC)
);



