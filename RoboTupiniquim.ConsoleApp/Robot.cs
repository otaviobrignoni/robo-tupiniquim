namespace RoboTupiniquim.ConsoleApp;

class Robot
{
    static int gridX;
    static int gridY;
    static int robotPosX;
    static int robotPosY;
    static char robotDirection = 'N';

    public static void ExecuteInstructions(string instructions)
    {
        for (int i = 0; i < instructions.Length; i++)
        {
            switch (instructions[i])
            {
                case 'M':
                    switch (robotDirection)
                    {
                        case 'N':
                            if (robotPosX + 1 > gridX)
                            {
                                Console.WriteLine("Insturções Inválidas");
                                return;
                            }
                            else
                                robotPosX++;
                            break;
                        case 'S':
                            if (robotPosX - 1 < 0)
                            {
                                Console.WriteLine("Insturções Inválidas");
                                return;
                            }
                            else
                                robotPosX--;
                            break;
                        case 'L':
                            if (robotPosY + 1 > gridY)
                            {
                                Console.WriteLine("Insturções Inválidas");
                                return;
                            }
                            else
                                robotPosY++;
                            break;
                        case 'O':
                            if (robotPosY - 1 < 0)
                            {
                                Console.WriteLine("Insturções Inválidas");
                                return;
                            }
                            else
                                robotPosY--;
                            break;
                    }
                    break;
                case 'E':
                    switch (robotDirection)
                    {
                        case 'N':
                            robotDirection = 'O';
                            break;
                        case 'S':
                            robotDirection = 'L';
                            break;
                        case 'L':
                            robotDirection = 'N';
                            break;
                        case 'O':
                            robotDirection = 'S';
                            break;

                    }
                    break;
                case 'D':
                    switch (robotDirection)
                    {
                        case 'N':
                            robotDirection = 'L';
                            break;
                        case 'S':
                            robotDirection = 'O';
                            break;
                        case 'L':
                            robotDirection = 'S';
                            break;
                        case 'O':
                            robotDirection = 'N';
                            break;
                    }
                    break;
            }
        }
        Console.WriteLine($"{robotPosX}, {robotPosY}, {robotDirection}");
    }
}
