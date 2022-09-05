using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class CountryCodetoCountryID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_CountryCode",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cities_CountryCode",
                table: "cities");

            migrationBuilder.DeleteData(
                table: "LanguagePersonModel",
                keyColumns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                keyValues: new object[] { "Japanese", "199302034389" });

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "cities");

            migrationBuilder.AddColumn<string>(
                name: "CountryID",
                table: "cities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "0010",
                column: "CountryID",
                value: "+47");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "100",
                column: "CountryID",
                value: "+82");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "22000",
                column: "CountryID",
                value: "+52");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "3000",
                column: "CountryID",
                value: "+61");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "41672",
                column: "CountryID",
                value: "+46");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "5005",
                column: "CountryID",
                value: "+47");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "50632",
                column: "CountryID",
                value: "+46");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "602",
                column: "CountryID",
                value: "+82");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "60601",
                column: "CountryID",
                value: "+1");

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "78613",
                column: "CountryID",
                value: "+1");

            migrationBuilder.CreateIndex(
                name: "IX_cities_CountryID",
                table: "cities",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries_CountryID",
                table: "cities",
                column: "CountryID",
                principalTable: "countries",
                principalColumn: "CountryCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_CountryID",
                table: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cities_CountryID",
                table: "cities");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "cities");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "cities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "LanguagePersonModel",
                columns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                values: new object[] { "Japanese", "199302034389" });

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
    }
}
