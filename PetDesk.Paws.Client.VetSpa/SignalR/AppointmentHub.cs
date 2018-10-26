using Microsoft.AspNetCore.SignalR;
using PetDesk.Paws.Client.VetSPA.Models;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Commands;

namespace PetDesk.Paws.Client.VetSpa.SignalR
{
    public class AppointmentHub : Hub//, //IAppointmentCommandReceiver
    {

        private IAppointmentActorSystem _appointmentActorSystem;

        public AppointmentHub(IAppointmentActorSystem appointmentActorSystem)
        {
            _appointmentActorSystem = appointmentActorSystem;
        }

        //Json doesnt like Interfaces. Need to readdress this
        public void AppointmentRequestedCommand(Appointment appointment) //(Iappointment appointment)
        {
            _appointmentActorSystem.SignalRBridge.Tell(new AppointmentRequestedCommand(appointment),
                _appointmentActorSystem.AppointmentController);

        }

        public void AppointmentConfirmedCommand(Appointment appointment)
        {
            _appointmentActorSystem.SignalRBridge.Tell(new AppointmentConfirmedCommand(appointment),
                _appointmentActorSystem.AppointmentController);

        }

        public void AppointmentRescheduledCommand(Appointment appointment)
        {
            _appointmentActorSystem.SignalRBridge.Tell(new AppointmentRescheduledCommand(appointment),
                _appointmentActorSystem.AppointmentController);

        }






    }
}
