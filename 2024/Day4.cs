using System.Collections;

class Day4
{
    private string[] data = File.ReadAllLines("./data/day4_demo.txt");

    public int CountWords_Phase1()
    {
        int totalFound = 0;

        int cols = data.Count();
        int rows = data[0].Length;

        char[,] wordMatrix = new char[rows,cols];
        var dataArray = data.ToArray();

        // Populate character matrix
        int row = 0;
        foreach(var line in data)
        {
            for(int i = 0; i < line.ToArray().Length; i++)
            {
                wordMatrix[row, i] = line[i];
            }
        }

        int currentXPos = 0;
        int currentYPos = 0;

        // TODO: 
        // Do a while loop? do { } while { currentXPos < rows && currentYPos < cols}
        // look at top left corner (0,0)
        // check character, if it's X check adjacent (0,1) (1,0) (1,1) for M
        // check 

        for(int r = 0; r < rows; r++)
        {
            for(int c = 0; c < cols; c++)
            {
                if(wordMatrix[r,c].Equals('X'))
                {
                    currentXPos = r;
                    currentYPos = c;
                    string direction = "";
                    if(r == 0) // special condition for top row
                    {
                        if(c == 0) // Check for top left beign X
                        {
                            // There can only be 8 potential directions, need to start at the left and go counter clockwise to find the letter M
                        }
                    }
                }
            }
        }

        return totalFound;
    }
}