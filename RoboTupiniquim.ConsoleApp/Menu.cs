namespace RoboTupiniquim.ConsoleApp;

class Menu
{
    const int menuWidth = 28;
    static string[] menuOptions = { "     Controlar Robôs", "     Informações", "     Sair" };
    static int selectedOption = 0;
    static bool exitOptionSelected = false;

    public static void Show()
    {
        while (!exitOptionSelected)
        {
            string title = "Robô Tupiniquim";
            int padding = (menuWidth - title.Length) / 2;
            Console.Clear();
            Console.WriteLine("┌" + new string('─', menuWidth) + "┐");
            Console.WriteLine("│" + title.PadLeft(padding + title.Length).PadRight(menuWidth) + "│");
            Console.WriteLine("└" + new string('─', menuWidth) + "┘");
            Console.WriteLine();
            for (int i = 0; i < menuOptions.Length; i++)
            {
                int optionPadding = (menuWidth - menuOptions[i].Length) / 2;
                if (i == selectedOption)
                {
                    string temp = "    >" + menuOptions[i].Substring(5);
                    menuOptions[i] = temp;
                }
                else
                {
                    string temp = "     " + menuOptions[i].Substring(5);
                    menuOptions[i] = temp;
                }
                Console.WriteLine(menuOptions[i]);
            }
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                selectedOption = (selectedOption == 0) ? menuOptions.Length - 1 : selectedOption - 1;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                selectedOption = (selectedOption == menuOptions.Length - 1) ? 0 : selectedOption + 1;
            }
            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                switch (selectedOption)
                {
                    case 0:
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine();
                        break;
                    case 2:
                        if (LeavePrompt())
                        {
                            exitOptionSelected = true;
                            break;
                        } 
                        break;
                         
                }
            }
        }
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
}
