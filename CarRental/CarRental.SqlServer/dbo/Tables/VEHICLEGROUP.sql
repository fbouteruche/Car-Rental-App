CREATE TABLE [dbo].[Vehicle_Group] (
    [Id]                       INT          IDENTITY (1, 1) NOT NULL,
    [Name]                     VARCHAR (50) NOT NULL,
    [DailyPlanRate]            FLOAT (53)   NOT NULL,
    [DailyKmRate]              FLOAT (53)   NULL,
    [ControlledPlanRate]       FLOAT (53)   NOT NULL,
    [ControlledKmLimit]        INT          NULL,
    [ControlledExceededKmRate] FLOAT (53)   NULL,
    [FreePlanRate]             FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_VEHICLE_GROUP] PRIMARY KEY CLUSTERED ([Id] ASC)
);









