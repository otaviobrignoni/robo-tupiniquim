using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

class Robot
{

    public Robot()
    {
        positionSet = false;
    }

    private int posX;
    private int posY;
    private char direction;
    public bool positionSet { get; private set; }

    public void SetPosition(string robotPosition)
    {
        string[] robotPositionArray = Regex.Split(robotPosition, @"[,. ]+");
        posX = int.Parse(robotPositionArray[0]);
        posY = int.Parse(robotPositionArray[1]);
        direction = robotPositionArray[2].ToUpper()[0];
        positionSet = true;
    }

    public string GetCurrentPosition()
    {
        return $"{posX}, {posY}, {direction}";
    }

    public void ResetPos()
    {
        posX = -1;
        posY = -1;
        direction = ' ';
        positionSet = false;
    }

    public void ExecuteInstructions(string instructions, out bool validInstructions)
    {
        validInstructions = true;
        foreach (char command in instructions)
        {
            if (!ProcessCommand(command))
            {
                validInstructions = false;
                return;
            }
        }
    }

    private bool ProcessCommand(char command)
    {
        int gridSizeX = Grid.GetSizeX();
        int gridSizeY = Grid.GetSizeY();
        switch (command)
        {
            case 'M':
                return Move(gridSizeX, gridSizeY);
            case 'E':
                RotateLeft();
                return true;
            case 'D':
                RotateRight();
                return true;
        }
        return false;
    }

    private bool Move(int gridSizeX, int gridSizeY)
    {
        switch (direction)
        {
            case 'N':
                if (posY + 1 > gridSizeY) 
                    return false; 
                posY++; 
                break; 
            case 'S': 
                if (posY - 1 < 0) 
                    return false; 
                posY--; 
                break;
            case 'L': 
                if (posX + 1 > gridSizeX) 
                    return false; 
                posX++; 
                break;
            case 'O': 
                if (posX - 1 < 0) 
                    return false; 
                posX--; 
                break;
        }
        return true;
    }

    private void RotateLeft()
    {
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
    }

    private void RotateRight()
    {
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
    }

}
