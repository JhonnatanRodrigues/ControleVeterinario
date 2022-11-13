USE [DB_ControleVeterinario]
GO

/****** Object:  Table [dbo].[CV_Alimentacao]    Script Date: 12/11/2022 23:21:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CV_Alimentacao](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdRFID] [int] NOT NULL,
	[DataHora_FoiCome] [datetime2](7) NOT NULL,
	[DataHora_ParoCome] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CV_Alimentacao]  WITH CHECK ADD  CONSTRAINT [FK_Alimentacao_RFID] FOREIGN KEY([IdRFID])
REFERENCES [dbo].[CV_RFID] ([ID])
GO

ALTER TABLE [dbo].[CV_Alimentacao] CHECK CONSTRAINT [FK_Alimentacao_RFID]
GO

