using Akka.Actor;
using PetDesk.Paws.Client.VetSpa.ActorModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions
{
    public interface IAppointmentActorSystem
    {
        IActorRef AppointmentController { get;  }
        IActorRef SignalRBridge { get; }
    }
    
}
