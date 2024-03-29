USE [master]
GO
/****** Object:  Database [presensi]    Script Date: 10/12/2023 7:47:28 PM ******/
CREATE DATABASE [presensi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'presensi', FILENAME = N'D:\SQLSERVER\MSSQL16.SQLEXPRESS01\MSSQL\DATA\presensi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'presensi_log', FILENAME = N'D:\SQLSERVER\MSSQL16.SQLEXPRESS01\MSSQL\DATA\presensi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [presensi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [presensi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [presensi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [presensi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [presensi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [presensi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [presensi] SET ARITHABORT OFF 
GO
ALTER DATABASE [presensi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [presensi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [presensi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [presensi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [presensi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [presensi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [presensi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [presensi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [presensi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [presensi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [presensi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [presensi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [presensi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [presensi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [presensi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [presensi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [presensi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [presensi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [presensi] SET  MULTI_USER 
GO
ALTER DATABASE [presensi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [presensi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [presensi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [presensi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [presensi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [presensi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [presensi] SET QUERY_STORE = ON
GO
ALTER DATABASE [presensi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [presensi]
GO
/****** Object:  Table [dbo].[Atasan]    Script Date: 10/12/2023 7:47:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atasan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](50) NULL,
 CONSTRAINT [PK_Atasan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisi]    Script Date: 10/12/2023 7:47:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](50) NULL,
	[status] [char](10) NULL,
 CONSTRAINT [PK_Divisi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jabatan]    Script Date: 10/12/2023 7:47:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jabatan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_divisi] [int] NULL,
	[nama] [varchar](50) NULL,
	[status] [char](10) NULL,
 CONSTRAINT [PK_Jabatan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pegawai]    Script Date: 10/12/2023 7:47:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pegawai](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_divisi] [int] NULL,
	[id_jabatan] [int] NULL,
	[id_atasan] [int] NULL,
	[nik] [varchar](50) NULL,
	[pass] [varchar](200) NULL,
	[gender] [char](10) NULL,
	[alamat] [text] NULL,
	[email] [varchar](50) NULL,
	[foto] [varchar](200) NULL,
	[ket] [text] NULL,
 CONSTRAINT [PK_Pegawai] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Atasan] ON 

INSERT [dbo].[Atasan] ([id], [nama]) VALUES (1, N'John Doe')
INSERT [dbo].[Atasan] ([id], [nama]) VALUES (2, N'Edward')
INSERT [dbo].[Atasan] ([id], [nama]) VALUES (3, N'Buddy')
SET IDENTITY_INSERT [dbo].[Atasan] OFF
GO
SET IDENTITY_INSERT [dbo].[Divisi] ON 

INSERT [dbo].[Divisi] ([id], [nama], [status]) VALUES (1, N'Jurnalis', N'2         ')
SET IDENTITY_INSERT [dbo].[Divisi] OFF
GO
SET IDENTITY_INSERT [dbo].[Jabatan] ON 

INSERT [dbo].[Jabatan] ([id], [id_divisi], [nama], [status]) VALUES (1, 1, N'Manajer', N'1         ')
INSERT [dbo].[Jabatan] ([id], [id_divisi], [nama], [status]) VALUES (2, 2, N'Staff', N'1         ')
SET IDENTITY_INSERT [dbo].[Jabatan] OFF
GO
SET IDENTITY_INSERT [dbo].[Pegawai] ON 

INSERT [dbo].[Pegawai] ([id], [id_divisi], [id_jabatan], [id_atasan], [nik], [pass], [gender], [alamat], [email], [foto], [ket]) VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pegawai] ([id], [id_divisi], [id_jabatan], [id_atasan], [nik], [pass], [gender], [alamat], [email], [foto], [ket]) VALUES (2, 1, 1, 1, N'123', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', NULL, NULL, N'123', NULL, NULL)
INSERT [dbo].[Pegawai] ([id], [id_divisi], [id_jabatan], [id_atasan], [nik], [pass], [gender], [alamat], [email], [foto], [ket]) VALUES (3, 2, 1, 1, N'123', N'123', N'2         ', N'123', N'Email', N'd:\Users\Lenovo\Downloads\IMG_20230908_175350.jpg', N'123')
INSERT [dbo].[Pegawai] ([id], [id_divisi], [id_jabatan], [id_atasan], [nik], [pass], [gender], [alamat], [email], [foto], [ket]) VALUES (4, NULL, NULL, NULL, NULL, N'1', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Pegawai] OFF
GO
USE [master]
GO
ALTER DATABASE [presensi] SET  READ_WRITE 
GO
