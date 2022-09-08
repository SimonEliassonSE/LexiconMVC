﻿using LexiconMVC.Models;

namespace LexiconMVC.ViewModels

{
    public class CityViewModel
    {
        public City City { get; set; }
        public Person PersonModel { get; set; }
        public string CityPostalCode { get; set; }
        public string CityName { get; set; }
        public string CountryID { get; set; }
        public string SSN { get; set; }

        public string Name { get; set; }

        public int Phonenumber { get; set; }
    }
}