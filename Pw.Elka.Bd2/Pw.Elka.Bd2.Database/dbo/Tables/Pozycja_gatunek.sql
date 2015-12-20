CREATE TABLE [dbo].[Pozycja_gatunek] (
    [id_pozycja] INT      NOT NULL,
    [id_gatunek] SMALLINT NOT NULL,
    CONSTRAINT [PK_Pozycja_gatunek] PRIMARY KEY CLUSTERED ([id_pozycja] ASC, [id_gatunek] ASC), 
    CONSTRAINT [FK_Pozycja_gatunek_Pozycja] FOREIGN KEY ([id_pozycja]) REFERENCES [Pozycja]([id_pozycja]), 
    CONSTRAINT [FK_Pozycja_gatunek_Gatunek] FOREIGN KEY ([id_gatunek]) REFERENCES [Gatunek]([id_gatunek])
);



