﻿CREATE TABLE [dbo].[Klient] (
    [id_klient] INT            NOT NULL IDENTITY,
    [imiona]    VARCHAR (50)   NOT NULL,
    [nazwiska]  VARCHAR (50)   NOT NULL,
    [email]     VARCHAR (50)   NULL,
    [telefon]   CHAR (15)      NOT NULL,
    [kara]      DECIMAL (9, 2) NULL,
    [liczba_wypozyczonych] TINYINT NULL, 
    CONSTRAINT [PK_Klient] PRIMARY KEY CLUSTERED ([id_klient] ASC)
);



