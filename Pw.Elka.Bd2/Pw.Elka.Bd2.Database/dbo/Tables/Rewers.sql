CREATE TABLE [dbo].[Rewers] (
    [id_rewers]   INT  NOT NULL,
    [data_od]     DATE NOT NULL,
    [data_do]     DATE NOT NULL,
    [data_zwrotu] DATE NULL,
    [id_pozycja]  INT  NOT NULL,
    [id_klient]   INT  NOT NULL,
    CONSTRAINT [PK_Rewers] PRIMARY KEY CLUSTERED ([id_rewers] ASC),
    CONSTRAINT [FK_Rewers_Klient] FOREIGN KEY ([id_klient]) REFERENCES [dbo].[Klient] ([id_klient]),
    CONSTRAINT [FK_Rewers_Pozycja] FOREIGN KEY ([id_pozycja]) REFERENCES [dbo].[Pozycja] ([id_pozycja])
);






GO
CREATE NONCLUSTERED INDEX [INDEX_Rewers_id_pozycja]
    ON [dbo].[Rewers]([id_pozycja] ASC);


GO
CREATE NONCLUSTERED INDEX [INDEX_Rewers_data_zwrotu]
    ON [dbo].[Rewers]([data_zwrotu] ASC);


GO
CREATE NONCLUSTERED INDEX [INDEX_Rewers_data_od]
    ON [dbo].[Rewers]([data_od] ASC);


GO
CREATE NONCLUSTERED INDEX [INDEX_Rewers_data_do]
    ON [dbo].[Rewers]([data_do] ASC);

