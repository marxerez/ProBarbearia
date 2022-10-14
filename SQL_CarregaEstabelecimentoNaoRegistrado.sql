/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT a.Id, a.Nome,c.Uf, a.CidadeId, b.UserId
  FROM [DbBarbearia].[dbo].[Estabelecimento] a
  left join 
  [DbBarbearia].[dbo].[EstabelecimentoUsuario] b
 on b.EstabelecimentoID = a.Id
  INNER JOIN 
  [DbBarbearia].[dbo].[Cidade] C
ON a.CidadeId= C.Id
where b.UserId not in (select b.UserId from EstabelecimentoUsuario b )

AND C.UF =6
AND C.ID=756
AND B.NOME LIKE '%BAR%'
ORDER BY B.Nome


select a.Id, a.Nome,a.LogoMarcaImagem, a.CidadeId, C.Uf
 from Estabelecimento a
 inner join
 cidade c
 on a.CidadeId= c.Id
 where a.id not in(select b.EstabelecimentoID from EstabelecimentoUsuario b where b.UserId=5)


 protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view [EstabelecimentoNaoRegistradoView] as SELECT b.Id, b.Nome,b.LogoMarcaImagem, b.CidadeId, C.Uf
                                FROM [DbBarbearia].[dbo].[Estabelecimento] b
                                left join 
                                [DbBarbearia].[dbo].[EstabelecimentoUsuario] a
                                on a.EstabelecimentoID = b.Id
                                INNER JOIN 
                                [DbBarbearia].[dbo].[Cidade] C
                                ON B.CidadeId= C.Id
                                where a.EstabelecimentoID is null and a.UserId=5;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view [EstabelecimentoNaoRegistradoView]");
        }