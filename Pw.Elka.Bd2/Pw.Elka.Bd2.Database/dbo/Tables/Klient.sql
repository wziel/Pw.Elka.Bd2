CREATE TABLE [dbo].[Klient] (
    [id_klient] INT            NOT NULL,
    [imiona]    VARCHAR (50)   NOT NULL,
    [nazwiska]  VARCHAR (50)   NOT NULL,
    [email]     VARCHAR (50)   NULL,
    [telefon]   CHAR (15)      NOT NULL,
    [kara]      DECIMAL (9, 2) NULL
);

