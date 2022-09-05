using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class SeededdatatoPeopleModelLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguagePersonModel",
                columns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                values: new object[] { "Japanese", "199302034389" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguagePersonModel",
                keyColumns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                keyValues: new object[] { "Japanese", "199302034389" });
        }
    }
}
