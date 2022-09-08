﻿using System.ComponentModel.DataAnnotations;

namespace LexiconMVC.Models
{
    public class Person
    {
        // Remove database and change PersonId to SSN and Phonenumber to string, Remove both Required aswell.
        [Key]
        public string SSN { get; set; }
     
        public string Name { get; set; }

        public int Phonenumber { get; set; }      
        
        public string CityID { get; set; }  

        public City City { get; set; }       

        public List<Language> LanguagesList { get; set; } = new List<Language>();

    }
}