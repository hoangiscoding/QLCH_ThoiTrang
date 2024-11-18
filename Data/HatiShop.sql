USE [master]
GO
/****** Object:  Database [HatiShop]    Script Date: 11/18/2024 12:54:00 PM ******/
CREATE DATABASE [HatiShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HatiShop', FILENAME = N'D:\SQL\MSSQL16.SQLEXPRESS\MSSQL\DATA\HatiShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HatiShop_log', FILENAME = N'D:\SQL\MSSQL16.SQLEXPRESS\MSSQL\DATA\HatiShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HatiShop] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HatiShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HatiShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HatiShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HatiShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HatiShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HatiShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [HatiShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HatiShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HatiShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HatiShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HatiShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HatiShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HatiShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HatiShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HatiShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HatiShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HatiShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HatiShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HatiShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HatiShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HatiShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HatiShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HatiShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HatiShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HatiShop] SET  MULTI_USER 
GO
ALTER DATABASE [HatiShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HatiShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HatiShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HatiShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HatiShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HatiShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HatiShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [HatiShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HatiShop]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [varchar](50) NOT NULL,
	[CustomerId] [varchar](50) NULL,
	[StaffId] [varchar](50) NULL,
	[CreationTime] [datetime] NOT NULL,
	[DiscountAmount] [float] NULL,
	[OriginalPrice] [float] NOT NULL,
	[DiscountedTotal] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[Id] [varchar](50) NOT NULL,
	[ProductId] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_BillDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [varchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](4) NULL,
	[BirthDate] [datetime] NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Email] [varchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[AvatarPath] [nvarchar](max) NULL,
	[Revenue] [int] NULL,
	[Rank] [nvarchar](50) NULL,
	[Password] [nvarchar](1) NULL,
	[Username] [nvarchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportGood]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportGood](
	[Id] [varchar](50) NOT NULL,
	[StaffId] [varchar](50) NULL,
	[ProductId] [varchar](50) NULL,
	[ImportTime] [datetime] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [varchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [int] NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[Size] [nvarchar](10) NULL,
	[Info] [nvarchar](max) NULL,
	[AvatarPath] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](4) NULL,
	[BirthDate] [datetime] NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Email] [varchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[AvatarPath] [nvarchar](max) NULL,
	[Role] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [varchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Bill] ([Id], [CustomerId], [StaffId], [CreationTime], [DiscountAmount], [OriginalPrice], [DiscountedTotal]) VALUES (N'BI1', N'KH1', N'NV1', CAST(N'2024-10-09T10:36:11.000' AS DateTime), 0, 800000, 800000)
GO
INSERT [dbo].[Bill] ([Id], [CustomerId], [StaffId], [CreationTime], [DiscountAmount], [OriginalPrice], [DiscountedTotal]) VALUES (N'BI2', N'KH1', N'NV0', CAST(N'2024-10-10T09:24:47.000' AS DateTime), 0, 960000, 960000)
GO
INSERT [dbo].[Bill] ([Id], [CustomerId], [StaffId], [CreationTime], [DiscountAmount], [OriginalPrice], [DiscountedTotal]) VALUES (N'BI3', N'KH1', N'NV2', CAST(N'2024-10-10T09:39:54.000' AS DateTime), 0, 680000, 680000)
GO
INSERT [dbo].[Bill] ([Id], [CustomerId], [StaffId], [CreationTime], [DiscountAmount], [OriginalPrice], [DiscountedTotal]) VALUES (N'BI4', N'KH2', N'NV1', CAST(N'2024-11-18T00:49:44.000' AS DateTime), 0, 1280000, 1280000)
GO
INSERT [dbo].[Bill] ([Id], [CustomerId], [StaffId], [CreationTime], [DiscountAmount], [OriginalPrice], [DiscountedTotal]) VALUES (N'BI5', N'KH2', N'NV1', CAST(N'2024-11-18T00:54:56.000' AS DateTime), 0, 580000, 580000)
GO
INSERT [dbo].[Bill] ([Id], [CustomerId], [StaffId], [CreationTime], [DiscountAmount], [OriginalPrice], [DiscountedTotal]) VALUES (N'BI6', N'KH1', N'NV1', CAST(N'2024-11-18T00:57:30.000' AS DateTime), 0, 1020000, 1020000)
GO
INSERT [dbo].[Bill] ([Id], [CustomerId], [StaffId], [CreationTime], [DiscountAmount], [OriginalPrice], [DiscountedTotal]) VALUES (N'BI7', N'KH1', N'NV1', CAST(N'2024-11-18T01:38:39.000' AS DateTime), 0, 1040000, 1040000)
GO
INSERT [dbo].[Bill] ([Id], [CustomerId], [StaffId], [CreationTime], [DiscountAmount], [OriginalPrice], [DiscountedTotal]) VALUES (N'BI8', N'KH2', N'NV1', CAST(N'2024-11-18T01:51:10.000' AS DateTime), 0, 2190000, 2190000)
GO
INSERT [dbo].[Bill] ([Id], [CustomerId], [StaffId], [CreationTime], [DiscountAmount], [OriginalPrice], [DiscountedTotal]) VALUES (N'BI9', N'KH2', N'NV1', CAST(N'2024-11-18T10:47:49.000' AS DateTime), 0, 1400000, 1400000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI1', N'SP1', 1, 100000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI1', N'SP2', 2, 200000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI1', N'SP5', 1, 100000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI3', N'SP5', 3, 240000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI4', N'SP5', 2, 160000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI5', N'SP2', 1, 100000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI6', N'SP4', 2, 360000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI7', N'SP1', 2, 400000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI8', N'SP3', 2, 240000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI9', N'SP1', 3, 600000)
GO
INSERT [dbo].[BillDetail] ([Id], [ProductId], [Quantity], [Total]) VALUES (N'BI9', N'SP2', 2, 200000)
GO
INSERT [dbo].[Customer] ([Id], [FullName], [Gender], [BirthDate], [PhoneNumber], [Email], [Address], [AvatarPath], [Revenue], [Rank], [Password], [Username]) VALUES (N'KH1', N'Trần Thanh Phong', N'Nam', CAST(N'2024-10-08T20:50:07.790' AS DateTime), N'0829229332', N'TTP@gmail.com', N'Nam Định', N'', 800000, N'ĐỒNG', NULL, NULL)
GO
INSERT [dbo].[Customer] ([Id], [FullName], [Gender], [BirthDate], [PhoneNumber], [Email], [Address], [AvatarPath], [Revenue], [Rank], [Password], [Username]) VALUES (N'KH2', N'Nguyễn Quốc Khánh', N'Nam', CAST(N'2023-08-24T20:50:07.000' AS DateTime), N'0835336139', N'nqk@gmail.com', N'Trần Quang Khải - Nam Định', N'', 0, N'ĐỒNG', NULL, NULL)
GO
INSERT [dbo].[Customer] ([Id], [FullName], [Gender], [BirthDate], [PhoneNumber], [Email], [Address], [AvatarPath], [Revenue], [Rank], [Password], [Username]) VALUES (N'KH3', N'Lưu Nguyễn Minh Chill', N'Nữ', CAST(N'2023-11-26T10:11:22.000' AS DateTime), N'0392786589', N'lmnc@gmail.com', N'Tô Hiệu - Nam Định', N'', 0, N'ĐỒNG', NULL, NULL)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM1', N'NV1', N'SP1', CAST(N'2024-10-09T10:33:34.207' AS DateTime), 10)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM10', N'NV0', N'SP7', CAST(N'2024-10-10T09:55:00.800' AS DateTime), 10)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM2', N'NV0', N'SP2', CAST(N'2024-10-09T10:33:50.883' AS DateTime), 20)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM3', N'NV2', N'SP3', CAST(N'2024-10-09T10:34:06.227' AS DateTime), 20)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM4', N'NV0', N'SP4', CAST(N'2024-10-09T10:34:44.550' AS DateTime), 10)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM5', N'NV1', N'SP3', CAST(N'2024-10-09T10:34:56.177' AS DateTime), 10)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM6', N'NV1', N'SP6', CAST(N'2024-10-09T10:35:07.280' AS DateTime), 50)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM7', N'NV2', N'SP5', CAST(N'2024-10-09T10:35:18.197' AS DateTime), 30)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM8', N'NV2', N'SP3', CAST(N'2024-10-09T10:35:30.357' AS DateTime), 40)
GO
INSERT [dbo].[ImportGood] ([Id], [StaffId], [ProductId], [ImportTime], [Quantity]) VALUES (N'IM9', N'NV2', N'SP1', CAST(N'2024-10-09T10:35:55.980' AS DateTime), 20)
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [Type], [Quantity], [Size], [Info], [AvatarPath]) VALUES (N'SP1', N'Áo Hoddie Đỏ', 200000, N'Áo', 25, N'XL', N'Áo Hoddie Nam, Màu Đỏ, Chất vải dày giữ ấm tốt', N'D:\HatiStore\images\products\bff-printed-red-hoodie.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [Type], [Quantity], [Size], [Info], [AvatarPath]) VALUES (N'SP2', N'Áo phông cộc tay', 100000, N'Áo', 10, N'XL', N'Áo phông nam cộc tay trắng', N'D:\HatiStore\images\products\Isolated_black_t-shirt_front.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [Type], [Quantity], [Size], [Info], [AvatarPath]) VALUES (N'SP3', N'Quần sooc xanh', 120000, N'Quần', 63, N'L', N'Quần sooc nam màu xanh dương', N'D:\HatiStore\images\products\casual-men-short-pants.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [Type], [Quantity], [Size], [Info], [AvatarPath]) VALUES (N'SP4', N'Váy nơ ngắn', 180000, N'Áo', 8, N'L', N'Váy màu vàng, chiếc nơ lớn thắt ngang eo', N'D:\HatiStore\images\products\Kids dress -3.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [Type], [Quantity], [Size], [Info], [AvatarPath]) VALUES (N'SP5', N'Quần đùi trắng', 80000, N'Quần', 20, N'XL', N'Quần đùi nam trắng', N'D:\HatiStore\images\products\men_s_white_short.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [Type], [Quantity], [Size], [Info], [AvatarPath]) VALUES (N'SP6', N'Bộ Thu Đông', 480000, N'Combo', 47, N'XL', N'Bộ Thu Đông gồm Áo Hoodie, Áo dài tay và quần dài', N'D:\HatiStore\images\products\shop-clothing-clothes-shop-hanger-modern-shop-boutique.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [Type], [Quantity], [Size], [Info], [AvatarPath]) VALUES (N'SP7', N'Áo Hoodie Trắng', 190000, N'Áo', -1, N'XL', N'Áo Hoodie Trắng chất vải dày giữ ấm tốt', N'D:\HatiStore\images\products\white_front_hoody_mockup.jpg')
GO
INSERT [dbo].[Product] ([Id], [Name], [Price], [Type], [Quantity], [Size], [Info], [AvatarPath]) VALUES (N'SP8', N'hdt', 100000, N'Áo', 0, N'XXXL', N'', N'D:\HatiStore\images\products\white_front_hoody_mockup.jpg')
GO
INSERT [dbo].[Staff] ([Id], [Username], [Password], [FullName], [Gender], [BirthDate], [PhoneNumber], [Email], [Address], [AvatarPath], [Role]) VALUES (N'NV0', N'HoangBao', N'123', N'Hoàng Bảo Nguyên', N'Nam', CAST(N'2004-11-23T10:04:56.937' AS DateTime), N'0366814621', N'hoang2004bao@gmail.com', N'Nam Định', N'D:\HatiStore\images\Avatars\man.png', N'QUẢN LÝ')
GO
INSERT [dbo].[Staff] ([Id], [Username], [Password], [FullName], [Gender], [BirthDate], [PhoneNumber], [Email], [Address], [AvatarPath], [Role]) VALUES (N'NV1', N'hbn', N'2311', N'hbn', N'Nam', CAST(N'2024-10-07T22:04:56.937' AS DateTime), N'0394317040', N'hbn@gmail.com', N'hbn2311', N'D:\HatiStore\images\Avatars\man.png', N'NHÂN VIÊN')
GO
INSERT [dbo].[Staff] ([Id], [Username], [Password], [FullName], [Gender], [BirthDate], [PhoneNumber], [Email], [Address], [AvatarPath], [Role]) VALUES (N'NV2', N'dmh', N'123', N'dmh', N'Nam', CAST(N'2024-10-09T08:01:42.803' AS DateTime), N'0328475892', N'123@gmail.com', N'HP', N'D:\HatiStore\images\Avatars\man.png', N'QUẢN LÝ')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_Product_Name]    Script Date: 11/18/2024 12:54:00 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Product_Name] ON [dbo].[Product]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Staff__536C85E4CA0B8AA2]    Script Date: 11/18/2024 12:54:00 PM ******/
ALTER TABLE [dbo].[Staff] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IDX_Staff_Username]    Script Date: 11/18/2024 12:54:00 PM ******/
CREATE NONCLUSTERED INDEX [IDX_Staff_Username] ON [dbo].[Staff]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ((0)) FOR [Revenue]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([Id])
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ImportGood]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ImportGood]  WITH CHECK ADD FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[CreateNewBill]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CreateNewBill]
	@Id varchar(50),
	@StaffId varchar(50),
	@CustomerId varchar(50),
	@CreationTime datetime,
	@DiscountAmount float,
	@OriginalPrice float,
	@DiscountedTotal float
