CREATE TABLE [dbo].[Customer] (
    [CustomerId]  INT            NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Age]         INT            NULL,
    [Gender]      NCHAR (10)     NULL,
    [PhoneNumber] NUMERIC (18)   NOT NULL,
    [EmailId]     NCHAR (30)     NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

