﻿CREATE TABLE [dbo].[Dzial] (
    [id_dzial] SMALLINT     NOT NULL IDENTITY,
    [nazwa]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Dzial] PRIMARY KEY CLUSTERED ([id_dzial] ASC)
);



