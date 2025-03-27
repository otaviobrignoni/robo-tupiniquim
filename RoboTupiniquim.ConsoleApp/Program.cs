namespace RoboTupiniquim.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Grid.SetGridSize(GlobalUtils.GetValidGridSize());

        Robot.ExecuteInstructions("MDMMEM");
        
        Console.ReadKey();
    }
}
