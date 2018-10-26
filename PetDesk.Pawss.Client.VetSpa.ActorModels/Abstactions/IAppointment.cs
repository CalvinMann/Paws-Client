using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions
{
    public interface IAppointment
    {
       
         int AppointmentId { get;  }
         string AppointmentType { get;  }
         DateTime CreatedDateTime { get;  }
         DateTime RequestDateTime { get;  }
         IUser User { get;  }
         IAnimal Animal { get;  }
    }
}
