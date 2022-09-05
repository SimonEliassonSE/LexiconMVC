using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class SeedMorepeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "SSN", "CityPostalCode", "Name", "Phonenumber" },
                values: new object[,]
                {
                    { "1969-08-01-7487", null, "Frida Svensson", 778852211 },
                    { "1978-01-01-3578", null, "Björn Bergman", 759982251 },
                    { "1995-03-07-9898", null, "Sara Strand", 761496378 },
                    { "2001-11-31-8952", null, "Andy Hjert", 738660102 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "1969-08-01-7487");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "1978-01-01-3578");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "1995-03-07-9898");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "2001-11-31-8952");
        }
    }
}
