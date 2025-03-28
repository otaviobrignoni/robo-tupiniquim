namespace RoboTupiniquim.ConsoleApp
{
    class GlobalUtils
    {
        public static void Header(string title)
        {
            const int menuWidth = 28;
            int padding = (menuWidth - title.Length) / 2;
            Console.Clear();
            Console.WriteLine("┌" + new string('─', menuWidth) + "┐");
            Console.WriteLine("│" + title.PadLeft(padding + title.Length).PadRight(menuWidth) + "│");
            Console.WriteLine("└" + new string('─', menuWidth) + "┘");
            Console.WriteLine();
        }

        public static string GetNonNullString()
        {
            string @string = Console.ReadLine()!;
            while (string.IsNullOrWhiteSpace(@string))
            {
                InvalidEntry();
                @string = Console.ReadLine()!;
            }
            return @string;
        }

        public static void AnyKeyPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public static void InvalidEntry()
        {
            Console.Write("Entrada inválida, tente novamente -> ");
        }

        public static bool LeavePrompt()
        {
            Console.Clear();
            Console.Write("Você realmente quer sair? (S/N) -> ");
            string userInput = Console.ReadLine()!;
            while (userInput != "S" && userInput != "N" && userInput != "s" && userInput != "n" || (userInput == null))
            {
                Console.Write("Opção inválida, tente novamente -> ");
                userInput = Console.ReadLine()!;
            }
            return userInput.ToUpper()[0] == 'S';
        }

        public static void ShowGridSize(string gridSize)
        {
            Console.WriteLine();
            Console.WriteLine($"Grid atual: {gridSize}");
        }
    }
}
