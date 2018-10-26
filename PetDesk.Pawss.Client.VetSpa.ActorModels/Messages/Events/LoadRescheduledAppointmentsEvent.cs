using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Events
{
    public class LoadRescheduledAppointmentsEvent
    {
        public IEnumerable<IAppointment> Appointments { get; private set; }

        public LoadRescheduledAppointmentsEvent(IEnumerable<IAppointment> appointments)
        {
            Appointments = appointments;
        }
    }
}
