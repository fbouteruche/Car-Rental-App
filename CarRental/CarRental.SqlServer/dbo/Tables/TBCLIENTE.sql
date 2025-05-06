CREATE TABLE [dbo].[Customer] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    [UniqueRegister] VARCHAR (50) NOT NULL,
    [Address]        VARCHAR (50) NULL,
    [Phone]          VARCHAR (50) NULL,
    [Email]          VARCHAR (50) NULL,
    [IsIndividual]   BIT          NOT NULL,
    [DriverLicense]  VARCHAR (50) NULL,
    [DriverLicenseValidity] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);









