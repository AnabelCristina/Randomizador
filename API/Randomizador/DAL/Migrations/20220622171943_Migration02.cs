using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Randomizador.DAL.Migrations
{
    public partial class Migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Franquia",
                table: "Personagens",
                type: "varchar(max)",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Franquia",
                table: "Personagens");
        }
    }
}
