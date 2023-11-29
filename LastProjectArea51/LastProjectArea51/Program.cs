namespace LastProjectArea51
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

            while (true)
            {
                agent1.MoveRandomly();
                agent2.MoveRandomly();
                agent3.MoveRandomly();

                elevator.CallElevator(agent1, "T2");
                elevator.CallElevator(agent2, "S");
                elevator.CallElevator(agent3, "G");

                Thread.Sleep(2000); 
            }
        }
    }
}
