using Akka.Actor;
using PetDesk.Paws.Client.VetSpa.ActorModels.Abstractions;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Commands;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Paws.Client.VetSpa.ActorModels.Actors
{


    public class SignalRBridgeActor : ReceiveActor
    {
        private IAppointmentEventPusher _appointmentEventPusher;
        private IActorRef _appointmentController;

        public SignalRBridgeActor(IAppointmentEventPusher appointmentEventPusher,
            IActorRef appointmentController)
        {
            _appointmentEventPusher = appointmentEventPusher;
            _appointmentController = appointmentController;


            //This wires up our event handlers 
            #region Commands

            Receive<AppointmentRequestedCommand>(
                message => _appointmentController.Tell(message));

            Receive<AppointmentConfirmedCommand>(
             message => _appointmentController.Tell(message));

            Receive<AppointmentRescheduledCommand>(
            message => _appointmentController.Tell(message));

            Receive<LoadAppointmentsCommand>(
           message => _appointmentController.Tell(message));

            #endregion

            #region Events

            Receive<AppointmentRequestedEvent>(
                message => {
                    _appointmentEventPusher.AppointmentRequestedEvent(message.Appointment);
                    });

            Receive<AppointmentConfirmedEvent>(
              message => {
                  _appointmentEventPusher.AppointmentConfirmedEvent(message.Appointment);
              });

            Receive<AppointmentRescheduledEvent>(
             message => {
                 _appointmentEventPusher.AppointmentRescheduledEvent(message.Appointment);
             });

            Receive<LoadRequestedAppointmentsEvent>(
             message => {
                 _appointmentEventPusher.LoadRequestedAppointmentsEvent(message.Appointments);
             });

            Receive<LoadConfirmedAppointmentsEvent>(
           message => {
               _appointmentEventPusher.LoadConfirmedAppointmentsEvent(message.Appointments);
           });

            Receive<LoadRescheduledAppointmentsEvent>(
           message => {
               _appointmentEventPusher.LoadRescheduledAppointmentsEvent(message.Appointments);
           });

            #endregion
        }
    }
}
