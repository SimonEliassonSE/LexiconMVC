using LexiconMVC.Models;

namespace LexiconMVC.ViewModels
{
    public class LanguageViewModel
    {
        public Language Language { get; set; }
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string LanguageShortName { get; set; }
    }
}
