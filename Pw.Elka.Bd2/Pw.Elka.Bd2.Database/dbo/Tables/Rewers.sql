CREATE TABLE [dbo].[Rewers] (
    [id_rewers]   INT  NOT NULL,
    [data_od]     DATE NOT NULL,
    [data_do]     DATE NOT NULL,
    [data_zwrotu] DATE NULL,
    [id_pozycja]  INT  NOT NULL,
    [id_klient]   INT  NOT NULL,
    CONSTRAINT [PK_Rewers] PRIMARY KEY CLUSTERED ([id_rewers] ASC)
);



