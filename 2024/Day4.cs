using System.Collections;

class Day4
{
    private string[] data = File.ReadAllLines("./data/day4_demo.txt");
#region Phase1
    private bool SearchWord(char[,] grid, string word, int row, int col, int rowDir, int colDir)
    {
        int wordLen = word.Length;
        for (int i = 0; i < wordLen; i++)
        {
            int newRow = row + i * rowDir;
            int newCol = col + i * colDir;

            if (newRow < 0 || newCol < 0 || newRow >= grid.GetLength(0) || newCol >= grid.GetLength(1))
                return false;
            
            if (grid[newRow, newCol] != word[i])
                return false;
        }
        return true;
    }

    public int CountWordOccurrences(string word)
    {
        int[] rowDir = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] colDir = { -1, 0, 1, -1, 1, -1, 0, 1 };
        int count = 0;
        int cols, rows;
        char[,] wordMatrix;
        GetWordMatrix(out cols, out rows, out wordMatrix);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (wordMatrix[row, col] == word[0])
                {
                    for (int dir = 0; dir < 8; dir++)
                    {
                        if (SearchWord(wordMatrix, word, row, col, rowDir[dir], colDir[dir])) count++;
                    }
                }
            }
        }
        return count;
    }
#endregion

#region Phase 2
        public int CountWordInXShape(string word)
    {
        int cols, rows;
        char[,] wordMatrix;
        GetWordMatrix(out cols, out rows, out wordMatrix);
        int count = 0;

        for (int row = 1; row < rows - 2; row++)
        {
            for (int col = 1; col < cols - 2; col++)
            {
                if (wordMatrix[row, col] == 'A')
                {

                    char upperLeft = wordMatrix[row - 1, col - 1];
                    char lowerRight = wordMatrix[row + 1, col + 1];
                    char upperRight = wordMatrix[row -1, col + 1];
                    char lowerLeft = wordMatrix[row + 1, col - 1];


                    if((wordMatrix[row - 1, col - 1] == 'M' && wordMatrix[row + 1, col + 1] == 'S') || 
                    (wordMatrix[row - 1, col - 1] == 'S' && wordMatrix[row + 1, col + 1] == 'M') || 
                    (wordMatrix[row - 1, col + 1] == 'M' && wordMatrix[row + 1, col - 1] == 'S') ||
                    (wordMatrix[row - 1, col + 1] == 'S' && wordMatrix[row + 1, col - 1] == 'M'))
                    {
                        wordMatrix[row, col] = '.';
                        wordMatrix[row - 1, col - 1] = '.';
                        wordMatrix[row + 1, col + 1] = '.';
                        wordMatrix[row -1, col + 1] = '.';
                        wordMatrix[row + 1, col - 1] = '.';
                        count++;
                    }
                }
            }
        }

        return count;
    }
#endregion

    private void GetWordMatrix(out int cols, out int rows, out char[,] wordMatrix)
    {
        cols = data.Count();
        rows = data[0].Length;
        wordMatrix = new char[rows, cols];

        // Populate character matrix
        int row = 0;
        foreach (var line in data)
        {
            for (int i = 0; i < line.ToArray().Length; i++)
            {
                wordMatrix[row, i] = line[i];
            }
            row++;
        }
    }
}