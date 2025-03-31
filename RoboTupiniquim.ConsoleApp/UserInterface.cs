using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoboTupiniquim.ConsoleApp;

class UserInterface
{
    static string[] menuOptions = { "Definir Grid", "Controlar Robôs", "Informações", "Sair" };
    static bool exitOptionSelected = false;
    static Robot[] robots;
    static Robot activeRobot;
    static int selectedRobot = 0;

    public static void ShowMenu()
    {
        GetRobotsNumber();
        string gridSize = "Não definido";
        int selectedOption = 0;
        while (!exitOptionSelected)
        {
            RenderMenu("Robô Tupiniquim", menuOptions, selectedOption);
            GlobalUtils.ShowGridSize(gridSize);
            switch (MenuNavigation(menuOptions.Length, ref selectedOption))
            {
                case 0:
                    Grid.SetGridSize(RobotUtils.GetValidGridSize());
                    gridSize = $"{Grid.GetSizeX()}, {Grid.GetSizeY()}";
                    break;
                case 1:
                    RobotMenu();
                    break;
                case 2:
                    InfoScreen();
                    break;
                case 3:
                    if (GlobalUtils.LeavePrompt())
                    {
                        exitOptionSelected = true;
                    }
                    break;
            }
        }
    }

    public static void RobotMenu()
    {
        string[] menuOptions = { "Definir Ponto de Origem", "Enviar Instruções", "Executar Instruções", "Trocar Robô", "Sair" };
        int selectedOption = 0;
        string currentInstructions = "Sem instruções";
        string currentOriginPos = "Não definido";
        bool exitOptionSelected = false;

        while (!exitOptionSelected)
        {
            RenderMenu("Central de Controle", menuOptions, selectedOption);
            RobotUtils.CurrentRobotSettings(selectedRobot + 1, currentOriginPos, currentInstructions);

            switch (MenuNavigation(menuOptions.Length, ref selectedOption))
            {
                case 0:
                    if (!Grid.exists)
                    {
                        RobotUtils.RobotInfo("noGrid", activeRobot);
                        break;
                    }
                    activeRobot.SetPosition(RobotUtils.GetValidRobotPosition());
                    currentOriginPos = activeRobot.GetCurrentPosition();
                    break;

                case 1:
                    if (!activeRobot.positionSet)
                    {
                        RobotUtils.RobotInfo("noPos", activeRobot);
                        break;
                    }
                    currentInstructions = RobotUtils.GetValidInstructions();
                    break;

                case 2:
                    if (currentInstructions == "Sem instruções")
                    {
                        RobotUtils.RobotInfo("noInstructions", activeRobot);
                        GlobalUtils.AnyKeyPrompt();
                        break;
                    }
                    activeRobot.ExecuteInstructions(currentInstructions, out bool validInstructions);
                    if (validInstructions)
                        RobotUtils.RobotInfo("showPos", activeRobot);
                    GlobalUtils.AnyKeyPrompt();
                    Reset();
                    break;

                case 3:
                    selectedRobot = (selectedRobot + 1) % robots.Length;
                    activeRobot = robots[selectedRobot];
                    Reset();
                    break;

                case 4:
                    exitOptionSelected = true;
                    break;
            }
        }

        void Reset()
        {
            currentInstructions = "Sem instruções";
            currentOriginPos = "Não definido";
            activeRobot.ResetPos();
        }
    }

    public static void RenderMenu(string title, string[] options, int selectedOption)
    {
        GlobalUtils.Header(title);
        for (int i = 0; i < options.Length; i++)
        {
            string prefix = (i == selectedOption) ? "   >" : "    ";
            Console.WriteLine(prefix + options[i]);
        }
    }

    public static int MenuNavigation(int menuLength, ref int selectedOption)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.UpArrow)
            selectedOption = (selectedOption == 0) ? menuLength - 1 : selectedOption - 1;
        else if (key.Key == ConsoleKey.DownArrow)
            selectedOption = (selectedOption == menuLength - 1) ? 0 : selectedOption + 1;
        else if (key.Key == ConsoleKey.Enter)
            return selectedOption;
        return -1;
    }

    public static void GetRobotsNumber()
    {
        Console.Clear();
        Console.Write("Digite quantos robôs você quer controlar -> ");
        int robotCount;

        while (!int.TryParse(Console.ReadLine(), out robotCount) || robotCount <= 0)
            Console.Write("Número inválido, tente novamente -> ");

        robots = new Robot[robotCount];

        for (int i = 0; i < robotCount; i++)
        {
            robots[i] = new Robot();
        }

        activeRobot = robots[0];
    }

    public static void InfoScreen()
    {
        Console.Clear();
        Console.WriteLine("=== Tupiniquim I - Expedição a Marte ===");
        Console.WriteLine();
        Console.WriteLine("A AEB (Agência Espacial Brasileira) recrutou a Academia do Programador");
        Console.WriteLine("para desenvolver o software de navegação do robô Tupiniquim I.");
        Console.WriteLine();
        Console.WriteLine("O robô explorará uma área retangular de Marte, coletando dados com suas câmeras.");
        Console.WriteLine("Sua posição é representada por coordenadas (X, Y) e uma direção (N, S, L, O).");
        Console.WriteLine();
        Console.WriteLine("=== Comandos ===");
        Console.WriteLine("E - Gira 90° para a esquerda");
        Console.WriteLine("D - Gira 90° para a direita");
        Console.WriteLine("M - Move-se para frente na direção atual");
        Console.WriteLine();
        Console.WriteLine("Exemplo: Posição inicial (0,0,N). Comando 'M' -> nova posição (0,1,N).");
        GlobalUtils.AnyKeyPrompt();
    }
}
