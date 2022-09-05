using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class CityIDcanbenull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_cities_CityID",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "CityID",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_cities_CityID",
                table: "Persons",
                column: "CityID",
                principalTable: "cities",
                principalColumn: "CityPostalCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_cities_CityID",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "CityID",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_cities_CityID",
                table: "Persons",
                column: "CityID",
                principalTable: "cities",
                principalColumn: "CityPostalCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
