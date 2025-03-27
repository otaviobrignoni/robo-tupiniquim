namespace RoboTupiniquim.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        string instructions = GlobalUtils.GetValidIntructions();
        Console.WriteLine(instructions);
        Grid.SetGridSize(GlobalUtils.GetValidGridSize());


        
        Console.ReadKey();
    }
}
