using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class AddedLanguageListinpeopleandpeopleListinLanguageclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageName",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LanguageName",
                table: "Persons",
                column: "LanguageName");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Languages_LanguageName",
                table: "Persons",
                column: "LanguageName",
                principalTable: "Languages",
                principalColumn: "LanguageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Languages_LanguageName",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_LanguageName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LanguageName",
                table: "Persons");
        }
    }
}
