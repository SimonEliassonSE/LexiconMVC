using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class AddedCitiesListinCountryClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "cities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryCode",
                table: "cities",
                column: "CountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries_CountryCode",
                table: "cities",
                column: "CountryCode",
                principalTable: "countries",
                principalColumn: "CountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_CountryCode",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cities_CountryCode",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "cities");
        }
    }
}
