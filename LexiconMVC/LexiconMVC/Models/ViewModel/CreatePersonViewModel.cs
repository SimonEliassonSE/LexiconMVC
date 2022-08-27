﻿namespace LexiconMVC.Models.ViewModel
{
    public class CreatePersonViewModel
    {

        // Vad vill vi skicka med/ komma åt i vår index, detta läggs in här. 
        public PersonModel? PersonModel { get; set; }
        public PeopleViewModel? PeopleViewModel { get; set; }

        public int PersonId { get; set; }
        public string? Name { get; set; }
        public int Phonenumber { get; set; }
        public string? City { get; set; }

        public CreatePersonViewModel()
        {

        }

    }
}
