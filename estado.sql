--
-- Estrutura da tabela "estado"
--

begin try drop table estado end try begin catch end catch
CREATE TABLE estado (
  id int NOT NULL,
  nome varchar(75) DEFAULT NULL,
  uf varchar(2) DEFAULT NULL,
  ibge int DEFAULT NULL,
  pais int DEFAULT NULL,
  ddd varchar(50) DEFAULT NULL
); --ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Unidades Federativas';

	-- Adicionando comentários a tabela
	IF NOT EXISTS (SELECT NULL FROM SYS.EXTENDED_PROPERTIES WHERE [major_id] = OBJECT_ID('estado') AND [minor_id] = 0)
	EXEC sys.sp_addextendedproperty
	@name = N'comentario_estado',
	@value = N'Unidades Federativas',
	@level0type = N'SCHEMA', @level0name = 'dbo', -- coloque seu schema aqui no lugar de 'dbo'
	@level1type = N'TABLE',  @level1name = 'estado';
	GO

--
-- Inserindo dados na tabela "estado"
--

INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES('Acre', 'AC', 12, 1, '68')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES('Alagoas', 'AL', 27, 1, '82')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES('Amazonas', 'AM', 13, 1, '97,92')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES('Amapá', 'AP', 16, 1, '96')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES('Bahia', 'BA', 29, 1, '77,75,73,74,71')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES('Ceará', 'CE', 23, 1, '88,85')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES('Distrito Federal', 'DF', 53, 1, '61')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES('Espírito Santo', 'ES', 32, 1, '28,27')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES('Goiás', 'GO', 52, 1, '62,64,61')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Maranhão', 'MA', 21, 1, '99,98')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Minas Gerais', 'MG', 31, 1, '34,37,31,33,35,38,32')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Mato Grosso do Sul', 'MS', 50, 1, '67')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Mato Grosso', 'MT', 51, 1, '65,66')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Pará', 'PA', 15, 1, '91,94,93')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Paraíba', 'PB', 25, 1, '83')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Pernambuco', 'PE', 26, 1, '81,87')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Piauí', 'PI', 22, 1, '89,86')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Paraná', 'PR', 41, 1, '43,41,42,44,45,46')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Rio de Janeiro', 'RJ', 33, 1, '24,22,21')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Rio Grande do Norte', 'RN', 24, 1, '84')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Rondônia', 'RO', 11, 1, '69')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Roraima', 'RR', 14, 1, '95')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Rio Grande do Sul', 'RS', 43, 1, '53,54,55,51')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Santa Catarina', 'SC', 42, 1, '47,48,49')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Sergipe', 'SE', 28, 1, '79')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'São Paulo', 'SP', 35, 1, '11,12,13,14,15,16,17,18,19')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Tocantins', 'TO', 17, 1, '63')
INSERT INTO dbo.Estado (nome, uf, ibge, pais, ddd) VALUES( 'Exterior', 'EX', 99, NULL, NULL);

--
-- Indexes for table "estado"
--

ALTER TABLE estado
  ADD PRIMARY KEY (id);