using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Commands
{
    public class AppointmentConfirmedCommand
    {
        public IAppointment Appointment { get; private set; }

        public AppointmentConfirmedCommand(IAppointment appointment)
        {
            Appointment = appointment;
        }
    }
}
