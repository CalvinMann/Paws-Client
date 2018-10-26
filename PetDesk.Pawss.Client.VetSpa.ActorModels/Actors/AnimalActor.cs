using Akka.Actor;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Actors
{
    public class AnimalActor : ReceiveActor, IAnimal
    {
        public AnimalActor(IAnimal animal)
        {
            AnimalId = animal.AnimalId;
            FirstName = animal.FirstName;
            Species = animal.Species;
            Breed = animal.Breed;
        }

        public int AnimalId { get; private set; }

        public string FirstName { get; private set; }

        public string Species { get; private set; }

        public string Breed { get; private set; }

    }
}
