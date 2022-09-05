using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class AddedDbSetforlanguageschangefirstletterinnamefromlowertouppercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Language_LanguageName",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_LanguageName",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "LanguageName",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "LanguageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.AddColumn<string>(
                name: "LanguageName",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "LanguageName");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LanguageName",
                table: "Persons",
                column: "LanguageName");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Language_LanguageName",
                table: "Persons",
                column: "LanguageName",
                principalTable: "Language",
                principalColumn: "LanguageName");
        }
    }
}
