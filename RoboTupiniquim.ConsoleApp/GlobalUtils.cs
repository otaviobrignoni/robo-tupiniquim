using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

class GlobalUtils
{
    
    public static string GetValidGridSize()
    {
        Console.Write("Digite o tamanho do grid (\"x, y\") -> ");
        string gridSize = GetNonNullString();
        while (!Regex.IsMatch(gridSize!, @"^-?\d+[,. ]+-?\d+$"))
        {
            Console.Write("Formato de entrada inválido, tente novamente -> ");
            gridSize = GetNonNullString();
            
        }
        string GetNonNullString()
        {
            string @string = Console.ReadLine()!;
            while (string.IsNullOrWhiteSpace(@string))
            {
                Console.Write("Entrada inválida, tente novamente -> ");
                @string = Console.ReadLine()!;
            }
            return @string;
        }
        return gridSize;
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
