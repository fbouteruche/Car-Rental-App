CREATE TABLE [dbo].[Rental] (
    [Id]                    INT          IDENTITY (1, 1) NOT NULL,
    [VehicleId]             INT          NOT NULL,
    [EmployeeId]            INT          NOT NULL,
    [ContractingClientId]   INT          NOT NULL,
    [DriverClientId]        INT          NULL,
    [CouponId]              INT          NULL,
    [DepartureDate]         DATETIME     NOT NULL,
    [ExpectedReturnDate]    DATETIME     NOT NULL,
    [ReturnDate]            DATETIME     NULL,
    [PlanType]              VARCHAR (50) NOT NULL,
    [InsuranceType]         VARCHAR(50)   NOT NULL,
    [RentalPrice]           FLOAT NOT NULL, 
    [ReturnPrice]           FLOAT NOT NULL, 
    [IsOpen]                BIT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RENTAL_CUSTOMER] FOREIGN KEY ([ContractingClientId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_RENTAL_CUSTOMER1] FOREIGN KEY ([DriverClientId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_RENTAL_COUPON_DISCOUNT] FOREIGN KEY ([CouponId]) REFERENCES [dbo].[Coupon] ([Id]),
    CONSTRAINT [FK_RENTAL_EMPLOYEE] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RENTAL_VEHICLE] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicle] ([Id]) ON DELETE CASCADE
);

