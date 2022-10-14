﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ProBarbearia.Persistence.Migrations
{
    public partial class EstabelecimentoNaoRegistradoView : Migration
    {
       
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
                                where a.EstabelecimentoID is null;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view [EstabelecimentoNaoRegistradoView]");
        }
    }
}
