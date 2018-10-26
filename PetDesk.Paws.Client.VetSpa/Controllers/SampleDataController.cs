using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PetDesk.Paws.Client.VetSpa.SignalR;
using PetDesk.Paws.Client.VetSPA.Models;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Messages.Commands;

namespace PetDesk.Paws.Client.VetSpa.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        private IAppointmentActorSystem _appointmentActorSystem;

        public SampleDataController(IAppointmentActorSystem appointmentActorSystem)
        {
            _appointmentActorSystem = appointmentActorSystem;
        }

        [HttpPost]
        public string Post([FromBody]IEnumerable<Appointment> apts)
        {
            string retMessage = string.Empty;

            try
            {
                foreach (Appointment apt in apts)
                {
                    
                    _appointmentActorSystem.SignalRBridge.Tell(new AppointmentRequestedCommand(apt),
                _appointmentActorSystem.AppointmentController);

                }
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }
    }


}
