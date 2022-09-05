using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class UpdatedPeopleListandLanguagesList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LanguagePersonModel",
                columns: table => new
                {
                    LanguagesListLanguageName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PeopleListSSN = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePersonModel", x => new { x.LanguagesListLanguageName, x.PeopleListSSN });
                    table.ForeignKey(
                        name: "FK_LanguagePersonModel_Languages_LanguagesListLanguageName",
                        column: x => x.LanguagesListLanguageName,
                        principalTable: "Languages",
                        principalColumn: "LanguageName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagePersonModel_Persons_PeopleListSSN",
                        column: x => x.PeopleListSSN,
                        principalTable: "Persons",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePersonModel_PeopleListSSN",
                table: "LanguagePersonModel",
                column: "PeopleListSSN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguagePersonModel");

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
    }
}
