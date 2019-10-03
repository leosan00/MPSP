using Microsoft.EntityFrameworkCore.Migrations;

namespace MPSP.Persistency.Migrations
{
    public partial class updateJucespTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Jucesp");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Jucesp",
                newName: "Uf");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Capital",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dt_constituicao",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Inicio_atv",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero_end",
                table: "Jucesp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_empresa",
                table: "Jucesp",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Capital",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Dt_constituicao",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Inicio_atv",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Numero_end",
                table: "Jucesp");

            migrationBuilder.DropColumn(
                name: "Tipo_empresa",
                table: "Jucesp");

            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "Jucesp",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Jucesp",
                nullable: false,
                defaultValue: 0);
        }
    }
}
