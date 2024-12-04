class Day4
{
    private string[] data = File.ReadAllLines("./data/day4.txt");

    public int CountWords_Phase1()
    {
        int totalFound = 0;

        int cols = data.Count();
        int rows = data[0].Length;

        char[,] wordMatrix = new char[rows,cols];

        int currentXPos = 0;
        int currentYPos = 0;

        // TODO: 
        // Do a while loop? do { } while { currentXPos < rows && currentYPos < cols}
        // look at top left corner (0,0)
        // check character, if it's X check adjacent (0,1) (1,0) (1,1) for M
        // check 

        return totalFound;
    }
}