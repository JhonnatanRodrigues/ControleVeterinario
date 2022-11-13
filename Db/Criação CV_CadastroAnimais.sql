USE [DB_ControleVeterinario]
GO

/****** Object:  Table [dbo].[CV_CadastroAnimais]    Script Date: 12/11/2022 23:21:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CV_CadastroAnimais](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoAnimal] [int] NOT NULL,
	[IdRFID] [int] NOT NULL,
	[IdRaca] [int] NOT NULL,
	[abat_morte] [bit] NULL,
	[DataNacimento] [datetime2](7) NULL,
	[DataAbat_Morte] [datetime2](7) NULL,
	[Peso] [decimal](18, 0) NOT NULL,
	[Genero] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CV_CadastroAnimais] ADD  DEFAULT ((0)) FOR [abat_morte]
GO

ALTER TABLE [dbo].[CV_CadastroAnimais]  WITH CHECK ADD  CONSTRAINT [fk_CadastroAnimais_Raca] FOREIGN KEY([IdRaca])
REFERENCES [dbo].[CV_Raca] ([ID])
GO

ALTER TABLE [dbo].[CV_CadastroAnimais] CHECK CONSTRAINT [fk_CadastroAnimais_Raca]
GO

ALTER TABLE [dbo].[CV_CadastroAnimais]  WITH CHECK ADD  CONSTRAINT [fk_CadastroAnimais_RFID] FOREIGN KEY([IdRFID])
REFERENCES [dbo].[CV_RFID] ([ID])
GO

ALTER TABLE [dbo].[CV_CadastroAnimais] CHECK CONSTRAINT [fk_CadastroAnimais_RFID]
GO

ALTER TABLE [dbo].[CV_CadastroAnimais]  WITH CHECK ADD  CONSTRAINT [fk_CadastroAnimais_TipoAnimal] FOREIGN KEY([IdTipoAnimal])
REFERENCES [dbo].[CV_TipoAnimal] ([ID])
GO

ALTER TABLE [dbo].[CV_CadastroAnimais] CHECK CONSTRAINT [fk_CadastroAnimais_TipoAnimal]
GO

