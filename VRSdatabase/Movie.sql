CREATE TABLE [dbo].[Movie]
(
	[MovieId] INT NOT NULL PRIMARY KEY, 
    [Title] NCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Genre] NCHAR(10) NULL, 
    [ReleaseDate] DATE NULL, 
    [Language] NCHAR(50) NULL, 
    
)