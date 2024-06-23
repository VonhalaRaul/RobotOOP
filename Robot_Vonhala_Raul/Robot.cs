using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Robot_Vonhala_Raul;
using Robot_Vonhala_Raul.Robot.Target;

namespace Robot
{
    class Robot
    {
        public Intensity EyeLaserIntensity { get; set; }
        public List<Zone> Zones { get; private set; }
        public List<Zone> VisitedZones { get; private set; }
        public Zone CurrentZone { get; private set; }
        public Target CurrentTarget { get; private set; }
        public bool MissionCompleted { get; private set; }
        private Random random;
        public Robot(List<Zone> zones)
        {
            random = new Random();
            Zones = zones;
            VisitedZones = new List<Zone>();
        }

        public void Initialize()
        {
            Console.WriteLine("Robot initialized.");
            MoveToNextZone();
        }
        public void FireLaserAt(Target target)
        {
            if (target.IsAlive)
            {
                Console.WriteLine($"Firing {EyeLaserIntensity} intensity laser at {target.Name}.");

                if (random.NextDouble() < 0.003)
                {
                    Console.WriteLine("The robot has been defeated");
                    Console.WriteLine(" ");
                    Console.WriteLine("Mission FAILED");
                    Console.WriteLine("Press any key to EXIT...");
                    Console.ReadKey();


                    Environment.Exit(0);
                }
                bool killed = false;
                if (target is Human)
                {
                    killed = random.NextDouble() < 0.60;
                }

                else if (target is Animal)
                {
                    killed = random.NextDouble() < 0.25;
                }
                else if (target is Superhero)
                {
                    killed = random.NextDouble() < 0.15;
                }

                if (killed)
                {
                    target.IsAlive = false;
                    Console.WriteLine($"{target.Name} has been killed.");
                }

                else
                {
                    Console.WriteLine($"{target.Name} avoided the attack.");
                }
            }
        }
        public void AcquireNextTarget()
        {
            if (CurrentZone != null)
            {
                CurrentTarget = CurrentZone.Targets.Find(t => t.IsAlive);
                if (CurrentTarget == null)
                {
                    Console.WriteLine($"No more targets available in {CurrentZone.Name}.");
                    MoveToNextZone();
                }
                else
                {
                    Console.WriteLine($"New target acquired: {CurrentTarget.Name}");
                }
            }
            else
            {
                Console.WriteLine("No current zone available.");
            }

            if (!Zones.Any(zone => zone.Targets.Any(target => target.IsAlive)))
            {

                Console.WriteLine("Mission completed!");
                Console.WriteLine(" ");
                Console.WriteLine("Press any key to EXIT ");
                Console.ReadKey();
                MissionCompleted = true;
            }
        }
        public void MoveToNextZone()
        {
            if (Zones == null || Zones.Count == 0)
            {
                Console.WriteLine("No zones available.");
                return;
            }

            List<Zone> unvisitedZones = Zones.Except(VisitedZones).ToList();
            if (unvisitedZones.Count == 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("All zones visited!");
                return;
            }


            // Alegem o zonă aleatorie din lista de zone
            int nextZoneIndex = random.Next(unvisitedZones.Count);
            CurrentZone = unvisitedZones[nextZoneIndex];
            VisitedZones.Add(CurrentZone);

            Console.WriteLine("/////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("/////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine($"Moving to the next zone: {CurrentZone.Name}");
            AcquireNextTarget();
        }
    }
}
