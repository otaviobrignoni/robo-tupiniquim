using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

class GlobalUtils
{

    public static string GetValidRobotPosition()
    {
        Console.Clear();
        Console.Write("Digite o ponto de origem e o sentido do robô (x, y, N|S|L|O) -> ");
        string robotPosition = GetNonNullString();
        while (!Regex.IsMatch(robotPosition, @"^\d+[,. ]+\d+[,. ]+[nslo]$", RegexOptions.IgnoreCase))
        {
            Console.Write("Formato de entrada inválido, tente novamente -> ");
            robotPosition = GetNonNullString();
        }
        return robotPosition;
    }

    public static string GetValidIntructions()
    {
        Console.Clear();
        Console.Write("Digite a sequência instruções do robo (D, E ou M) -> ");
        string instructions = GetNonNullString();
        while (!Regex.IsMatch(instructions, @"^[dem]+?$", RegexOptions.IgnoreCase))
        {
            Console.Write("Formato de entrada inválido (formato aceito: EMMDMEMEMDM), tente novamente -> ");
            instructions = GetNonNullString();
        }
        return instructions.ToUpper();
    }

    public static string GetValidGridSize()
    {
        Console.Clear();
        Console.Write("Digite o tamanho do grid (\"x, y\") -> ");
        string gridSize = GetNonNullString();
        while (!Regex.IsMatch(gridSize, @"^\d+[,. ]+\d+$"))
        {
            Console.Write("Formato de entrada inválido, tente novamente -> ");
            gridSize = GetNonNullString();
        }
        return gridSize;
    }

    static string GetNonNullString()
    {
        string @string = Console.ReadLine()!;
        while (string.IsNullOrWhiteSpace(@string))
        {
            Console.Write("Entrada inválida, tente novamente -> ");
            @string = Console.ReadLine()!;
        }
        return @string;
    }
    
    public class Text
    {

    }
}
