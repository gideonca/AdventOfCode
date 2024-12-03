using System.Text.RegularExpressions;

class Day3
{
    // TODO: Regex through text file
    private string data = File.ReadAllText("./data/day3.txt");

    public int ParseData()
    {
        int product = 0;
        var regex = new Regex("mul\\(\\d+,\\d+\\)");
        foreach(var match in regex.Matches(data))
        {

        }

        return product;
    }
}