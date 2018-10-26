using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Events
{
    class AppointmentRescheduledEvent
    {
        public IAppointment Appointment { get; private set; }

        public AppointmentRescheduledEvent(IAppointment appointment)
        {
            Appointment = appointment;
        }
    }
}