AS
BEGIN
	INSERT Bill(Id,StaffId,CustomerId,CreationTime,DiscountAmount,OriginalPrice,DiscountedTotal)
	VALUES(@Id,@StaffId,@CustomerId,@CreationTime,@DiscountAmount,@OriginalPrice,@DiscountedTotal)
END;
GO
/****** Object:  StoredProcedure [dbo].[CreateNewBillDetail]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CreateNewBillDetail]
	@Id varchar(50),
	@ProductId varchar(50),
	@Quantity int,
	@Total float
AS
BEGIN
	INSERT BillDetail(Id,ProductId,Quantity,Total)
	VALUES(@Id,@ProductId,@Quantity,@Total)
END;

DROP PROC PayBill
GO
/****** Object:  StoredProcedure [dbo].[CreateNewCustomer]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateNewCustomer]
	@Id varchar(50),
	@Username varchar(50),
	@Password varchar(100),
	@FullName nvarchar(50),
	@Gender nvarchar(4),
	@BirthDate datetime,
	@PhoneNumber varchar(10),
	@Email varchar(100),
	@Address nvarchar(200),
	@AvatarPath nvarchar(MAX),
	@Revenue int,
	@Rank nvarchar(50)
AS
BEGIN
    INSERT Customer (Id,Username,Password,FullName,Gender,BirthDate,PhoneNumber,Email,Address,AvatarPath, Revenue, Rank)
	VALUES (@Id,@Username,@Password, @FullName,@Gender,@BirthDate,@PhoneNumber,@Email,@Address,@AvatarPath,@Revenue,@Rank)
END;
GO
/****** Object:  StoredProcedure [dbo].[CreateNewImportGood]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CreateNewImportGood]
	@Id varchar(50),
	@StaffId varchar(50),
	@ProductId varchar(50),
	@ImportTime datetime,
	@Quantity int
AS
BEGIN
	INSERT ImportGood(Id,StaffId,ProductId,ImportTime,Quantity)
	VALUES(@Id,@StaffId,@ProductId,@ImportTime,@Quantity)
	
	--sửa thông tin về số lượng sản phẩm 
	UPDATE 
		Product
	SET 
		Quantity = Quantity + @Quantity
	WHERE Id = @ProductId
END;
GO
/****** Object:  StoredProcedure [dbo].[CreateNewProduct]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CreateNewProduct]
	@Id varchar(50),
	@Name nvarchar(100),
	@Price int,
	@Type nvarchar(50),
	@Quantity int,
	@Size nvarchar(10),
	@Info nvarchar(MAX),
	@AvatarPath nvarchar(MAX)
AS
BEGIN
	INSERT Product(Id,Name,Price,Type,Quantity,Size,Info,AvatarPath)
	VALUES(@Id,@Name,@Price,@Type,@Quantity,@Size,@Info,@AvatarPath)
END;
GO
/****** Object:  StoredProcedure [dbo].[CreateNewStaff]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateNewStaff]
	@Id varchar(50),
	@Username varchar(50),
	@Password varchar(100),
	@FullName nvarchar(50),
	@Gender nvarchar(4),
	@BirthDate datetime,
	@PhoneNumber varchar(10),
	@Email varchar(100),
	@Address nvarchar(200),
	@AvatarPath nvarchar(MAX),
	@Role nvarchar(50)
AS
BEGIN
    INSERT Staff (Id,Username,Password,FullName,Gender,BirthDate,PhoneNumber,Email,Address,AvatarPath, Role)
	VALUES (@Id,@Username,@Password, @FullName,@Gender,@BirthDate,@PhoneNumber,@Email,@Address,@AvatarPath,@Role)
END;
GO
/****** Object:  StoredProcedure [dbo].[CheckLogin]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckLogin]
	@Username varchar(50),
	@Password varchar(100),
	@Role nvarchar(50)
AS
BEGIN
    SELECT 
		Username,
		Password
		Role
	FROM 
		Staff
	WHERE
		Username = @Username
		AND
		Password = @Password
		AND 
		Role = @Role
END;

GO
/****** Object:  StoredProcedure [dbo].[EditCustomerInfo]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EditCustomerInfo]
	@Id varchar(50),
	@FullName nvarchar(50),
	@Gender nvarchar(4),
	@BirthDate datetime,
	@PhoneNumber varchar(10),
	@Email varchar(100),
	@Address nvarchar(200),
	@AvatarPath nvarchar(MAX),
	@Revenue int,
	@Rank nvarchar(50)
AS
BEGIN
UPDATE Customer
	SET
		FullName = @FullName,
		Gender = @Gender,
		BirthDate = @BirthDate,
		PhoneNumber = @PhoneNumber,
		Email = @Email,
		Address = @Address,
		AvatarPath = @AvatarPath,
		Revenue = @Revenue,
		Rank = @Rank
	WHERE 
		Id = @Id
END

--Sửa thô
GO
/****** Object:  StoredProcedure [dbo].[EditImportGoodInfo]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EditImportGoodInfo]
	@Id varchar(50),
	@StaffId varchar(50),
	@ProductId varchar(50),
	@ImportTime datetime,
	@Quantity int
AS
BEGIN
	Update ImportGood
	SET 
		StaffId = @StaffId,
		ProductId = @ProductId,
		Quantity = @Quantity,
		ImportTime = @ImportTime
	WHERE Id = @Id
END;
GO
/****** Object:  StoredProcedure [dbo].[EditProductInfo]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EditProductInfo]
	@Id varchar(50),
	@Name nvarchar(100),
	@Price int,
	@Type nvarchar(50),
	@Quantity int,
	@Size nvarchar(10),
	@Info nvarchar(MAX),
	@AvatarPath nvarchar(MAX)
AS
BEGIN
	UPDATE Product
	SET
		Name = @Name,
		Price = @Price,
		Type = @Type,
		Quantity = @Quantity,
		Size = @Size,
		Info = @Info,
		AvatarPath = @AvatarPath
	WHERE
		Id = @Id
END;
GO
/****** Object:  StoredProcedure [dbo].[EditStaffInfo]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EditStaffInfo]
	@Id varchar(50),
	@FullName nvarchar(50),
	@Gender nvarchar(4),
	@BirthDate datetime,
	@PhoneNumber varchar(10),
	@Email varchar(100),
	@Address nvarchar(200),
	@AvatarPath nvarchar(MAX),
	@Role nvarchar(50)
AS
BEGIN
UPDATE Staff
	SET
		FullName = @FullName,
		Gender = @Gender,
		BirthDate = @BirthDate,
		PhoneNumber = @PhoneNumber,
		Email = @Email,
		Address = @Address,
		AvatarPath = @AvatarPath,
		Role = @Role
	WHERE 
		Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[EditStaffPassword]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EditStaffPassword]
	@Username varchar(50),
	@Password varchar(100)
AS
BEGIN
	UPDATE Staff
	SET
		Password = @Password
	WHERE 
		Username = @Username
END
GO
/****** Object:  StoredProcedure [dbo].[FindBillByCustomerName]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindBillByCustomerName]
	@Name nvarchar(50)
AS 
BEGIN
	SELECT 
		Id, CustomerId,StaffId,CreationTime,DiscountAmount,OriginalPrice,DiscountedTotal
	FROM 
		Bill
	WHERE 
		StaffId 
		IN 
		(
		SELECT Id
		FROM Staff
		WHERE Staff.FullName LIKE '%' + @Name + '%'
		)
END;
GO
/****** Object:  StoredProcedure [dbo].[FindBillByDate]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindBillByDate]
	@Date varchar(50)
AS 
BEGIN
	SELECT 
		Id, CustomerId,StaffId,CreationTime,DiscountAmount,OriginalPrice,DiscountedTotal
	FROM 
		Bill
	WHERE DAY(CreationTime) = @Date
END;
GO
/****** Object:  StoredProcedure [dbo].[FindBillById]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindBillById]
	@Id varchar(50)
AS 
BEGIN
	SELECT 
		Id, CustomerId,StaffId,CreationTime,DiscountAmount,OriginalPrice,DiscountedTotal
	FROM 
		Bill
	WHERE Id LIKE '%' + @Id + '%'
END;
GO
/****** Object:  StoredProcedure [dbo].[FindById]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindById]
    @Id NVARCHAR(50),
    @Table VARCHAR(50)
AS
BEGIN
    IF @Table = 'Staff'
    BEGIN
        SELECT
            Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
        FROM 
            Staff
        WHERE
            Id LIKE @Id + '%'
    END
    ELSE IF @Table = 'Customer'
    BEGIN
        SELECT
            Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Revenue, Rank
        FROM 
            Customer
        WHERE
            Id LIKE @Id + '%'
    END
END
GO
/****** Object:  StoredProcedure [dbo].[FindByName]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindByName]
	@Fullname nvarchar(50),
	@Table varchar(50)
AS
BEGIN
	IF @Table = 'Staff'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
		FROM 
			Staff
		WHERE
			Fullname LIKE N'%' + @Fullname + '%'
	END
	ELSE IF @Table = 'Customer'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath,Revenue,Rank
		FROM 
			Customer
		WHERE
			Fullname LIKE N'%' + @Fullname + '%'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[FindByPhoneNumber]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindByPhoneNumber]
    @PhoneNumber NVARCHAR(50),
    @Table VARCHAR(50)
AS
BEGIN
    IF @Table = 'Staff'
    BEGIN
        SELECT
            Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
        FROM 
            Staff
        WHERE
            PhoneNumber LIKE @PhoneNumber + '%'
    END
    ELSE IF @Table = 'Customer'
    BEGIN
        SELECT
            Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Revenue, Rank
        FROM 
            Customer
        WHERE
            PhoneNumber LIKE @PhoneNumber + '%'
    END
END

GO
/****** Object:  StoredProcedure [dbo].[FindByRole]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindByRole]
	@Role nvarchar(50),
	@Table varchar(50)
AS
BEGIN
	IF @Table = 'Staff'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
		FROM 
			Staff
		WHERE
			Role = @Role
	END
END
GO
/****** Object:  StoredProcedure [dbo].[FindByUsername]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindByUsername]
	@Username varchar(50),
	@Table varchar(50)
AS
BEGIN
	IF @Table = 'Staff'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, Role
		FROM 
			Staff
		WHERE
			Username LIKE N'%' + @Username + '%'
	END
	ELSE IF @Table = 'Customer'
	BEGIN
		SELECT
			Id, Username, Password, Fullname, Gender, BirthDate, PhoneNumber, Email, Address, AvatarPath, NULL AS Revenue, NULL AS Rank
		FROM 
			Customer
		WHERE
			Username LIKE N'%' + @Username + '%'
	END
END

GO
/****** Object:  StoredProcedure [dbo].[FindImportGoodByDate]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindImportGoodByDate]
	@Date varchar(50)
AS 
BEGIN
	SELECT 
		Id, StaffId,ProductId,ImportTime,Quantity
	FROM 
		ImportGood
	WHERE DAY(ImportTime) = @Date
END;

GO
/****** Object:  StoredProcedure [dbo].[FindImportGoodById]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindImportGoodById]
	@Id varchar(50)
AS 
BEGIN
	SELECT 
		Id, StaffId,ProductId,ImportTime,Quantity
	FROM 
		ImportGood
	WHERE Id LIKE '%' + @Id + '%'
END;
GO
/****** Object:  StoredProcedure [dbo].[FindImportGoodByStaffName]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindImportGoodByStaffName]
	@Name nvarchar(50)
AS 
BEGIN
	SELECT 
		Id, StaffId,ProductId,ImportTime,Quantity
	FROM 
		ImportGood
	WHERE 
		StaffId 
		IN 
		(
		SELECT Id
		FROM Staff
		WHERE Staff.FullName LIKE '%' + @Name + '%'
		)
END;

GO
/****** Object:  StoredProcedure [dbo].[FindProductById]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindProductById]
	@Id varchar(50)
AS
BEGIN
	SELECT
		Id, Name,Price, Type,Quantity,Size,Info,AvatarPath
	FROM 
		Product
	WHERE Id LIKE '%' + @Id + '%'
END;
GO
/****** Object:  StoredProcedure [dbo].[FindProductByName]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FindProductByName]
	@Name varchar(50)
AS
BEGIN
	SELECT
		Id, Name,Price, Type,Quantity,Size,Info,AvatarPath
	FROM 
		Product
	WHERE Name LIKE '%' + @Name + '%'
END;

GO
/****** Object:  StoredProcedure [dbo].[LoadBill]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LoadBill]
AS
BEGIN
	SELECT 
		Id, CustomerId,StaffId,CreationTime,DiscountAmount,OriginalPrice,DiscountedTotal
	FROM 
		Bill
END;
GO
/****** Object:  StoredProcedure [dbo].[LoadBillDetail]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LoadBillDetail]
AS
BEGIN
	SELECT 
		Id, ProductId,Quantity,Total
	FROM 
		BillDetail
END;

GO
/****** Object:  StoredProcedure [dbo].[LoadCustomer]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LoadCustomer]
AS
BEGIN
	SELECT 
		Id,
		Username,
		Password,
		FullName,
		Gender,
		BirthDate,
		PhoneNumber,
		Email,
		Address,
		AvatarPath,
		Revenue,
		Rank
	FROM 
		Customer
END
GO
/****** Object:  StoredProcedure [dbo].[LoadEmail]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadEmail]
AS
BEGIN
	SELECT 
		Email
	FROM 
		Staff
	UNION
	SELECT 
		Email
	FROM 
		Customer
END;

GO
/****** Object:  StoredProcedure [dbo].[LoadImportGood]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LoadImportGood]
AS
BEGIN
	SELECT 
		Id, StaffId, ProductId,ImportTime,Quantity
	FROM
		ImportGood
END;
GO
/****** Object:  StoredProcedure [dbo].[LoadProduct]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LoadProduct]
AS
BEGIN
	SELECT
		Id, Name,Price,Type,Quantity,Size,Info,AvatarPath
	FROM Product
END;
GO
/****** Object:  StoredProcedure [dbo].[LoadPhone]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadPhone]
AS
BEGIN
	SELECT 
		PhoneNumber
	FROM 
		Staff
	UNION
	SELECT 
		PhoneNumber
	FROM 
		Customer
END;
GO
/****** Object:  StoredProcedure [dbo].[LoadStaff]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LoadStaff]
AS
BEGIN
	SELECT 
		Id,
		Username,
		Password,
		FullName,
		Gender,
		BirthDate,
		PhoneNumber,
		Email,
		Address,
		AvatarPath,
		Role
	FROM 
		Staff
END
GO
/****** Object:  StoredProcedure [dbo].[LoadUsername]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadUsername]
AS
BEGIN
	SELECT 
		Username
	FROM 
		Staff
	UNION
	SELECT 
		Username
	FROM 
		Customer
END;
GO
/****** Object:  StoredProcedure [dbo].[RemoveImportGood]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RemoveImportGood]
	@Id varchar(50),
	@ProductId varchar(50),
	@Quantity varchar(50)
AS
BEGIN
	DELETE FROM ImportGood
	WHERE Id = @Id
	UPDATE Product
	SET 
		Product.Quantity -= @Quantity
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveProduct]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RemoveProduct]
	@Id varchar(50)
AS
BEGIN
	DELETE FROM Product
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveStaffByUsername]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RemoveStaffByUsername]
	@Username varchar(50)
AS
BEGIN
	DELETE FROM Staff
	WHERE Username = @Username
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBill]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateBill]
	@Id varchar(50),
	@OriginalPrice float,
	@DiscountAmount float,
	@DiscountedTotal float
AS
BEGIN
	UPDATE Bill
	SET
		OriginalPrice = OriginalPrice +  @OriginalPrice,
		DiscountAmount = DiscountAmount + @DiscountAmount,
		DiscountedTotal = DiscountedTotal + @DiscountedTotal 
	WHERE 
		Id = @Id
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 11/18/2024 12:54:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateProduct]
	@Id varchar(50),
	@Quantity int
AS
BEGIN
	UPDATE Product
	SET
	Quantity = @Quantity
	WHERE
	Id = @Id
END;
GO
USE [master]
GO
ALTER DATABASE [HatiShop] SET  READ_WRITE 
GO
