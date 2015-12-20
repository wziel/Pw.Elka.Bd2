CREATE TABLE [dbo].[Pozycja] (
    [id_pozycja]  INT             NOT NULL,
    [isbn]        BIGINT          NULL,
    [nazwa]       VARCHAR (50)    NOT NULL,
    [rok]         SMALLINT        NOT NULL,
    [zdjecie]     VARBINARY (MAX) NOT NULL,
    [dostepna_od] DATE            NULL,
    [wypozyczona] BIT             NOT NULL,
    [id_dzial]    SMALLINT        NOT NULL,
    [id_seria]    INT             NULL,
    [id_typ]      SMALLINT        NOT NULL,
    CONSTRAINT [PK_Pozycja] PRIMARY KEY CLUSTERED ([id_pozycja] ASC), 
    CONSTRAINT [FK_Pozycja_Dzial] FOREIGN KEY ([id_dzial]) REFERENCES [Dzial]([id_dzial]), 
    CONSTRAINT [FK_Pozycja_Seria] FOREIGN KEY ([id_seria]) REFERENCES [Seria]([id_seria]), 
    CONSTRAINT [FK_Pozycja_Typ] FOREIGN KEY ([id_typ]) REFERENCES [Typ]([id_typ])
);





