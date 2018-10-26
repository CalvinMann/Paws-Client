using Microsoft.AspNetCore.SignalR;
using PetDesk.Paws.Client.VetSpa.ActorModels.Abstractions;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetDesk.Paws.Client.VetSpa.SignalR
{
    //singleton created in services
    public class AppointmentEventPusher : IAppointmentEventPusher
    {
        private readonly IHubContext<AppointmentHub> _hubContext; //readonly so we dont change the ref value

        //Inject the hub
        public AppointmentEventPusher(IHubContext<AppointmentHub> hubContext)
        {
            _hubContext = hubContext;
        }

       

        public void AppointmentRequestedEvent(IAppointment appointment)
        {
            _hubContext.Clients.All.SendAsync("AppointmentRequestedEvent", appointment);
        }

        public void AppointmentConfirmedEvent(IAppointment appointment)
        {
            _hubContext.Clients.All.SendAsync("AppointmentConfirmedEvent", appointment);
        }

        public void AppointmentRescheduledEvent(IAppointment appointment)
        {
            _hubContext.Clients.All.SendAsync("AppointmentRescheduledEvent", appointment);
        }
    }
}
