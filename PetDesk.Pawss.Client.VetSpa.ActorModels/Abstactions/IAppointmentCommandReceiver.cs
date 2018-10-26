using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions
{
    public interface IAppointmentCommandReceiver
    {
        void AppointmentRequestedCommand(IAppointment appointment);

        void AppointmentConfirmedCommand(IAppointment appointment);

        void AppointmentRescheduledCommand(IAppointment appointment);
    }
}
