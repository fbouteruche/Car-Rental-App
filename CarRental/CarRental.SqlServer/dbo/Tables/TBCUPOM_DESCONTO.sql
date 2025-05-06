CREATE TABLE [dbo].[Coupon]
(
	[Id]          INT          IDENTITY (1, 1) NOT NULL,
    [CouponName]  VARCHAR (50) NOT NULL,
    [Code]        VARCHAR (50) NOT NULL,
    [MinimumValue] FLOAT (53)   NOT NULL,
    [Value]       FLOAT        NOT NULL,    
    [IsFixedDiscount]        BIT          NOT NULL,
    [Validity]    DATE         NOT NULL,
    [PartnerId]   INT          NOT NULL,        
    CONSTRAINT [PK_COUPON] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_COUPON_PARTNER] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[Partner] ([Id])
)
