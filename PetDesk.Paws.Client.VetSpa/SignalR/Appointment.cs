using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetDesk.Paws.Client.VetSPA.Models
{

    public class Appointment : IAppointment
    {

        public Appointment(User user, Animal animal)
        {
            User = user;
            Animal = animal;
        }
        //public Appointment(int appointmentId, string appointmentType
        //    , DateTime createdDateTime, DateTime requestDateTime
        //    ,IUser user, IAnimal animal)
        //{
        //    AppointmentId = appointmentId;
        //    AppointmentType = appointmentType;
        //    CreatedDateTime = createdDateTime;
        //    RequestDateTime = requestDateTime;
        //    User = user;
        //    Animal = animal;
        //}

        public int AppointmentId { get;  set; }
        public string AppointmentType { get;  set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime RequestDateTime { get; set; }
        public IUser User{ get;  set; }
        public IAnimal Animal { get;  set; }
    }
}