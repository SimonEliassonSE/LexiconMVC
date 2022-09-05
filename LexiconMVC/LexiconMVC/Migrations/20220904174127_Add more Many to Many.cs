using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconMVC.Migrations
{
    public partial class AddmoreManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguagePersonModel",
                columns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                values: new object[] { "Japanese", "2001-11-31-8952" });

            migrationBuilder.InsertData(
                table: "LanguagePersonModel",
                columns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                values: new object[] { "Mexican", "2001-11-31-8952" });

            migrationBuilder.InsertData(
                table: "LanguagePersonModel",
                columns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                values: new object[] { "Swedish", "1995-03-07-9898" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguagePersonModel",
                keyColumns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                keyValues: new object[] { "Japanese", "2001-11-31-8952" });

            migrationBuilder.DeleteData(
                table: "LanguagePersonModel",
                keyColumns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                keyValues: new object[] { "Mexican", "2001-11-31-8952" });

            migrationBuilder.DeleteData(
                table: "LanguagePersonModel",
                keyColumns: new[] { "LanguagesListLanguageName", "PeopleListSSN" },
                keyValues: new object[] { "Swedish", "1995-03-07-9898" });
        }
    }
}
