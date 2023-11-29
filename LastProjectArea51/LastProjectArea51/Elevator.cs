using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastProjectArea51
{
    internal class Elevator
    {
        private string currentFloor;
        private bool[] floorButtonsEnabled;
        private HashSet<string> uniqueFloorsVisited;

        public Elevator()
        {
            currentFloor = "G";
            floorButtonsEnabled = new bool[] { true, true, true, true };
            uniqueFloorsVisited = new HashSet<string> { currentFloor };
        }

        public void CallElevator(Agent agent, string destinationFloor)
        {
            Console.WriteLine($"Agent {agent.Name} with security level {agent.SecurityLevel} on floor {agent.CurrentFloor} presses the elevator button for floor {destinationFloor}.");
            DisableAllButtons();
            MoveElevator(agent, destinationFloor);
        }

        private void MoveElevator(Agent agent, string destinationFloor)
        {
            while (currentFloor != destinationFloor)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Elevator is moving from {currentFloor} to {GetNextFloor(currentFloor, destinationFloor)}");
                currentFloor = GetNextFloor(currentFloor, destinationFloor);
            }

            Console.WriteLine($"Elevator has reached floor {currentFloor}.");
            EnableFloorButton(currentFloor);
            OpenDoor(agent);
        }

        private void OpenDoor(Agent agent)
        {
            Console.WriteLine("Door opens.");

            if (CheckSecurity(agent))
            {
                Console.WriteLine($"Security check passed. Agent {agent.Name} is allowed to exit on floor {currentFloor}.");
                agent.CurrentFloor = currentFloor;
                Console.WriteLine($"Agent {agent.Name} exits on floor {currentFloor}.");

                uniqueFloorsVisited.Add(currentFloor);
                if (uniqueFloorsVisited.Count == floorButtonsEnabled.Length)
                {
                    Console.WriteLine("All agents have visited all floors. Stopping the simulation.");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine($"Security check failed. Agent {agent.Name} cannot exit on floor {currentFloor}. Choosing a different floor.");
                agent.MoveRandomly();
                MoveElevator(agent, agent.CurrentFloor);
                return;
            }

            CloseDoor();
        }

        private void CloseDoor()
        {
            Console.WriteLine("Door closes.");
            EnableAllButtons();
        }

        private bool CheckSecurity(Agent agent)
        {
            switch (currentFloor)
            {
                case "G":
                    return agent.SecurityLevel >= SecurityLevels.Confidential;
                case "S":
                    return agent.SecurityLevel >= SecurityLevels.Secret;
                case "T1":
                case "T2":
                    return agent.SecurityLevel >= SecurityLevels.TopSecret;
                default:
                    return false;
            }
        }

        private string GetNextFloor(string current, string destination)
        {
            if (current == destination)
                return current;

            return current.CompareTo(destination) < 0 ? GetNextFloorAlphabetical(current) : GetPreviousFloorAlphabetical(current);
        }

        private string GetNextFloorAlphabetical(string current)
        {
            switch (current)
            {
                case "G":
                    return "S";
                case "S":
                    return "T1";
                case "T1":
                    return "T2";
                case "T2":
                    return "T2"; 
                default:
                    return current;
            }
        }

        private string GetPreviousFloorAlphabetical(string current)
        {
            switch (current)
            {
                case "G":
                    return "G"; 
                case "S":
                    return "G";
                case "T1":
                    return "S";
                case "T2":
                    return "T1";
                default:
                    return current;
            }
        }

        private void DisableAllButtons()
        {
            for (int i = 0; i < floorButtonsEnabled.Length; i++)
            {
                floorButtonsEnabled[i] = false;
            }
        }

        private void EnableAllButtons()
        {
            for (int i = 0; i < floorButtonsEnabled.Length; i++)
            {
                floorButtonsEnabled[i] = true;
            }
        }

        private void EnableFloorButton(string floor)
        {
            switch (floor)
            {
                case "G":
                    floorButtonsEnabled[0] = true;
                    break;
                case "S":
                    floorButtonsEnabled[1] = true;
                    break;
                case "T1":
                    floorButtonsEnabled[2] = true;
                    break;
                case "T2":
                    floorButtonsEnabled[3] = true;
                    break;
            }
        }
    }
}
