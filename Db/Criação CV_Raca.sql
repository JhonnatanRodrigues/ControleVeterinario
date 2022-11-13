USE [DB_ControleVeterinario]
GO

/****** Object:  Table [dbo].[CV_Raca]    Script Date: 12/11/2022 23:21:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CV_Raca](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Raca] [varchar](255) NULL,
	[IdTipoAnimal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CV_Raca]  WITH CHECK ADD  CONSTRAINT [FK_Raca_TipoAnimal] FOREIGN KEY([IdTipoAnimal])
REFERENCES [dbo].[CV_TipoAnimal] ([ID])
GO

ALTER TABLE [dbo].[CV_Raca] CHECK CONSTRAINT [FK_Raca_TipoAnimal]
GO

