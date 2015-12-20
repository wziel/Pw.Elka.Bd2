CREATE TABLE [dbo].[Rezerwacja] (
    [id_rezerwacja]   INT  NOT NULL,
    [data_rezerwacji] DATE NOT NULL,
    [gotowe_od]       DATE NULL,
    [id_pozycja]      INT  NOT NULL,
    [id_klient]       INT  NOT NULL,
    CONSTRAINT [PK_Rezerwacja] PRIMARY KEY CLUSTERED ([id_rezerwacja] ASC), 
    CONSTRAINT [FK_Rezerwacja_Pozycja] FOREIGN KEY ([id_pozycja]) REFERENCES [Pozycja]([id_pozycja]), 
    CONSTRAINT [FK_Rezerwacja_Klient] FOREIGN KEY ([id_klient]) REFERENCES [Klient]([id_klient])
);





