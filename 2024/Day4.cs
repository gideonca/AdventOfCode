class Day4
{
    private string[] data = File.ReadAllLines("./data/day4.txt");

    public int CountWords_Phase1()
    {
        int totalFound = 0;

        int cols = data.Count();
        int rows = data[0].Length;

        char[,] wordMatrix = new char[rows,cols];

        return totalFound;
    }
}