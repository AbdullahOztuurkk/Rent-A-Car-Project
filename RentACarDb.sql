CREATE DATABASE RentACarDb
USE [RentACarDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15.02.2021 22:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 15.02.2021 22:39:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 15.02.2021 22:39:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[ModelYear] [int] NOT NULL,
	[DailyPrice] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 15.02.2021 22:39:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 15.02.2021 22:39:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 15.02.2021 22:39:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RentDate] [datetime2](7) NOT NULL,
	[ReturnDate] [datetime2](7) NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15.02.2021 22:39:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Brands_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Brands_BrandId]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Colors_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Colors_ColorId]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Users_UserId]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Cars_CarId] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Cars_CarId]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Customers_CustomerId]
GO