USE [DB_ControleVeterinario]
GO

/****** Object:  Table [dbo].[CV_Vacinacao]    Script Date: 12/11/2022 23:22:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CV_Vacinacao](
	[ID] [int] NOT NULL,
	[IdRFID] [int] NOT NULL,
	[DataInicioAplicacao] [datetime2](7) NOT NULL,
	[DataUltimaDose] [datetime2](7) NULL,
	[QuantDose] [decimal](18, 0) NOT NULL,
	[TipoVacinacao] [varchar](1) NOT NULL,
	[EmAplicacao] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CV_Vacinacao] ADD  DEFAULT ((1)) FOR [EmAplicacao]
GO

ALTER TABLE [dbo].[CV_Vacinacao]  WITH CHECK ADD  CONSTRAINT [fk_Vacinacao_RFID] FOREIGN KEY([IdRFID])
REFERENCES [dbo].[CV_RFID] ([ID])
GO

ALTER TABLE [dbo].[CV_Vacinacao] CHECK CONSTRAINT [fk_Vacinacao_RFID]
GO

