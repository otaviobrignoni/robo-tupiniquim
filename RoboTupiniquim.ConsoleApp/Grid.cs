namespace RoboTupiniquim.ConsoleApp;

class Grid
{
    static int axisSizeX;
    static int axisSizeY;
    
    public static void SetGridSize(string axisSizes)
    {
        string[] axisSizeArray = axisSizes.Split(' ');
        axisSizeX = Convert.ToInt32(axisSizeArray[0]);
        axisSizeY = Convert.ToInt32(axisSizeArray[1]);
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
