CREATE TABLE [dbo].[RentalReturn]
(
	[RentalId] INT NOT NULL PRIMARY KEY, 
    [MovieId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [RentalDate] DATE NOT NULL, 
    [ReturnDate] DATE NOT NULL, 
    [RentalFee] NUMERIC NOT NULL, 
    [LateFee] NUMERIC NULL, 
    [ReturnId] INT NOT NULL, 
    CONSTRAINT [Customerid] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([CustomerId]), 
    CONSTRAINT [Movieid] FOREIGN KEY ([MovieId]) REFERENCES [Movie]([MovieId]) 
   

)