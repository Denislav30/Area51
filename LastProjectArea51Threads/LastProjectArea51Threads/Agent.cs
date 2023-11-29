using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProjectArea51Threads
{
    internal class Agent
    {
        public string Name { get; }
        public SecurityLevel SecurityLevel { get; }
        public string CurrentFloor { get; set; }

        public Agent(string name, SecurityLevel securityLevel, string currentFloor)
        {
            Name = name;
            SecurityLevel = securityLevel;
            CurrentFloor = currentFloor;
        }

        public void MoveRandomly()
        {
            string[] floors = { "G", "S", "T1", "T2" };
            Random random = new Random();
            int randomIndex = random.Next(floors.Length);
            CurrentFloor = floors[randomIndex];
        }
    }
}
