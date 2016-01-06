CREATE TABLE [dbo].[Pozycja_gatunek] (
    [id_pozycja] INT      NOT NULL,
    [id_gatunek] SMALLINT NOT NULL,
    CONSTRAINT [PK_Pozycja_gatunek] PRIMARY KEY CLUSTERED ([id_pozycja] ASC, [id_gatunek] ASC),
    CONSTRAINT [FK_Pozycja_gatunek_Gatunek] FOREIGN KEY ([id_gatunek]) REFERENCES [dbo].[Gatunek] ([id_gatunek]),
    CONSTRAINT [FK_Pozycja_gatunek_Pozycja] FOREIGN KEY ([id_pozycja]) REFERENCES [dbo].[Pozycja] ([id_pozycja])
);


GO
ALTER TABLE [dbo].[Pozycja_gatunek] NOCHECK CONSTRAINT [FK_Pozycja_gatunek_Pozycja];





