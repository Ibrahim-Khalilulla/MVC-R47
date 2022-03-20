CREATE TABLE [dbo].[items] (
    [itemcode] VARCHAR (10)  NOT NULL,
    [itemname] VARCHAR (100) NULL,
    [deptid]   VARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([itemcode] ASC),
    FOREIGN KEY ([deptid]) REFERENCES [dbo].[department] ([deptid])
);
go

