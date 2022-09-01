using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class Seededsomepeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "City", "Name", "Phonenumber" },
                values: new object[,]
                {
                    { 1, "Kinna", "Simon Eliasson", 738450197 },
                    { 2, "Göteborg", "Janne Karlsson", 709952132 },
                    { 3, "Borås", "Annie Svensson", 782161234 },
                    { 4, "Malmö", "Kalle Carlsson", 741237894 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 4);
        }
    }
}
