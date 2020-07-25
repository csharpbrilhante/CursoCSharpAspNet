CREATE TABLE [dbo].[Pessoas](
	[PessoaId] [int] NOT NULL,
	[Nome] [varchar](90) NOT NULL,
	[Tipo] Char(01) Not Null default 'A',
PRIMARY KEY CLUSTERED 
(
	[PessoaId] ASC
))

GO

INSERT INTO dbo.Pessoas (PessoaId, Nome) VALUES (1, 'Daniel Júnior');
INSERT INTO dbo.Pessoas (PessoaId, Nome) VALUES (2, 'Poliana Protazio');
INSERT INTO dbo.Pessoas (PessoaId, Nome) VALUES (3, 'Bierley Machado');
INSERT INTO dbo.Pessoas (PessoaId, Nome) VALUES (4, 'Kenia Terrinha');
INSERT INTO dbo.Pessoas (PessoaId, Nome) VALUES (5, 'Victor Guimarães');
INSERT INTO dbo.Pessoas (PessoaId, Nome) VALUES (6, 'Luiz Fernando');
INSERT INTO dbo.Pessoas (PessoaId, Nome) VALUES (7, 'Alex Júnior');

GO

select * from Pessoas


USE [Escolar]
GO

/****** Object:  Table [dbo].[Notas]    Script Date: 24/07/2020 19:27:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Notas](
	[NotaId] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[PessoaId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NotaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Notas] ADD  DEFAULT ((0)) FOR [Valor]
GO

ALTER TABLE [dbo].[Notas]  WITH CHECK ADD FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Pessoas] ([PessoaId])
GO

alter table Notas add DataAvaliacao Datetime not null;


delete from notas
INSERT INTO dbo.Notas (NotaId, DataAvaliacao, Valor, PessoaId) VALUES (15, DATEADD(DAY, -27, getdate()), 9.5, 1);
INSERT INTO dbo.Notas (NotaId, DataAvaliacao, Valor, PessoaId) VALUES (16, DATEADD(DAY, -27, getdate()), 8.0, 2);
INSERT INTO dbo.Notas (NotaId, DataAvaliacao, Valor, PessoaId) VALUES (17, DATEADD(DAY, -27, getdate()), 9.0, 3);
INSERT INTO dbo.Notas (NotaId, DataAvaliacao, Valor, PessoaId) VALUES (18, DATEADD(DAY, -27, getdate()), 7.0, 4);
INSERT INTO dbo.Notas (NotaId, DataAvaliacao, Valor, PessoaId) VALUES (19, DATEADD(DAY, -27, getdate()), 8.5, 5);
INSERT INTO dbo.Notas (NotaId, DataAvaliacao, Valor, PessoaId) VALUES (20, DATEADD(DAY, -27, getdate()), 6.5, 6);
INSERT INTO dbo.Notas (NotaId, DataAvaliacao, Valor, PessoaId) VALUES (21, DATEADD(DAY, -27, getdate()), 7.5, 7);
GO
