using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

class GlobalUtils
{

    public static string GetValidIntructions()
    {
        Console.Write("Digite a sequência instruções do robo (D, E ou M) -> ");
        string instructions = GetNonNullString();
        while (!Regex.IsMatch(instructions, @"[dem]+", RegexOptions.IgnoreCase))
        {
            Console.Write("Formato de entrada inválido (formato aceito: EMMDMEMEMDM), tente novamente -> ");
            instructions = GetNonNullString();
        }
        return instructions;
    }

    public static string GetValidGridSize()
    {
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

    public static int GetInt()
    {
        int number;
        Console.Write("Digite um número -> ");
        while (!int.TryParse(Console.ReadLine(), out number))
            Console.Write("Número inválido, tente novamente -> ");
        return number;
    }
}
