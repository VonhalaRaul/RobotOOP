using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Robot;
using Robot_Vonhala_Raul.Robot.Target;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            var oradeaTargets = new List<Target> { new Human(), new Animal(), new Animal(), new Superhero() };
            var beiusTargets = new List<Target> { new Human(), new Human(), new Animal(), new Superhero() };
            var borsTargets = new List<Target> { new Animal(), new Animal(), new Animal(), new Superhero() };
            var nojoridTargets = new List<Target> { new Human(), new Animal(), new Superhero() };
            var baileFelixTargets = new List<Target> { new Human(), new Animal(), new Superhero() };
            var bihariaTargets = new List<Target> { new Human(), new Human(), new Human(), new Superhero() };
            var alesdTargets = new List<Target> { new Animal(), new Animal(), new Superhero() };

            var zones = new List<Zone>
            {
                new Zone("Oradea", oradeaTargets),
                new Zone("Beius", beiusTargets),
                new Zone("Bors", borsTargets),
                new Zone("Nojorid", nojoridTargets),
                new Zone("Baile Felix", baileFelixTargets),
                new Zone("Biharia", bihariaTargets),
                new Zone("Alesd", alesdTargets)
            };
            Robot robot = new Robot(zones)
            {
                EyeLaserIntensity = Intensity.Kill
            };

            robot.Initialize();

            while (!robot.MissionCompleted)
            {
                if (robot.CurrentTarget != null)
                {
                    robot.FireLaserAt(robot.CurrentTarget);
                    robot.AcquireNextTarget();

                }

            }
        }
    }

}
