USE [master]
GO
/****** Object:  Database [AuctionSql]    Script Date: 6/16/2019 7:28:36 PM ******/
CREATE DATABASE [AuctionSql]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AuctionSql', FILENAME = N'C:\Users\Andjela95\AuctionSql.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AuctionSql_log', FILENAME = N'C:\Users\Andjela95\AuctionSql_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AuctionSql].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AuctionSql] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AuctionSql] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AuctionSql] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AuctionSql] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AuctionSql] SET ARITHABORT OFF 
GO
ALTER DATABASE [AuctionSql] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AuctionSql] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AuctionSql] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AuctionSql] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AuctionSql] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AuctionSql] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AuctionSql] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AuctionSql] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AuctionSql] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AuctionSql] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AuctionSql] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AuctionSql] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AuctionSql] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AuctionSql] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AuctionSql] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AuctionSql] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AuctionSql] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AuctionSql] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AuctionSql] SET  MULTI_USER 
GO
ALTER DATABASE [AuctionSql] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AuctionSql] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AuctionSql] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AuctionSql] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AuctionSql] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AuctionSql]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/16/2019 7:28:37 PM ******/
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
/****** Object:  Table [dbo].[Auctioners]    Script Date: 6/16/2019 7:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auctioners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](450) NULL,
	[Password] [nvarchar](30) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Auctioners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Auctions]    Script Date: 6/16/2019 7:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auctions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[AuctionerId] [int] NOT NULL,
	[GoodId] [int] NOT NULL,
	[ValidUntil] [datetime2](7) NOT NULL,
	[MaxPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Auctions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/16/2019 7:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Title] [nvarchar](40) NOT NULL,
	[Description] [nvarchar](150) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Goods]    Script Date: 6/16/2019 7:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[FirstPrice] [decimal](18, 2) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Goods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 6/16/2019 7:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Url] [nvarchar](300) NULL,
	[GoodId] [int] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/16/2019 7:28:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL DEFAULT (getdate()),
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Name] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Auctioners_Email]    Script Date: 6/16/2019 7:28:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Auctioners_Email] ON [dbo].[Auctioners]
(
	[Email] ASC
)
WHERE ([Email] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Auctioners_RoleId]    Script Date: 6/16/2019 7:28:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_Auctioners_RoleId] ON [dbo].[Auctioners]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Auctions_AuctionerId]    Script Date: 6/16/2019 7:28:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_Auctions_AuctionerId] ON [dbo].[Auctions]
(
	[AuctionerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Auctions_GoodId]    Script Date: 6/16/2019 7:28:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_Auctions_GoodId] ON [dbo].[Auctions]
(
	[GoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Goods_CategoryId]    Script Date: 6/16/2019 7:28:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_Goods_CategoryId] ON [dbo].[Goods]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Goods_Title]    Script Date: 6/16/2019 7:28:37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Goods_Title] ON [dbo].[Goods]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Images_GoodId]    Script Date: 6/16/2019 7:28:37 PM ******/
CREATE NONCLUSTERED INDEX [IX_Images_GoodId] ON [dbo].[Images]
(
	[GoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Auctioners]  WITH CHECK ADD  CONSTRAINT [FK_Auctioners_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Auctioners] CHECK CONSTRAINT [FK_Auctioners_Roles_RoleId]
GO
ALTER TABLE [dbo].[Auctions]  WITH CHECK ADD  CONSTRAINT [FK_Auctions_Auctioners_AuctionerId] FOREIGN KEY([AuctionerId])
REFERENCES [dbo].[Auctioners] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Auctions] CHECK CONSTRAINT [FK_Auctions_Auctioners_AuctionerId]
GO
ALTER TABLE [dbo].[Auctions]  WITH CHECK ADD  CONSTRAINT [FK_Auctions_Goods_GoodId] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Goods] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Auctions] CHECK CONSTRAINT [FK_Auctions_Goods_GoodId]
GO
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD  CONSTRAINT [FK_Goods_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Goods] CHECK CONSTRAINT [FK_Goods_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Goods_GoodId] FOREIGN KEY([GoodId])
REFERENCES [dbo].[Goods] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Goods_GoodId]
GO
USE [master]
GO
ALTER DATABASE [AuctionSql] SET  READ_WRITE 
GO
