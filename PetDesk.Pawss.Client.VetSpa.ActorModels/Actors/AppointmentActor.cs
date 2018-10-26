using Akka.Actor;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Paws.Client.VetSpa.ActorModels.Actors
{
    //This class needs to be immutable
    public class AppointmentActor : ReceiveActor, IAppointment
    {
        public AppointmentActor(IAppointment appointment)
        {
            //map all props here

            AppointmentId = appointment.AppointmentId;
            AppointmentType = appointment.AppointmentType;
            CreatedDateTime = appointment.CreatedDateTime;
            RequestDateTime = appointment.RequestDateTime;
            User = appointment.User;
            Animal = appointment.Animal;

            //Create the user and animal actors 

            IActorRef userActor = Context.ActorOf(
              Props.Create(
                  () => new UserActor(appointment.User)
              ));

                IActorRef animalActor = Context.ActorOf(
              Props.Create(
                  () => new AnimalActor(appointment.Animal)
              ));

        }

        public int AppointmentId { get; private set; }

        public string AppointmentType { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public DateTime RequestDateTime { get; private set; }

        public IUser User { get; private set; }

        public IAnimal Animal { get; private set; }
    }
}
