CREATE TABLE [dbo].[Service] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (50) NOT NULL,
    [IsDailyCharged]  BIT NOT NULL,
    [Value] FLOAT (53)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

