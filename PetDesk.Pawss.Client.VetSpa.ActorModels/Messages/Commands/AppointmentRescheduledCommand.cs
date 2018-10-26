using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Commands
{
    public class AppointmentRescheduledCommand
    {
        public IAppointment Appointment { get; private set; }

        public AppointmentRescheduledCommand(IAppointment appointment)
        {
            Appointment = appointment;
        }
    }
}
