using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions
{
    public interface IAnimal
    {
         int AnimalId { get;  }
         string FirstName { get;  }
         string Species { get;  }
         string Breed { get;  }
    }
}
