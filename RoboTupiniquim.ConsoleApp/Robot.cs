using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

class Robot
{

    public Robot()
    {

    }

    static int posX;
    static int posY;
    static char direction;
    public static bool positionSet = false;

    public static void SetRobotPosition(string robotPosition)
    {
        string[] robotPositionArray = Regex.Split(robotPosition, @"[,. ]+");
        posX = int.Parse(robotPositionArray[0]);
        posY = int.Parse(robotPositionArray[1]);
        direction = robotPositionArray[2].ToUpper()[0];
        positionSet = true;
    }

    public static void ExecuteInstructions(string instructions)
    {
        int gridSizeX = Grid.GetSizeX();
        int gridSizeY = Grid.GetSizeY();
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case 'M':
                    switch (direction)
                    {
                        case 'N':
                            if (posY + 1 > gridSizeY)
                            {
                                Console.WriteLine("Insturções inválidas, robô tentou sair do grid pelo norte");
                                return;
                            }
                            else
                                posY++;
                            break;
                        case 'S':
                            if (posY - 1 < 0)
                            {
                                Console.WriteLine("Insturções inválidas, robô tentou sair do grid pelo sul");
                                return;
                            }
                            else
                                posY--;
                            break;
                        case 'L':
                            if (posX + 1 > gridSizeY)
                            {
                                Console.WriteLine("Insturções inválidas, robô tentou sair do grid pelo leste");
                                return;
                            }
                            else
                                posX++;
                            break;
                        case 'O':
                            if (posX - 1 < 0)
                            {
                                Console.WriteLine("Insturções inválidas, robô tentou sair do grid pelo oeste");
                                return;
                            }
                            else
                                posX--;
                            break;
                    }
                    break;
                case 'E':
                    switch (direction)
                    {
                        case 'N':
                            direction = 'O';
                            break;
                        case 'S':
                            direction = 'L';
                            break;
                        case 'L':
                            direction = 'N';
                            break;
                        case 'O':
                            direction = 'S';
                            break;

                    }
                    break;
                case 'D':
                    switch (direction)
                    {
                        case 'N':
                            direction = 'L';
                            break;
                        case 'S':
                            direction = 'O';
                            break;
                        case 'L':
                            direction = 'S';
                            break;
                        case 'O':
                            direction = 'N';
                            break;
                    }
                    break;
            }
        }
    }

    public static string GetCurrentPosition()
    {
        return $"{posX}, {posY}, {direction}";
    }

    
}
