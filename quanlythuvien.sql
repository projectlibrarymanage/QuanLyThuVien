USE [QUANLYTHUVIEN]
GO
ALTER TABLE [dbo].[TuaSach] DROP CONSTRAINT [FK_TuaSach_TheLoai]
GO
ALTER TABLE [dbo].[TuaSach] DROP CONSTRAINT [FK_TuaSach_TacGia]
GO
ALTER TABLE [dbo].[Sach] DROP CONSTRAINT [FK_Sach_DauSach]
GO
ALTER TABLE [dbo].[Muon] DROP CONSTRAINT [FK_Muon_Sach]
GO
ALTER TABLE [dbo].[Muon] DROP CONSTRAINT [FK_Muon_DocGia]
GO
ALTER TABLE [dbo].[DauSach] DROP CONSTRAINT [FK_DauSach_TuaSach]
GO
/****** Object:  Table [dbo].[TuaSach]    Script Date: 01/07/2019 10:49:15 CH ******/
DROP TABLE [dbo].[TuaSach]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 01/07/2019 10:49:15 CH ******/
DROP TABLE [dbo].[TheLoai]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 01/07/2019 10:49:15 CH ******/
DROP TABLE [dbo].[TacGia]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 01/07/2019 10:49:15 CH ******/
DROP TABLE [dbo].[Sach]
GO
/****** Object:  Table [dbo].[Muon]    Script Date: 01/07/2019 10:49:15 CH ******/
DROP TABLE [dbo].[Muon]
GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 01/07/2019 10:49:15 CH ******/
DROP TABLE [dbo].[DocGia]
GO
/****** Object:  Table [dbo].[DauSach]    Script Date: 01/07/2019 10:49:15 CH ******/
DROP TABLE [dbo].[DauSach]
GO
USE [master]
GO
/****** Object:  Database [QUANLYTHUVIEN]    Script Date: 01/07/2019 10:49:15 CH ******/
DROP DATABASE [QUANLYTHUVIEN]
GO
/****** Object:  Database [QUANLYTHUVIEN]    Script Date: 01/07/2019 10:49:15 CH ******/
CREATE DATABASE [QUANLYTHUVIEN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYTHUVIEN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QUANLYTHUVIEN.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLYTHUVIEN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QUANLYTHUVIEN_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QUANLYTHUVIEN] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLYTHUVIEN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLYTHUVIEN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QUANLYTHUVIEN] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QUANLYTHUVIEN', N'ON'
GO
ALTER DATABASE [QUANLYTHUVIEN] SET QUERY_STORE = OFF
GO
USE [QUANLYTHUVIEN]
GO
/****** Object:  Table [dbo].[DauSach]    Script Date: 01/07/2019 10:49:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DauSach](
	[MaDauSach] [int] NOT NULL,
	[MaTuaSach] [int] NOT NULL,
	[NhaXB] [nvarchar](50) NOT NULL,
	[NamXB] [nvarchar](50) NOT NULL,
	[TriGia] [float] NOT NULL,
 CONSTRAINT [PK_DauSach] PRIMARY KEY CLUSTERED 
(
	[MaDauSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 01/07/2019 10:49:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocGia](
	[MaDocGia] [int] NOT NULL,
	[TenDocGia] [nvarchar](50) NOT NULL,
	[MaLoaiDocGia] [nvarchar](50) NOT NULL,
	[NgaySinh] [smalldatetime] NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[NgayLapThe] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_DocGia] PRIMARY KEY CLUSTERED 
(
	[MaDocGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Muon]    Script Date: 01/07/2019 10:49:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Muon](
	[MaSach] [int] NOT NULL,
	[MaDauSach] [int] NOT NULL,
	[MaDocGia] [int] NOT NULL,
	[NgayMuon] [smalldatetime] NOT NULL,
	[NgayHetHan] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Muon_1] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 01/07/2019 10:49:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [int] NOT NULL,
	[MaDauSach] [int] NOT NULL,
	[TinhTrang] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 01/07/2019 10:49:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTacGia] [int] NOT NULL,
	[TenTacGia] [nvarchar](50) NOT NULL,
	[QueQuan] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 01/07/2019 10:49:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTheLoai] [int] NOT NULL,
	[TenTheLoai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TuaSach]    Script Date: 01/07/2019 10:49:16 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuaSach](
	[MaTuaSach] [int] NOT NULL,
	[TuaSach] [nvarchar](100) NOT NULL,
	[MaTheLoai] [int] NOT NULL,
	[MaTacGia] [int] NOT NULL,
 CONSTRAINT [PK_TuaSach] PRIMARY KEY CLUSTERED 
(
	[MaTuaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DauSach] ([MaDauSach], [MaTuaSach], [NhaXB], [NamXB], [TriGia]) VALUES (1, 1, N'Kim Dong', N'2000', 9000)
INSERT [dbo].[DocGia] ([MaDocGia], [TenDocGia], [MaLoaiDocGia], [NgaySinh], [DiaChi], [Email], [NgayLapThe]) VALUES (1, N'Thuan', N'Sinh Vien', CAST(N'1999-08-24T00:00:00' AS SmallDateTime), N'Gia Lai', N'Meo@mgail.com', CAST(N'2018-11-20T00:00:00' AS SmallDateTime))
INSERT [dbo].[Sach] ([MaSach], [MaDauSach], [TinhTrang]) VALUES (1, 1, N'Con       ')
INSERT [dbo].[TacGia] ([MaTacGia], [TenTacGia], [QueQuan]) VALUES (1, N'Nguyen Van A', N'Binh Dinh')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (1, N'Truyen Tranh')
INSERT [dbo].[TuaSach] ([MaTuaSach], [TuaSach], [MaTheLoai], [MaTacGia]) VALUES (1, N'doremon', 1, 1)
ALTER TABLE [dbo].[DauSach]  WITH CHECK ADD  CONSTRAINT [FK_DauSach_TuaSach] FOREIGN KEY([MaTuaSach])
REFERENCES [dbo].[TuaSach] ([MaTuaSach])
GO
ALTER TABLE [dbo].[DauSach] CHECK CONSTRAINT [FK_DauSach_TuaSach]
GO
ALTER TABLE [dbo].[Muon]  WITH CHECK ADD  CONSTRAINT [FK_Muon_DocGia] FOREIGN KEY([MaDocGia])
REFERENCES [dbo].[DocGia] ([MaDocGia])
GO
ALTER TABLE [dbo].[Muon] CHECK CONSTRAINT [FK_Muon_DocGia]
GO
ALTER TABLE [dbo].[Muon]  WITH CHECK ADD  CONSTRAINT [FK_Muon_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[Muon] CHECK CONSTRAINT [FK_Muon_Sach]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_DauSach] FOREIGN KEY([MaDauSach])
REFERENCES [dbo].[DauSach] ([MaDauSach])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_DauSach]
GO
ALTER TABLE [dbo].[TuaSach]  WITH CHECK ADD  CONSTRAINT [FK_TuaSach_TacGia] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TacGia] ([MaTacGia])
GO
ALTER TABLE [dbo].[TuaSach] CHECK CONSTRAINT [FK_TuaSach_TacGia]
GO
ALTER TABLE [dbo].[TuaSach]  WITH CHECK ADD  CONSTRAINT [FK_TuaSach_TheLoai] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[TheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[TuaSach] CHECK CONSTRAINT [FK_TuaSach_TheLoai]
GO
USE [master]
GO
ALTER DATABASE [QUANLYTHUVIEN] SET  READ_WRITE 
GO
