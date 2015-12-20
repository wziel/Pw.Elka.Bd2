CREATE TABLE [dbo].[Rezerwacja] (
    [id_rezerwacja] INT  NOT NULL,
    [data_od]       DATE NOT NULL,
    [data_do]       DATE NOT NULL,
    CONSTRAINT [PK_Rezerwacja] PRIMARY KEY CLUSTERED ([id_rezerwacja] ASC)
);



