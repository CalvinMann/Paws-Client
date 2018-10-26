using Akka.Actor;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Commands;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Paws.Client.VetSpa.ActorModels.Actors
{
    public class AppointmentControllerActor : ReceiveActor
    {
        private readonly Dictionary<int, IActorRef> _requestedAppointments;
        private readonly Dictionary<int, IActorRef> _confirmedAppointments;
        private readonly Dictionary<int, IActorRef> _rescheduledAppointments;

        private readonly Dictionary<int, IAppointment> _requestedAppointmentsList;
        private readonly Dictionary<int, IAppointment> _confirmedAppointmentsList;
        private readonly Dictionary<int, IAppointment> _rescheduledAppointmentsList;


        public AppointmentControllerActor()
        {
            _requestedAppointments = new Dictionary<int, IActorRef>();
            _confirmedAppointments = new Dictionary<int, IActorRef>();
            _rescheduledAppointments = new Dictionary<int, IActorRef>();

            _requestedAppointmentsList = new Dictionary<int, IAppointment>();
            _confirmedAppointmentsList = new Dictionary<int, IAppointment>();
            _rescheduledAppointmentsList = new Dictionary<int, IAppointment>();

            Receive<AppointmentRequestedCommand>(message => AppointmentRequestedCommandHandler(message));

            Receive<AppointmentConfirmedCommand>(message => AppointmentConfirmedCommandHandler(message));

            Receive<AppointmentRescheduledCommand>(message => AppointmentRescheduledCommandHandler(message));

            Receive<LoadAppointmentsCommand>(message => LoadAppointmentsCommandHandler(message));
        }

        private void AppointmentRescheduledCommandHandler(AppointmentRescheduledCommand message)
        {

            if (!_requestedAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;

            if (_rescheduledAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;

            IActorRef apt = _requestedAppointments[message.Appointment.AppointmentId];

            _requestedAppointments.Remove(message.Appointment.AppointmentId);
            _rescheduledAppointments.Add(message.Appointment.AppointmentId, apt);

            _requestedAppointmentsList.Remove(message.Appointment.AppointmentId);
            _rescheduledAppointmentsList.Add(message.Appointment.AppointmentId, message.Appointment);

            //Send off event to notify clients 
            Sender.Tell(new AppointmentRescheduledEvent(message.Appointment));
        }

        private void AppointmentConfirmedCommandHandler(AppointmentConfirmedCommand message)
        {

            if (! _requestedAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;

            if ( _confirmedAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;

            IActorRef apt = _requestedAppointments[message.Appointment.AppointmentId];

            _requestedAppointments.Remove(message.Appointment.AppointmentId);
            _confirmedAppointments.Add(message.Appointment.AppointmentId, apt);

            _requestedAppointmentsList.Remove(message.Appointment.AppointmentId);
            _confirmedAppointmentsList.Add(message.Appointment.AppointmentId, message.Appointment);

            //Send off event to notify clients //This is cheating since Im not pulling from actorRef
            Sender.Tell(new AppointmentConfirmedEvent(message.Appointment));
        }

        private void AppointmentRequestedCommandHandler(AppointmentRequestedCommand message)
        {
            if (_requestedAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;


            IActorRef aptActor = Context.ActorOf(
                Props.Create(
                    () => new AppointmentActor(message.Appointment)
                )) ;

            _requestedAppointments.Add(message.Appointment.AppointmentId, aptActor);

            _requestedAppointmentsList.Add(message.Appointment.AppointmentId, message.Appointment);

            //Send off event to notify clients 
            Sender.Tell(new AppointmentRequestedEvent(message.Appointment));
        }

        //I dont like string but doing this for speed at the moment
        private void LoadAppointmentsCommandHandler(LoadAppointmentsCommand message)
        {
            switch (message.AppointmentType)
            {
                case "Requested":
                    Sender.Tell(new LoadRequestedAppointmentsEvent(_requestedAppointmentsList.Values));
                    break;

                case "Confirmed":
                    Sender.Tell(new LoadConfirmedAppointmentsEvent(_confirmedAppointmentsList.Values));
                    break;

                case "Rescheduled":
                    Sender.Tell(new LoadRescheduledAppointmentsEvent(_rescheduledAppointmentsList.Values));
                    break;
            }
        }
    }
}
