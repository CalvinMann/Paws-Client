﻿using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Events
{
    public class LoadRequestedAppointmentsEvent
    {
        public IEnumerable<IAppointment> Appointments { get; private set; }

        public LoadRequestedAppointmentsEvent(IEnumerable<IAppointment> appointments)
        {
            Appointments = appointments;
        }
    }
}
