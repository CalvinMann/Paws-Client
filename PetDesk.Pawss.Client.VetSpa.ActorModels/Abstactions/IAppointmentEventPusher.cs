using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetDesk.Paws.Client.VetSpa.ActorModels.Abstractions
{
    public interface IAppointmentEventPusher
    {
        void AppointmentRequestedEvent(IAppointment appointment );

        void AppointmentConfirmedEvent(IAppointment appointment);

        void AppointmentRescheduledEvent(IAppointment appointment);
    }
}
