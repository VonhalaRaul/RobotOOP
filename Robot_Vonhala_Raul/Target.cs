using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Vonhala_Raul
{
    namespace Robot.Target
    {
        public abstract class Target
        {
            public bool IsAlive { get; set; } = true;
            public string Name { get; set; }
        }
        public class Animal : Target
        {
            public Animal()
            {
                Name = "Animal";
            }
        }
        public class Human : Target
        {
            public Human()
            {
                Name = "Human";
            }
        }

        public class Superhero : Target
        {
            public Superhero()
            {
                Name = "Superhero";
            }
        }
    }
}
