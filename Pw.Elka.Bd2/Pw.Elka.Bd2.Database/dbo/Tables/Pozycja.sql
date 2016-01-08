CREATE TABLE [dbo].[Pozycja] (
    [id_pozycja]  INT             IDENTITY (1, 1) NOT NULL,
    [isbn]        BIGINT          NULL,
    [nazwa]       VARCHAR (100)   NOT NULL,
    [rok]         SMALLINT        NOT NULL,
    [zdjecie]     VARBINARY (MAX) NULL,
    [dostepna_od] DATE            NULL,
    [wypozyczona] BIT             NOT NULL,
    [id_dzial]    SMALLINT        NOT NULL,
    [id_seria]    INT             NULL,
    [id_typ]      SMALLINT        NOT NULL,
    CONSTRAINT [PK_Pozycja] PRIMARY KEY CLUSTERED ([id_pozycja] ASC),
    CONSTRAINT [FK_Pozycja_Dzial] FOREIGN KEY ([id_dzial]) REFERENCES [dbo].[Dzial] ([id_dzial]),
    CONSTRAINT [FK_Pozycja_Seria] FOREIGN KEY ([id_seria]) REFERENCES [dbo].[Seria] ([id_seria]),
    CONSTRAINT [FK_Pozycja_Typ] FOREIGN KEY ([id_typ]) REFERENCES [dbo].[Typ] ([id_typ])
);












GO
CREATE NONCLUSTERED INDEX [INDEX_Pozycja_wypozyczona]
    ON [dbo].[Pozycja]([wypozyczona] ASC);


GO
CREATE NONCLUSTERED INDEX [INDEX_Pozycja_isbn]
    ON [dbo].[Pozycja]([isbn] ASC);


GO
CREATE NONCLUSTERED INDEX [INDEX_Pozycja_id_dzial]
    ON [dbo].[Pozycja]([id_dzial] ASC);

