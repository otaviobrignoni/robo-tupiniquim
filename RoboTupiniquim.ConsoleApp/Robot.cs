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

    public static void SetRobotPosition(string robotPosition)
    {
        string[] robotPositionArray = Regex.Split(robotPosition, @"[,. ]+");
        posX = int.Parse(robotPositionArray[0]);
        posY = int.Parse(robotPositionArray[1]);
        direction = robotPositionArray[2][0];
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
                            if (posX + 1 > gridSizeX)
                            {
                                Console.WriteLine("Insturções Inválidas");
                                return;
                            }
                            else
                                posX++;
                            break;
                        case 'S':
                            if (posX - 1 < 0)
                            {
                                Console.WriteLine("Insturções Inválidas");
                                return;
                            }
                            else
                                posX--;
                            break;
                        case 'L':
                            if (posY + 1 > gridSizeY)
                            {
                                Console.WriteLine("Insturções Inválidas");
                                return;
                            }
                            else
                                posY++;
                            break;
                        case 'O':
                            if (posY - 1 < 0)
                            {
                                Console.WriteLine("Insturções Inválidas");
                                return;
                            }
                            else
                                posY--;
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
}
