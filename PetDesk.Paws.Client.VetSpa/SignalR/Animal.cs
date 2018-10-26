using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetDesk.Paws.Client.VetSPA.Models
{
    public class Animal : IAnimal
    {
       
        //public Animal(int animalId, string firstName, string species, string breed)
        //{
        //    AnimalId = animalId;
        //    FirstName = firstName;
        //    Species = species;
        //    Breed = breed;
        //}

        public int AnimalId { get;  set; }
        public string FirstName { get;  set; }
        public string Species { get;  set; }
        public string Breed { get;  set; }
    }
}