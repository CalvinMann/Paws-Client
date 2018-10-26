using Akka.Actor;
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

        public AppointmentControllerActor()
        {
            _requestedAppointments = new Dictionary<int, IActorRef>();
            _confirmedAppointments = new Dictionary<int, IActorRef>();
            _rescheduledAppointments = new Dictionary<int, IActorRef>();

            Receive<AppointmentRequestedCommand>(message => AppointmentRequestedCommandHandler(message));

            Receive<AppointmentConfirmedCommand>(message => AppointmentConfirmedCommandHandler(message));

            Receive<AppointmentRescheduledCommand>(message => AppointmentRescheduledCommandHandler(message));
        }

        private void AppointmentRescheduledCommandHandler(AppointmentRescheduledCommand message)
        {

            if (!_requestedAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;

            if (_rescheduledAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;

            IActorRef aptActor = _requestedAppointments[message.Appointment.AppointmentId];

            _requestedAppointments.Remove(message.Appointment.AppointmentId);

            _rescheduledAppointments.Add(message.Appointment.AppointmentId, aptActor);

            //Send off event to notify clients 
            Sender.Tell(new AppointmentRescheduledEvent(message.Appointment));
        }

        private void AppointmentConfirmedCommandHandler(AppointmentConfirmedCommand message)
        {

            if (! _requestedAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;

            if ( _confirmedAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;

            IActorRef aptActor = _requestedAppointments[message.Appointment.AppointmentId];

            _requestedAppointments.Remove(message.Appointment.AppointmentId);

            _confirmedAppointments.Add(message.Appointment.AppointmentId, aptActor);

            //Send off event to notify clients 
            Sender.Tell(new AppointmentConfirmedEvent(message.Appointment));
        }

        private void AppointmentRequestedCommandHandler(AppointmentRequestedCommand message)
        {
            if (_requestedAppointments.ContainsKey(message.Appointment.AppointmentId))
                return;

            //We could use a mapper here
            IActorRef aptActor = Context.ActorOf(
                Props.Create(
                    () => new AppointmentActor(message.Appointment)
                ));

            _requestedAppointments.Add(message.Appointment.AppointmentId, aptActor);

            //Send off event to notify clients 
            Sender.Tell(new AppointmentRequestedEvent(message.Appointment));
        }
    }
}
