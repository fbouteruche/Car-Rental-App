CREATE TABLE [dbo].[Vehicle_Image] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [VehicleId]  INT             NULL,
    [Image]      VARBINARY (MAX) NULL,
    CONSTRAINT [PK_VEHICLE_IMAGE] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VEHICLE_IMAGE_VEHICLE] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicle] ([Id]) ON DELETE CASCADE
);





