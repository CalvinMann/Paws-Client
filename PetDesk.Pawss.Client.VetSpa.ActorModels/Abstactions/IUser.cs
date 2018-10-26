using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions
{
    public interface IUser
    {
         int UserId { get;  }
         string FirstName { get;  }
         string LastName { get;  }
    }
}
