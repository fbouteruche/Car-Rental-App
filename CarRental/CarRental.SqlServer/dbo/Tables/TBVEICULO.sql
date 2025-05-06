CREATE TABLE [dbo].[Vehicle] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [Model]                VARCHAR (50) NOT NULL,
    [VehicleGroupId]       INT          NOT NULL,
    [Plate]                VARCHAR (50) NOT NULL,
    [Chassis]              VARCHAR (50) NOT NULL,
    [Brand]                VARCHAR (50) NOT NULL,
    [Color]                VARCHAR (50) NOT NULL,
    [FuelType]             VARCHAR (50) NOT NULL,
    [TankCapacity]         FLOAT (53)   NOT NULL,
    [Year]                 INT          NOT NULL,
    [Mileage]              FLOAT (53)   NOT NULL,
    [NumberOfDoors]        INT          NOT NULL,
    [PeopleCapacity]       INT          NOT NULL,
    [TrunkSize]            VARCHAR (50) NOT NULL,
    [HasAirConditioning]   BIT          NOT NULL,
    [HasPowerSteering]     BIT          NOT NULL,
    [HasAbsBrakes]         BIT          NOT NULL,
    [IsRented]             BIT          NULL,
    CONSTRAINT [PK_VEHICLE] PRIMARY KEY CLUSTERED ([Id] ASC)
);













