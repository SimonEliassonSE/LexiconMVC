using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class AddedPeopleListinCityclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityPostalCode",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityPostalCode",
                table: "Persons",
                column: "CityPostalCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_cities_CityPostalCode",
                table: "Persons",
                column: "CityPostalCode",
                principalTable: "cities",
                principalColumn: "CityPostalCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_cities_CityPostalCode",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CityPostalCode",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CityPostalCode",
                table: "Persons");
        }
    }
}
