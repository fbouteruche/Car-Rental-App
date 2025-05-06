CREATE TABLE [dbo].[Employee] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [UniqueRegister]   VARCHAR (50) NOT NULL,
    [Address]          VARCHAR (50) NULL,
    [Phone]            VARCHAR (50) NULL,
    [Email]            VARCHAR (50) NULL,
    [IsIndividual]     BIT          NOT NULL,
    [InternalRegister] VARCHAR (50) NOT NULL,
    [AccessUser]       VARCHAR (50) NOT NULL,
    [Password]         VARCHAR (50) NULL,
    [Role]             VARCHAR (50) NOT NULL,
    [Salary]           FLOAT (53)   NOT NULL,
    [AdmissionDate]    DATETIME     NOT NULL,
    CONSTRAINT [PK_EMPLOYEE] PRIMARY KEY CLUSTERED ([Id] ASC)
);









