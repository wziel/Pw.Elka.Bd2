﻿CREATE TABLE [dbo].[Klient_Poufne] (
    [id_klient] INT          NOT NULL,
    [pesel]     INT          NOT NULL,
    [adres]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Klient_Poufne] PRIMARY KEY CLUSTERED ([id_klient] ASC),
    CONSTRAINT [FK_Klient_Poufne_Klient] FOREIGN KEY ([id_klient]) REFERENCES [dbo].[Klient] ([id_klient])
);




