CREATE TABLE [dbo].[Pozycja_autor] (
    [id_pozycja] INT NOT NULL,
    [id_autor]   INT NOT NULL,
    CONSTRAINT [PK_Pozycja_autor] PRIMARY KEY CLUSTERED ([id_pozycja] ASC, [id_autor] ASC),
    CONSTRAINT [FK_Pozycja_autor_ToTable] FOREIGN KEY ([id_pozycja]) REFERENCES [dbo].[Pozycja] ([id_pozycja]),
    CONSTRAINT [FK_Pozycja_autor_ToTable_1] FOREIGN KEY ([id_autor]) REFERENCES [dbo].[Autor] ([id_autor])
);


GO
ALTER TABLE [dbo].[Pozycja_autor] NOCHECK CONSTRAINT [FK_Pozycja_autor_ToTable];





