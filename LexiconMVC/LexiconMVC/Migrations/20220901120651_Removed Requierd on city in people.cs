using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class RemovedRequierdoncityinpeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_cities_CityPostalCode",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "CityPostalCode",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "SSN", "CityPostalCode", "Name", "Phonenumber" },
                values: new object[,]
                {
                    { "196103058877", null, "Simon Eliasson", 738450197 },
                    { "198309067744", null, "Janne Karlsson", 709952132 },
                    { "199901023366", null, "Annie Svensson", 782161234 },
                    { "200509012541", null, "Kalle Carlsson", 741237894 }
                });

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

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "196103058877");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "198309067744");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "199901023366");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "200509012541");

            migrationBuilder.AlterColumn<string>(
                name: "CityPostalCode",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_cities_CityPostalCode",
                table: "Persons",
                column: "CityPostalCode",
                principalTable: "cities",
                principalColumn: "CityPostalCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
