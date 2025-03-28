using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

class RobotUtils
{

    public static string GetValidRobotPosition()
    {
        RobotPrompt("robotPos");
        string robotPosition = GlobalUtils.GetNonNullString();
        while (!Regex.IsMatch(robotPosition, @"^\d+[,. ]+\d+[,. ]+[nslo]$", RegexOptions.IgnoreCase))
        {
            InvalidEntryFormat();
            robotPosition = GlobalUtils.GetNonNullString();
        }
        return robotPosition;
    }

    public static string GetValidInstructions()
    {
        RobotPrompt("instSequence");
        string instructions = GlobalUtils.GetNonNullString();
        while (!Regex.IsMatch(instructions, @"^[dem]+?$", RegexOptions.IgnoreCase))
        {
            InvalidEntryFormat();
            instructions = GlobalUtils.GetNonNullString();
        }
        return instructions.ToUpper();
    }

    public static string GetValidGridSize()
    {
        RobotPrompt("gridSize");
        string gridSize = GlobalUtils.GetNonNullString();
        while (!Regex.IsMatch(gridSize, @"^\d+[,. ]+\d+$"))
        {
            InvalidEntryFormat();
            gridSize = GlobalUtils.GetNonNullString();
        }
        return gridSize;
    }

    public static void RobotPrompt(string type)
    {
        switch (type)
        {
            case "robotPos":
                Console.Clear();
                Console.Write("Digite o ponto de origem e o sentido do robô (x, y, N|S|L|O) -> ");
                break;
            case "instSequence":
                Console.Clear();
                Console.Write("Digite a sequência instruções do robo (D, E ou M) -> ");
                break;
            case "gridSize":
                Console.Clear();
                Console.Write("Digite o tamanho do grid (x, y) -> ");
                break;
        }
    }

    public static void CurrentRobotSettings(int selectedRobot, string currentOriginPos, string currentInstructions)
    {
        Console.WriteLine();
        Console.WriteLine($"Robo selecionado: {selectedRobot}");
        Console.WriteLine($"Ponto de origem: {currentOriginPos}");
        Console.WriteLine($"Instruções na memória: {currentInstructions}");
        Console.WriteLine();
    }

    public static void InvalidInstructuions(string direction)
    {
        Console.Clear();
        Console.WriteLine($"Insturções inválidas, robô tentou sair do grid pelo {direction}");
    }

    public static void InvalidEntryFormat()
    {
        Console.Write("Formato de entrada inválido, tente novamente -> ");
    }

    public static void RobotInfo(string type)
    {
        switch (type)
        {
            case "noGrid":
                Console.Clear();
                Console.WriteLine("O grid ainda não foi definido!");
                GlobalUtils.AnyKeyPrompt();
                break;
            case "noInstructions":
                Console.Clear();
                Console.WriteLine("As instruções ainda não foram definidas!");
                GlobalUtils.AnyKeyPrompt();
                break;
            case "noPos":
                Console.Clear();
                Console.WriteLine("O robô ainda não foi posicionado!");
                GlobalUtils.AnyKeyPrompt();
                break;
            case "showPos":
                Console.Clear();
                Console.WriteLine("Instruções executadas.");
                Console.WriteLine();
                Console.WriteLine("Posição final do robo: " + Robot.GetCurrentPosition());
                break;
        }
    }
}
