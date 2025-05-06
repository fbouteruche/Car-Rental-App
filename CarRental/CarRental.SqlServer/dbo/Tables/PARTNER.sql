CREATE TABLE [dbo].[Partner]
(
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [PartnerName]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PARTNER] PRIMARY KEY CLUSTERED ([Id] ASC)
);