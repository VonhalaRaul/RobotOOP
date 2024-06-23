using Robot_Vonhala_Raul.Robot.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class Zone
    {
        public string Name { get; set; }
        public List<Target> Targets { get; set; }

        public Zone(string name, List<Target> targets)
        {
            Name = name;
            Targets = targets;
        }
    }
}
