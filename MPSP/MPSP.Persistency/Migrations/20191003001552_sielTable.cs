using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MPSP.Persistency.Migrations
{
    public partial class sielTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Siel",
                columns: table => new
                {
                    SielId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    Zona = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Municipio = table.Column<string>(nullable: true),
                    Uf = table.Column<string>(nullable: true),
                    DataDom = table.Column<string>(nullable: true),
                    NomePai = table.Column<string>(nullable: true),
                    NomeMae = table.Column<string>(nullable: true),
                    Naturalidade = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siel", x => x.SielId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siel");
        }
    }
}
