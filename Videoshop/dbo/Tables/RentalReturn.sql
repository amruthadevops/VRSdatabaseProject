CREATE TABLE [dbo].[RentalReturn] (
    [RentalId]   INT          NOT NULL,
    [MovieId]    INT          NOT NULL,
    [CustomerId] INT          NOT NULL,
    [RentalDate] DATE         NOT NULL,
    [ReturnDate] DATETIME     NOT NULL,
    [RentalFee]  NUMERIC (18) NOT NULL,
    [LateFee]    NUMERIC (18) NULL,
    [ReturnId]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
    CONSTRAINT [Customerid] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId]),
    CONSTRAINT [Movieid] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([MovieId])
);

