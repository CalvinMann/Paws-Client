using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Commands
{
    public class AppointmentRequestedCommand
    {
        public IAppointment Appointment { get; private set; }

        public AppointmentRequestedCommand(IAppointment appointment)
        {
            Appointment = appointment;
        }
    }
}
