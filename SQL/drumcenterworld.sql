CREATE TABLE [dbo].[Role] (
    [RoleID]          INT        IDENTITY (1, 1) NOT NULL,
    [RoleDescription] NCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

CREATE TABLE [dbo].[AdminUsers] (
    [Id]       INT          NOT NULL,
    [UserName] VARCHAR (50) NULL,
    [Password] VARCHAR (50) NULL,
    [IsAcive]  BIT          DEFAULT ((1)) NULL,
    [RoleID]   INT          DEFAULT ((2)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [UserID]            INT         IDENTITY (1, 1) NOT NULL,
    [RoleID]            INT         NOT NULL,
    [FirstName]         NCHAR (30)  NOT NULL,
    [LastName]          NCHAR (30)  NOT NULL,
    [Email]             NCHAR (50)  NOT NULL,
    [Street]            NCHAR (50)  NOT NULL,
    [City]              NCHAR (30)  NOT NULL,
    [StateAbbreviation] CHAR (2)    NOT NULL,
    [ZipCode]           CHAR (9)    NOT NULL,
    [UserPassword]      NCHAR (256) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_RoleId] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID])
);

CREATE TABLE [dbo].[Customer]
(
	[CustomerID]	INT				 NOT NULL,
	[JoinDate]		DATE			 NOT NULL,
    [BillingMethod]  NCHAR (50) 	NOT NULL,
	PRIMARY KEY CLUSTERED ([CustomerID] ASC),
	 CONSTRAINT [FK_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Users] ([UserID])
)


CREATE TABLE [dbo].[Product]
(
	[ProductID]    int IDENTITY (1,1) NOT NULL,
	[Category]     NCHAR (80)     NULL,
    [Description]  NCHAR(80)			NOT NULL,
    [PhotoLink]    NCHAR(120)         NOT NULL,
    [AvailableQty] INT				NOT NULL,
    [Price]        DECIMAL(6, 2)        NOT NULL,
    primary key CLUSTERED ([ProductID] ASC),
);


CREATE TABLE [dbo].[CustomerOrder] (
    [OrderID]    INT  IDENTITY (1, 1) NOT NULL,
    [CustomerID] INT  NOT NULL,
    [LastUpdate] DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC)
);

CREATE TABLE [dbo].[Items] (
    [OrderID]   INT NOT NULL,
    [ProductID] INT NOT NULL,
    [OrderQty]  INT NOT NULL,
    CONSTRAINT [FK_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID]) ON DELETE CASCADE
);

insert into Role values ('Customer');
insert into Role values ('Admin');

insert into AdminUsers (Id, UserName, Password, IsAcive, RoleID) values(1, 'admin','admin',1,2);