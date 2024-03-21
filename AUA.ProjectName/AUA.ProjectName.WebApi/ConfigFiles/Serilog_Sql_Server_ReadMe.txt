To use  Serilog in your project you must do these two steps.

1.Create a table with the following structure in SQL Server

CREATE TABLE [Logs] (

   [Id] int IDENTITY(1,1) NOT NULL,
   [Message] nvarchar(max) NULL,
   [MessageTemplate] nvarchar(max) NULL,
   [Level] nvarchar(128) NULL,
   [TimeStamp] datetime NOT NULL,
   [Exception] nvarchar(max) NULL,
   [Properties] nvarchar(max) NULL

   CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC) 
);


2.Set the Correct connection string in "Serilog.json" File

--change this line
 "connectionString": "Server=.;Database=AUALog;Trusted_Connection=True;"


 ****************************************************
 *    You will succeed , By the AUA framework       *
 ****************************************************