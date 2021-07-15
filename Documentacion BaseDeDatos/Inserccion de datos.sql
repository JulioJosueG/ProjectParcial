USE [NewsProjectDB]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 15/7/2021 6:51:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[ArticleId] [int] NOT NULL,
	[idAuthor] [int] NULL,
	[Title] [varchar](20) NULL,
	[content] [varchar](max) NULL,
	[PublishedAt] [datetime] NULL,
	[imageAt] [varchar](max) NULL,
	[CountryCode] [varchar](2) NULL,
	[CategoryId] [int] NULL,
	[IdSource] [int] NULL,
	[idState] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 15/7/2021 6:51:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authors](
	[idAuthor] [int] NOT NULL,
	[Name] [varchar](20) NULL,
	[LastName] [varchar](20) NULL,
	[idCountry] [varchar](2) NULL,
	[idState] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAuthor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 15/7/2021 6:51:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[idCategory] [int] NOT NULL,
	[CategoryName] [varchar](20) NULL,
	[idState] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 15/7/2021 6:51:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[code] [varchar](2) NOT NULL,
	[countryName] [varchar](20) NULL,
	[idState] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sources]    Script Date: 15/7/2021 6:51:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sources](
	[idSource] [int] NOT NULL,
	[SourceName] [varchar](20) NULL,
	[idState] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idSource] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 15/7/2021 6:51:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[idState] [int] NOT NULL,
	[StateName] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([idCategory])
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Countries] ([code])
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD FOREIGN KEY([idAuthor])
REFERENCES [dbo].[authors] ([idAuthor])
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD FOREIGN KEY([IdSource])
REFERENCES [dbo].[Sources] ([idSource])
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD FOREIGN KEY([idState])
REFERENCES [dbo].[State] ([idState])
GO
ALTER TABLE [dbo].[authors]  WITH CHECK ADD FOREIGN KEY([idCountry])
REFERENCES [dbo].[Countries] ([code])
GO
ALTER TABLE [dbo].[authors]  WITH CHECK ADD FOREIGN KEY([idState])
REFERENCES [dbo].[State] ([idState])
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD FOREIGN KEY([idState])
REFERENCES [dbo].[State] ([idState])
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD FOREIGN KEY([idState])
REFERENCES [dbo].[State] ([idState])
GO
ALTER TABLE [dbo].[Sources]  WITH CHECK ADD FOREIGN KEY([idState])
REFERENCES [dbo].[State] ([idState])
GO
