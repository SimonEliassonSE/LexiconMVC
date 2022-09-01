using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class ChangedPersonIdtoSSN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "SSN");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "SSN", "City", "Name", "Phonenumber" },
                values: new object[,]
                {
                    { "196103058877", "Kinna", "Simon Eliasson", 738450197 },
                    { "198309067744", "Göteborg", "Janne Karlsson", 709952132 },
                    { "199901023366", "Borås", "Annie Svensson", 782161234 },
                    { "200509012541", "Malmö", "Kalle Carlsson", 741237894 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyColumnType: "nvarchar(450)",
                keyValue: "196103058877");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyColumnType: "nvarchar(450)",
                keyValue: "198309067744");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyColumnType: "nvarchar(450)",
                keyValue: "199901023366");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "SSN",
                keyColumnType: "nvarchar(450)",
                keyValue: "200509012541");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "PersonId");

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
    }
}
