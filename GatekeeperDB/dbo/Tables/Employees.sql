CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PersonId] INT NOT NULL,
	[JobId] INT NOT NULL,
	[PhoneNumber] NVARCHAR(20) NOT NULL,
	[EmailAddress] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_Employees_Persons] FOREIGN KEY (PersonId) REFERENCES Persons(Id), 
    CONSTRAINT [FK_Employees_Jobs] FOREIGN KEY (JobId) REFERENCES Jobs(Id)
)
