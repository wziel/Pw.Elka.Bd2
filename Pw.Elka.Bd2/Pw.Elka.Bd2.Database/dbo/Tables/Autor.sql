CREATE TABLE [dbo].[Autor] (
    [id_autor] INT          NOT NULL IDENTITY,
    [imiona]   VARCHAR (50) NOT NULL,
    [nazwiska] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED ([id_autor] ASC)
);



