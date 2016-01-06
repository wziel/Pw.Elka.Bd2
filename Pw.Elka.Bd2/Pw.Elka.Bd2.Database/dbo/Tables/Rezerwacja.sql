CREATE TABLE [dbo].[Rezerwacja] (
    [id_rezerwacja]   INT  IDENTITY (1, 1) NOT NULL,
    [data_rezerwacji] DATE NOT NULL,
    [gotowe_od]       DATE NULL,
    [id_pozycja]      INT  NOT NULL,
    [id_klient]       INT  NOT NULL,
    CONSTRAINT [PK_Rezerwacja] PRIMARY KEY CLUSTERED ([id_rezerwacja] ASC),
    CONSTRAINT [FK_Rezerwacja_Klient] FOREIGN KEY ([id_klient]) REFERENCES [dbo].[Klient] ([id_klient]),
    CONSTRAINT [FK_Rezerwacja_Pozycja] FOREIGN KEY ([id_pozycja]) REFERENCES [dbo].[Pozycja] ([id_pozycja])
);


GO
ALTER TABLE [dbo].[Rezerwacja] NOCHECK CONSTRAINT [FK_Rezerwacja_Pozycja];










GO
CREATE NONCLUSTERED INDEX [INDEX_Rezerwacja_gotowe_od]
    ON [dbo].[Rezerwacja]([gotowe_od] ASC);

