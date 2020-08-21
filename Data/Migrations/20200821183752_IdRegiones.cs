using Microsoft.EntityFrameworkCore.Migrations;

namespace Huertos_Autosustentables_PI.Data.Migrations
{
    public partial class IdRegiones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRegione",
                table: "Cultivo");

            migrationBuilder.AddColumn<int>(
                name: "IdRegiones",
                table: "Cultivo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRegiones",
                table: "Cultivo");

            migrationBuilder.AddColumn<int>(
                name: "IdRegione",
                table: "Cultivo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
