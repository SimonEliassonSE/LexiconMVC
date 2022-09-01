using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class SeedforCityandCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "CityPostalCode", "CityName", "CountryCode" },
                values: new object[,]
                {
                    { "0010", "Oslo", null },
                    { "100", "Tokyo", null },
                    { "22000", "Tijuana", null },
                    { "3000", "Melbourne", null },
                    { "41672", "Gothenburg", null },
                    { "5005", "Bergen", null },
                    { "50632", "Borås", null },
                    { "602", "Kyoto", null },
                    { "60601", "Chicago", null },
                    { "78613", "Austin", null }
                });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "CountryCode", "Continent", "CountryName" },
                values: new object[,]
                {
                    { "+1", "North America", "USA" },
                    { "+46", "Europe", "Sweden" },
                    { "+47", "Europe", "Norway" },
                    { "+52", "South America", "Mexico" },
                    { "+61", "Australia", "Australia" },
                    { "+82", "Asia", "Japan" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "0010");

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "100");

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "22000");

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "3000");

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "41672");

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "5005");

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "50632");

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "602");

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "60601");

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "CityPostalCode",
                keyValue: "78613");

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "CountryCode",
                keyValue: "+1");

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "CountryCode",
                keyValue: "+46");

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "CountryCode",
                keyValue: "+47");

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "CountryCode",
                keyValue: "+52");

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "CountryCode",
                keyValue: "+61");

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "CountryCode",
                keyValue: "+82");
        }
    }
}
