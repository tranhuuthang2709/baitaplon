USE [QLSV]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 22/05/2024 8:21:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[diemthi]    Script Date: 22/05/2024 8:21:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diemthi](
	[MaMH] [int] IDENTITY(1,1) NOT NULL,
	[DiemThi] [float] NULL,
	[Monhoc] [nvarchar](255) NULL,
	[MaSV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[giangvien]    Script Date: 22/05/2024 8:21:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giangvien](
	[MaGV] [int] IDENTITY(1,1) NOT NULL,
	[TenGV] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[SDT] [nvarchar](10) NOT NULL,
	[MaKhoa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khoa]    Script Date: 22/05/2024 8:21:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khoa](
	[MaKhoa] [int] IDENTITY(1,1) NOT NULL,
	[TenKhoa] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lop]    Script Date: 22/05/2024 8:21:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lop](
	[MaLop] [int] IDENTITY(1,1) NOT NULL,
	[TenLop] [nvarchar](50) NOT NULL,
	[MaNganh] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nganh]    Script Date: 22/05/2024 8:21:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nganh](
	[Manganh] [int] IDENTITY(1,1) NOT NULL,
	[Tennganh] [nvarchar](50) NOT NULL,
	[MaKhoa] [int] NULL,
 CONSTRAINT [PK_nganh] PRIMARY KEY CLUSTERED 
(
	[Manganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sinhvien]    Script Date: 22/05/2024 8:21:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sinhvien](
	[MaSV] [int] IDENTITY(1,1) NOT NULL,
	[TenSV] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[SDT] [nvarchar](10) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[MaLop] [int] NULL,
	[AnhSV] [nvarchar](max) NULL,
	[AnhTheSV] [nvarchar](max) NULL,
	[AnhCCCD] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[diemthi]  WITH CHECK ADD  CONSTRAINT [FK_DiemThi_SinhVien] FOREIGN KEY([MaSV])
REFERENCES [dbo].[sinhvien] ([MaSV])
GO
ALTER TABLE [dbo].[diemthi] CHECK CONSTRAINT [FK_DiemThi_SinhVien]
GO
ALTER TABLE [dbo].[giangvien]  WITH CHECK ADD  CONSTRAINT [FK_GiangVien_Khoa] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[khoa] ([MaKhoa])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[giangvien] CHECK CONSTRAINT [FK_GiangVien_Khoa]
GO
ALTER TABLE [dbo].[lop]  WITH CHECK ADD  CONSTRAINT [FK_lop_nganh] FOREIGN KEY([MaNganh])
REFERENCES [dbo].[nganh] ([Manganh])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[lop] CHECK CONSTRAINT [FK_lop_nganh]
GO
ALTER TABLE [dbo].[nganh]  WITH CHECK ADD  CONSTRAINT [FK_nganh_Khoa] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[khoa] ([MaKhoa])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[nganh] CHECK CONSTRAINT [FK_nganh_Khoa]
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([MaLop])
REFERENCES [dbo].[lop] ([MaLop])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[sinhvien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
ALTER TABLE [dbo].[giangvien]  WITH CHECK ADD CHECK  ((len([SDT])=(10) AND ([SDT] like '090%' OR [SDT] like '098%' OR [SDT] like '091%' OR [SDT] like '031%' OR [SDT] like '035%' OR [SDT] like '038%')))
GO
ALTER TABLE [dbo].[giangvien]  WITH CHECK ADD CHECK  ((len([SDT])=(10) AND ([SDT] like '090%' OR [SDT] like '098%' OR [SDT] like '091%' OR [SDT] like '031%' OR [SDT] like '035%' OR [SDT] like '038%')))
GO
ALTER TABLE [dbo].[giangvien]  WITH CHECK ADD CHECK  ((len([TenGV])>=(10) AND len([TenGV])<=(50)))
GO
ALTER TABLE [dbo].[giangvien]  WITH CHECK ADD CHECK  ((len([TenGV])>=(10) AND len([TenGV])<=(50)))
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD CHECK  ((len([SDT])=(10) AND ([SDT] like '090%' OR [SDT] like '098%' OR [SDT] like '091%' OR [SDT] like '031%' OR [SDT] like '035%' OR [SDT] like '038%')))
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD CHECK  ((len([SDT])=(10) AND ([SDT] like '090%' OR [SDT] like '098%' OR [SDT] like '091%' OR [SDT] like '031%' OR [SDT] like '035%' OR [SDT] like '038%')))
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD CHECK  ((len([TenSV])>=(10) AND len([TenSV])<=(50)))
GO
ALTER TABLE [dbo].[sinhvien]  WITH CHECK ADD CHECK  ((len([TenSV])>=(10) AND len([TenSV])<=(50)))
GO
