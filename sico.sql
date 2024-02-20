USE [master]
GO
/****** Object:  Database [Sico_Test]    Script Date: 19/02/2024 19:50:26 ******/
CREATE DATABASE [Sico_Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sico_Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Sico_Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sico_Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Sico_Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Sico_Test] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sico_Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sico_Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sico_Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sico_Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sico_Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sico_Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sico_Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sico_Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sico_Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sico_Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sico_Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sico_Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sico_Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sico_Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sico_Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sico_Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sico_Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sico_Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sico_Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sico_Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sico_Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sico_Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sico_Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sico_Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Sico_Test] SET  MULTI_USER 
GO
ALTER DATABASE [Sico_Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sico_Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sico_Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sico_Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sico_Test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Sico_Test] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Sico_Test] SET QUERY_STORE = ON
GO
ALTER DATABASE [Sico_Test] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Sico_Test]
GO
/****** Object:  Table [dbo].[CURSO]    Script Date: 19/02/2024 19:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CURSO](
	[ID_CURSO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_CURSO] [varchar](50) NULL,
	[DIFICULTAD] [varchar](50) NULL,
 CONSTRAINT [PK_CURSO] PRIMARY KEY CLUSTERED 
(
	[ID_CURSO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTUDIANTE]    Script Date: 19/02/2024 19:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTUDIANTE](
	[ID_ESTUDIANTE] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRES_ESTUDIANTE] [varchar](100) NULL,
	[APELLIDOS_ESTUDIANTE] [varchar](100) NULL,
	[EDAD] [int] NULL,
	[TELEFONO] [bigint] NULL,
	[CORREO] [varchar](60) NULL,
 CONSTRAINT [PK_ESTUDIANTE] PRIMARY KEY CLUSTERED 
(
	[ID_ESTUDIANTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTUDIANTE_X_CURSO]    Script Date: 19/02/2024 19:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTUDIANTE_X_CURSO](
	[ID_ESTUDIANTE_X_CURSO] [int] IDENTITY(1,1) NOT NULL,
	[ID_ESTUDIANTE] [int] NULL,
	[ID_CURSO] [int] NULL,
 CONSTRAINT [PK_ESTUDIANTE_X_CURSO] PRIMARY KEY CLUSTERED 
(
	[ID_ESTUDIANTE_X_CURSO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ESTUDIANTE_X_CURSO]  WITH CHECK ADD  CONSTRAINT [FK_ESTUDIANTE_X_CURSO_CURSO] FOREIGN KEY([ID_CURSO])
REFERENCES [dbo].[CURSO] ([ID_CURSO])
GO
ALTER TABLE [dbo].[ESTUDIANTE_X_CURSO] CHECK CONSTRAINT [FK_ESTUDIANTE_X_CURSO_CURSO]
GO
ALTER TABLE [dbo].[ESTUDIANTE_X_CURSO]  WITH CHECK ADD  CONSTRAINT [FK_ESTUDIANTE_X_CURSO_ESTUDIANTE] FOREIGN KEY([ID_ESTUDIANTE])
REFERENCES [dbo].[ESTUDIANTE] ([ID_ESTUDIANTE])
GO
ALTER TABLE [dbo].[ESTUDIANTE_X_CURSO] CHECK CONSTRAINT [FK_ESTUDIANTE_X_CURSO_ESTUDIANTE]
GO
USE [master]
GO
ALTER DATABASE [Sico_Test] SET  READ_WRITE 
GO
