using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class AddedCityIDtoPersonModelclassandseedednewCityIDinPersonModelseeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CityID",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "196103058877",
                column: "CityID",
                value: "41672");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "1969-08-01-7487",
                column: "CityID",
                value: "602");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "1978-01-01-3578",
                column: "CityID",
                value: "100");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "198309067744",
                column: "CityID",
                value: "50632");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "1995-03-07-9898",
                column: "CityID",
                value: "60601");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "199901023366",
                column: "CityID",
                value: "50632");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "2001-11-31-8952",
                column: "CityID",
                value: "3000");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "SSN",
                keyValue: "200509012541",
                column: "CityID",
                value: "100");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityID",
                table: "Persons",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_cities_CityID",
                table: "Persons",
                column: "CityID",
                principalTable: "cities",
                principalColumn: "CityPostalCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_cities_CityID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CityID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Persons");

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
    }
}
