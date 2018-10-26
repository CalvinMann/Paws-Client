using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Commands
{
    public class LoadAppointmentsCommand
    {
        public string AppointmentType { get; private set; }

        public LoadAppointmentsCommand(string appointmentType)
        { 
            AppointmentType = appointmentType;
        }
    }
}
