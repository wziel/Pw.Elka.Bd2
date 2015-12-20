CREATE TABLE [dbo].[Pozycja_autor] (
    [id_pozycja] INT NOT NULL,
    [id_autor]   INT NOT NULL,
    CONSTRAINT [PK_Pozycja_autor] PRIMARY KEY CLUSTERED ([id_pozycja] ASC, [id_autor] ASC)
);



