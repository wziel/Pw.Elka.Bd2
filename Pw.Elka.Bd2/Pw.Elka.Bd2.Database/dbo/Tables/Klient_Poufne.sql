CREATE TABLE [dbo].[Klient_Poufne] (
    [id_klient] INT          NOT NULL,
    [pesel]     INT          NOT NULL,
    [adres]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Klient_Poufne] PRIMARY KEY CLUSTERED ([id_klient] ASC)
);



