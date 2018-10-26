using Akka.Actor;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetDesk.Pawss.Client.VetSpa.ActorModels.Actors
{
    public class UserActor : ReceiveActor, IUser
    {
        public UserActor(IUser user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        public int UserId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
