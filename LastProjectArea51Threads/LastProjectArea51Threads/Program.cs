namespace LastProjectArea51Threads
{
    public enum SecurityLevel
    {
        Confidential,
        Secret,
        TopSecret
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Elevator elevator = new Elevator();

            Agent agent1 = new Agent("JamesBond", SecurityLevels.Confidential, "G");
            Agent agent2 = new Agent("Killer", SecurityLevels.Secret, "T1");
            Agent agent3 = new Agent("MafiaBoss", SecurityLevels.TopSecret, "S");

            Thread agent1Thread = new Thread(() => SimulateAgent(elevator, agent1));
            Thread agent2Thread = new Thread(() => SimulateAgent(elevator, agent2));
            Thread agent3Thread = new Thread(() => SimulateAgent(elevator, agent3));

            agent1Thread.Start();
            agent2Thread.Start();
            agent3Thread.Start();

            agent1Thread.Join();
            agent2Thread.Join();
            agent3Thread.Join();
        }

        static void SimulateAgent(Elevator elevator, Agent agent)
        {
            while (true)
            {
                agent.MoveRandomly();
                elevator.CallElevator(agent, "T2");
                Thread.Sleep(2000); 
            }
        }
    }
}

