using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetDesk.Paws.Client.VetSPA.Models
{
    public class User : IUser
    {
        
        //public User(int userId, string firstName, string lastName)
        //{
        //    UserId = userId;
        //    FirstName = firstName;
        //    LastName = lastName;
        //}

        public int UserId { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; } 
    }
}