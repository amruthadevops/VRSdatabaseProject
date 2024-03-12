CREATE TABLE [dbo].[Customer]
(
	[CustomerId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Age] INT NULL, 
    [Gender] NCHAR(10) NULL, 
    [PhoneNumber] NUMERIC NOT NULL, 
    [EmailId] NCHAR(30) NULL
)