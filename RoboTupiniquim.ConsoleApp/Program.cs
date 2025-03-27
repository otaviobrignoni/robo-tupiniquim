namespace RoboTupiniquim.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        string valid = GlobalUtils.GetValidRobotPosition();
        Console.WriteLine(valid);
        Robot.SetRobotPosition(valid);
        Console.ReadKey();
    }
}
