using System.Text.RegularExpressions;

namespace RoboTupiniquim.ConsoleApp;

class Grid
{
    static int axisSizeX;
    static int axisSizeY;
    public static bool exists = false;
    
    public static void SetGridSize(string axisSizes)
    {
        string[] axisSizeArray = Regex.Split(axisSizes, @"[,. ]+");
        axisSizeX = int.Parse(axisSizeArray[0]);
        axisSizeY = int.Parse(axisSizeArray[1]);
        exists = true;
    }
    
    public static int GetSizeX()
    {
        return axisSizeX;
    }
    
    public static int GetSizeY()
    {
        return axisSizeY;
    }
}
    