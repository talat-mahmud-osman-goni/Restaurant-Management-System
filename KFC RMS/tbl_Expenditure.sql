CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Remarks] VARCHAR(50) NOT NULL, 
    [Amount] VARCHAR(50) NOT NULL, 
    [Date] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id])
)
