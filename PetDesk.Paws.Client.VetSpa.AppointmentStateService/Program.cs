using Akka.Actor;
using PetDesk.Paws.Client.VetSpa.ActorModels.Actors;
using System;
using Topshelf;

namespace PetDesk.Paws.Client.VetSpa.AppointmentStateService
{
    public class AppointmentStateService
    {
        private ActorSystem actorSystem;

        public void Start()
        {
            actorSystem = ActorSystem.Create("AppointmentSystem");

            var appointmentController = actorSystem.ActorOf<AppointmentControllerActor>("AppointmentController");
        }

        public void Stop()
        {
            actorSystem.Terminate();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(
                aptservice =>
                {

                    aptservice.Service<AppointmentStateService>(s =>
                    {
                        s.ConstructUsing(apt => new AppointmentStateService());
                        s.WhenStarted(apt => apt.Start());
                        s.WhenStopped(apt => apt.Stop());
                    });

                    aptservice.RunAsLocalSystem();
                    aptservice.StartAutomatically();

                    aptservice.SetDescription("Process to store VetSpa actors");
                    aptservice.SetDisplayName("VetSpa Service");
                    aptservice.SetServiceName("VetSpa Service");

                });
        }
    }
}
