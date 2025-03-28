using System.Reflection;

namespace RoboTupiniquim.ConsoleApp;

class UserInteraction
{
    const int menuWidth = 28;
    static string[] menuOptions = { "     Definir Grid", "     Controlar Robôs", "     Informações", "     Sair" };
    static int selectedOption = 0;
    static bool exitOptionSelected = false;

    public static void ShowMenu()
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
                        Grid.SetGridSize(GlobalUtils.GetValidGridSize());
                        break;
                    case 1:
                        RobotMenu();
                        break;
                    case 2:
                        break;
                    case 3:
                        if (LeavePrompt())
                        {
                            exitOptionSelected = true;
                        }
                        break;
                }
            }
        }
    }
    public static void RobotMenu()
    {
        const int menuWidth = 28;
        string[] menuOptions = { "     Parâmetros Iniciais", "     Enviar Instuções", "     Executar Instuções", "     Selecionar Robô 2", "     Sair" };
        int selectedOption = 0;
        int selectedRobot = 1;
        string currentInstructions = "Sem instruções";
        string currentOriginPos = "Não definido";
        bool exitOptionSelected = false;
        while (!exitOptionSelected)
        {
            Console.Clear();
            string title = "Central de controle";
            int padding = (menuWidth - title.Length) / 2;
            Console.Clear();
            Console.WriteLine("┌" + new string('─', menuWidth) + "┐");
            Console.WriteLine("│" + title.PadLeft(padding + title.Length).PadRight(menuWidth) + "│");
            Console.WriteLine("└" + new string('─', menuWidth) + "┘");
            Console.WriteLine($"Robo selecionado: {selectedRobot}");
            Console.WriteLine($"Ponto de origem: {currentOriginPos}");
            Console.WriteLine($"Instruções na memória: {currentInstructions}");
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
                        if (Grid.exists)
                        {
                            Robot.SetRobotPosition(GlobalUtils.GetValidRobotPosition());
                            currentOriginPos = Robot.GetCurrentPosition();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("O grid ainda não foi defindo!");
                            AnyKeyPrompt();
                            break;
                        }
                    case 1:
                        if (Robot.positionSet)
                        {
                            currentInstructions = GlobalUtils.GetValidIntructions();
                            Console.WriteLine("Instruções enviadas para a memória");
                            AnyKeyPrompt();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("O robo ainda não foi posicionado!");
                            AnyKeyPrompt();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        if (currentInstructions == "Sem instruções")
                        {
                            Console.WriteLine("As instruções ainda não foram definidas!");
                        } 
                        else
                        {
                            
                            Console.WriteLine("Executando instruções...");
                            Thread.Sleep(750);
                            Robot.ExecuteInstructions(currentInstructions);
                            Console.WriteLine("Posição final do robo: " + Robot.GetCurrentPosition());
                        }
                        AnyKeyPrompt();
                        break;
                    case 3:
                        if (selectedRobot == 1)
                        {
                            menuOptions[3] = "     Selecionar Robô 1";
                            selectedRobot = 2;
                        }
                        else
                        {
                            menuOptions[3] = "     Selecionar Robô 2";
                            selectedRobot = 1;
                        }
                        break;
                    case 4:
                        exitOptionSelected = true;
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
    public static void AnyKeyPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

}
