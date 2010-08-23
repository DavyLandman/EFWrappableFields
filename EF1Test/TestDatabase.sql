USE [EFTestDatabase]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 08/23/2010 16:36:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Identifier] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [EFTestDatabase]
GO

/****** Object:  Table [dbo].[Categories]    Script Date: 08/23/2010 16:36:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories](
	[Identifier] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [EFTestDatabase]
GO

/****** Object:  Table [dbo].[ProductCategories]    Script Date: 08/23/2010 16:36:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductCategories](
	[Product] [int] NOT NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Product] ASC,
	[Category] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Categories] FOREIGN KEY([Category])
REFERENCES [dbo].[Categories] ([Identifier])
GO

ALTER TABLE [dbo].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Categories]
GO

ALTER TABLE [dbo].[ProductCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategories_Products] FOREIGN KEY([Product])
REFERENCES [dbo].[Products] ([Identifier])
GO

ALTER TABLE [dbo].[ProductCategories] CHECK CONSTRAINT [FK_ProductCategories_Products]
GO

USE [EFTestDatabase]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 08/23/2010 16:37:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[Identifier] [int] IDENTITY(1,1) NOT NULL,
	[Occurance] [datetime] NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [EFTestDatabase]
GO

/****** Object:  Table [dbo].[OrderDetails]    Script Date: 08/23/2010 16:37:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderDetails](
	[Identifier] [int] IDENTITY(1,1) NOT NULL,
	[Order] [int] NOT NULL,
	[Product] [int] NOT NULL,
	[Quantity] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([Order])
REFERENCES [dbo].[Orders] ([Identifier])
GO

ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([Product])
REFERENCES [dbo].[Products] ([Identifier])
GO

ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO


-- Filling the data

SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Identifier],[Name],[Description],[Price])VALUES(1,'Test product','The first test product',12)
INSERT INTO [Products] ([Identifier],[Name],[Description],[Price])VALUES(2,'Second test product','The second test product',43)
SET IDENTITY_INSERT [Products] OFF

SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories] ([Identifier],[Name],[Description])VALUES(1,'First category','The first category for testing')
INSERT INTO [Categories] ([Identifier],[Name],[Description])VALUES(2,'Second category','The second category')
SET IDENTITY_INSERT [Categories] OFF

INSERT INTO [ProductCategories] ([Product],[Category])VALUES(1,1)
INSERT INTO [ProductCategories] ([Product],[Category])VALUES(1,2)
INSERT INTO [ProductCategories] ([Product],[Category])VALUES(2,1)

SET IDENTITY_INSERT [Orders] ON;
INSERT INTO [Orders] ([Identifier],[Occurance],[State])VALUES(1,'Aug 23 2010  4:28:11:350PM',2)
INSERT INTO [Orders] ([Identifier],[Occurance],[State])VALUES(2,'Aug 23 2010  4:28:15:333PM',1)
INSERT INTO [Orders] ([Identifier],[Occurance],[State])VALUES(3,'Aug 23 2010  4:28:17:383PM',3)
INSERT INTO [Orders] ([Identifier],[Occurance],[State])VALUES(4,'Aug 23 2010  4:28:19:230PM',4)
INSERT INTO [Orders] ([Identifier],[Occurance],[State])VALUES(5,'Aug 23 2010  4:28:20:707PM',5)
INSERT INTO [Orders] ([Identifier],[Occurance],[State])VALUES(6,'Aug 23 2010  4:28:22:100PM',6)
SET IDENTITY_INSERT [Orders] OFF

SET IDENTITY_INSERT [OrderDetails] ON;
INSERT INTO [OrderDetails] ([Identifier],[Order],[Product],[Quantity])VALUES(1,1,1,3)
INSERT INTO [OrderDetails] ([Identifier],[Order],[Product],[Quantity])VALUES(2,1,2,4)
INSERT INTO [OrderDetails] ([Identifier],[Order],[Product],[Quantity])VALUES(3,2,1,23)
INSERT INTO [OrderDetails] ([Identifier],[Order],[Product],[Quantity])VALUES(4,3,2,3)
INSERT INTO [OrderDetails] ([Identifier],[Order],[Product],[Quantity])VALUES(5,4,2,34)
INSERT INTO [OrderDetails] ([Identifier],[Order],[Product],[Quantity])VALUES(6,5,1,33)
INSERT INTO [OrderDetails] ([Identifier],[Order],[Product],[Quantity])VALUES(7,5,2,4)
INSERT INTO [OrderDetails] ([Identifier],[Order],[Product],[Quantity])VALUES(8,6,2,55)
SET IDENTITY_INSERT [OrderDetails] OFF
