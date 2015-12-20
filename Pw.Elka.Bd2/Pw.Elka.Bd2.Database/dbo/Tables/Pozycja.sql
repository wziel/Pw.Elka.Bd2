CREATE TABLE [dbo].[Pozycja] (
    [id_pozycja]  INT             NOT NULL,
    [isbn]        BIGINT          NULL,
    [nazwa]       VARCHAR (50)    NOT NULL,
    [rok]         SMALLINT        NOT NULL,
    [zdjecie]     VARBINARY (MAX) NOT NULL,
    [dostepna_od] DATE            NULL
);

