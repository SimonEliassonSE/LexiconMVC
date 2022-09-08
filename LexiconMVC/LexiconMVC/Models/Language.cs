using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
    public class Language
    {
        [Key]
        public string LanguageName { get; set; }
        public string LanguageShortName { get; set; }

        public List<Person> PeopleList { get; set; } = new List<Person>();
    }
}
