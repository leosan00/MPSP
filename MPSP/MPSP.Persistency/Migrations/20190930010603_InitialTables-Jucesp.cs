using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MPSP.Persistency.Migrations
{
    public partial class InitialTablesJucesp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jucesp",
                columns: table => new
                {
                    JucespId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jucesp", x => x.JucespId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jucesp");
        }
    }
}
