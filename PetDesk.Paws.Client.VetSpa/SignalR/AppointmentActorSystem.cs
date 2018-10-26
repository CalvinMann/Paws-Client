using Akka.Actor;
using PetDesk.Paws.Client.VetSpa.ActorModels.Abstractions;
using PetDesk.Paws.Client.VetSpa.ActorModels.Actors;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetDesk.Paws.Client.VetSpa.SignalR
{
    //Singleton created in services
    public class AppointmentActorSystem : IAppointmentActorSystem, IDisposable
    {
        private readonly ActorSystem _actorSystem;
        private readonly IAppointmentEventPusher _appointmentEventsPusher;

        public AppointmentActorSystem(ActorSystem actorSystem, IAppointmentEventPusher appointmentEventsPusher)
        {
            _appointmentEventsPusher = appointmentEventsPusher;
            _actorSystem = actorSystem;


            Init("akka.tcp://AppointmentSystem@127.0.0.1:8091/user/AppointmentController");
        }

        public IActorRef AppointmentController { get; private set; }

        public IActorRef SignalRBridge { get; private set; }

        public void Dispose()
        {
            if (_actorSystem != null)
                Task.WaitAll(_actorSystem.Terminate());
        }

        private void Init(string controllerIP)
        {

            //AppointmentController =
            //    _actorSystem.ActorSelection(controllerIP)
            //    .ResolveOne(TimeSpan.FromSeconds(3))
            //    .Result;

            AppointmentController = _actorSystem.ActorOf<AppointmentControllerActor>();

            SignalRBridge = _actorSystem.ActorOf(Props.Create(() => new SignalRBridgeActor(_appointmentEventsPusher, AppointmentController)), "SignalRBridge");

        }
    }
}
