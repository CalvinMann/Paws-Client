﻿using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Events
{
    public class AppointmentRequestedEvent
    {
        public IAppointment Appointment { get; private set; }

        public AppointmentRequestedEvent(IAppointment appointment)
        {
            Appointment = appointment;
        }
    }
}
