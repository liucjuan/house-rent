USE [master]
GO
/****** Object:  Database [House]    Script Date: 08/06/2014 18:04:38 ******/
CREATE DATABASE [House] ON  PRIMARY 
( NAME = N'House', FILENAME = N'F:\C#\ASP,NET WebSite\House\DB\House.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'House_log', FILENAME = N'F:\C#\ASP,NET WebSite\House\DB\House_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [House] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [House].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [House] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [House] SET ANSI_NULLS OFF
GO
ALTER DATABASE [House] SET ANSI_PADDING OFF
GO
ALTER DATABASE [House] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [House] SET ARITHABORT OFF
GO
ALTER DATABASE [House] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [House] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [House] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [House] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [House] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [House] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [House] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [House] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [House] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [House] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [House] SET  DISABLE_BROKER
GO
ALTER DATABASE [House] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [House] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [House] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [House] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [House] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [House] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [House] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [House] SET  READ_WRITE
GO
ALTER DATABASE [House] SET RECOVERY FULL
GO
ALTER DATABASE [House] SET  MULTI_USER
GO
ALTER DATABASE [House] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [House] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'House', N'ON'
GO
USE [House]
GO
/****** Object:  Table [dbo].[District]    Script Date: 08/06/2014 18:04:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[District] ([Id], [Name]) VALUES (1000, N'丰台')
INSERT [dbo].[District] ([Id], [Name]) VALUES (1001, N'东城')
INSERT [dbo].[District] ([Id], [Name]) VALUES (1002, N'西城')
INSERT [dbo].[District] ([Id], [Name]) VALUES (1003, N'石景山')
INSERT [dbo].[District] ([Id], [Name]) VALUES (1004, N'海淀')
INSERT [dbo].[District] ([Id], [Name]) VALUES (1006, N'朝阳')
/****** Object:  Table [dbo].[HouseType]    Script Date: 08/06/2014 18:04:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HouseType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_HouseType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[HouseType] ([Id], [Name]) VALUES (1000, N'一室一厅')
INSERT [dbo].[HouseType] ([Id], [Name]) VALUES (1001, N'一室两厅')
INSERT [dbo].[HouseType] ([Id], [Name]) VALUES (1002, N'两室一厅')
INSERT [dbo].[HouseType] ([Id], [Name]) VALUES (1003, N'两室两厅')
INSERT [dbo].[HouseType] ([Id], [Name]) VALUES (1004, N'三室一厅')
INSERT [dbo].[HouseType] ([Id], [Name]) VALUES (1005, N'三室两厅')
INSERT [dbo].[HouseType] ([Id], [Name]) VALUES (1006, N'四室一厅')
INSERT [dbo].[HouseType] ([Id], [Name]) VALUES (1007, N'四室两厅')
INSERT [dbo].[HouseType] ([Id], [Name]) VALUES (1008, N'四室三厅')
/****** Object:  Table [dbo].[User]    Script Date: 08/06/2014 18:04:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[LoginId] [int] IDENTITY(10000,1) NOT NULL,
	[LoginName] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Telephone] [nvarchar](20) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([LoginId], [LoginName], [UserName], [Password], [Telephone]) VALUES (10001, N'admin', N'admin', N'admin', NULL)
INSERT [dbo].[User] ([LoginId], [LoginName], [UserName], [Password], [Telephone]) VALUES (10002, N'hlg_owner', N'包建昌', N'123', N'18612346578')
INSERT [dbo].[User] ([LoginId], [LoginName], [UserName], [Password], [Telephone]) VALUES (10003, N'tty_owner', N'陈豪', N'123', N'56567878')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Street]    Script Date: 08/06/2014 18:04:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Street](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_Street] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Street] ([Id], [Name], [DistrictId]) VALUES (1000, N'知春路', 1004)
INSERT [dbo].[Street] ([Id], [Name], [DistrictId]) VALUES (1001, N'中关村大街', 1004)
INSERT [dbo].[Street] ([Id], [Name], [DistrictId]) VALUES (1002, N'学院路', 1004)
INSERT [dbo].[Street] ([Id], [Name], [DistrictId]) VALUES (1003, N'朝阳路', 1006)
/****** Object:  Table [dbo].[House]    Script Date: 08/06/2014 18:04:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[House](
	[HouseId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Floorage] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[StreetId] [int] NOT NULL,
	[Contract] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[PublishUser] [int] NOT NULL,
	[PublishTime] [datetime] NOT NULL,
 CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED 
(
	[HouseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[House] ON
INSERT [dbo].[House] ([HouseId], [Title], [TypeId], [Floorage], [Price], [StreetId], [Contract], [Description], [PublishUser], [PublishTime]) VALUES (2, N'知春路56号院 紧邻13号线', 1002, CAST(61.60 AS Decimal(18, 2)), CAST(4500.00 AS Decimal(18, 2)), 1000, N'13522039951', N'南北通透，家电齐全，拎包入住。', 10002, CAST(0x0000A1F300C0618A AS DateTime))
INSERT [dbo].[House] ([HouseId], [Title], [TypeId], [Floorage], [Price], [StreetId], [Contract], [Description], [PublishUser], [PublishTime]) VALUES (3, N'知春路罗庄东里南北通透', 1002, CAST(58.00 AS Decimal(18, 2)), CAST(3800.00 AS Decimal(18, 2)), 1000, N'1352210787', N'正规两居室，南北通透，木地板，房子非常干净，保持得很好。家电齐全，拎包入住。', 10002, CAST(0x0000A1F300C15DEE AS DateTime))
INSERT [dbo].[House] ([HouseId], [Title], [TypeId], [Floorage], [Price], [StreetId], [Contract], [Description], [PublishUser], [PublishTime]) VALUES (4, N'中关村大主卧', 1004, CAST(18.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), 1001, N'55457788', N'大主卧，北大旁边，干净。', 10002, CAST(0x0000A1F300F8B598 AS DateTime))
INSERT [dbo].[House] ([HouseId], [Title], [TypeId], [Floorage], [Price], [StreetId], [Contract], [Description], [PublishUser], [PublishTime]) VALUES (5, N'朝阳一居室临6号线', 1000, CAST(40.00 AS Decimal(18, 2)), CAST(2600.00 AS Decimal(18, 2)), 1003, N'55457788', N'新装修的一居，希望租给学生或夫妻。', 10002, CAST(0x0000A1F300F92E86 AS DateTime))
INSERT [dbo].[House] ([HouseId], [Title], [TypeId], [Floorage], [Price], [StreetId], [Contract], [Description], [PublishUser], [PublishTime]) VALUES (6, N'青云小区单间', 1002, CAST(10.00 AS Decimal(18, 2)), CAST(900.00 AS Decimal(18, 2)), 1000, N'13522039951', N'二局中的一个小单间，希望租给生活有规律的社会人士或学生。', 10002, CAST(0x0000A1F300F9A355 AS DateTime))
INSERT [dbo].[House] ([HouseId], [Title], [TypeId], [Floorage], [Price], [StreetId], [Contract], [Description], [PublishUser], [PublishTime]) VALUES (7, N'北邮学生宿舍1床位', 1000, CAST(6.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), 1002, N'18711234566', N'北邮研究生宿舍1床位出租', 10002, CAST(0x0000A1F300FA53F8 AS DateTime))
INSERT [dbo].[House] ([HouseId], [Title], [TypeId], [Floorage], [Price], [StreetId], [Contract], [Description], [PublishUser], [PublishTime]) VALUES (9, N'人大好单间出租', 1004, CAST(12.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)), 1001, N'18645456766', N'该房子已有两租户入住，求1人合租，男女不限，生活非常方便。', 10003, CAST(0x0000A25000B7964C AS DateTime))
INSERT [dbo].[House] ([HouseId], [Title], [TypeId], [Floorage], [Price], [StreetId], [Contract], [Description], [PublishUser], [PublishTime]) VALUES (14, N'大标间出租', 1000, CAST(30.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), 1002, N'13132132', N'重播当成你的烦恼的你', 10001, CAST(0x0000A37F011F7C63 AS DateTime))
INSERT [dbo].[House] ([HouseId], [Title], [TypeId], [Floorage], [Price], [StreetId], [Contract], [Description], [PublishUser], [PublishTime]) VALUES (15, N'test', 1004, CAST(150.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), 1003, N'13132132', N'test', 10001, CAST(0x0000A37F012242FD AS DateTime))
SET IDENTITY_INSERT [dbo].[House] OFF
/****** Object:  Default [DF_House_PublishTime]    Script Date: 08/06/2014 18:04:39 ******/
ALTER TABLE [dbo].[House] ADD  CONSTRAINT [DF_House_PublishTime]  DEFAULT (getdate()) FOR [PublishTime]
GO
/****** Object:  ForeignKey [FK_Street_District]    Script Date: 08/06/2014 18:04:39 ******/
ALTER TABLE [dbo].[Street]  WITH CHECK ADD  CONSTRAINT [FK_Street_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([Id])
GO
ALTER TABLE [dbo].[Street] CHECK CONSTRAINT [FK_Street_District]
GO
/****** Object:  ForeignKey [FK_House_House]    Script Date: 08/06/2014 18:04:39 ******/
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_House] FOREIGN KEY([PublishUser])
REFERENCES [dbo].[User] ([LoginId])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_House]
GO
/****** Object:  ForeignKey [FK_House_HouseType]    Script Date: 08/06/2014 18:04:39 ******/
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_HouseType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[HouseType] ([Id])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_HouseType]
GO
/****** Object:  ForeignKey [FK_House_Street]    Script Date: 08/06/2014 18:04:39 ******/
ALTER TABLE [dbo].[House]  WITH CHECK ADD  CONSTRAINT [FK_House_Street] FOREIGN KEY([StreetId])
REFERENCES [dbo].[Street] ([Id])
GO
ALTER TABLE [dbo].[House] CHECK CONSTRAINT [FK_House_Street]
GO
