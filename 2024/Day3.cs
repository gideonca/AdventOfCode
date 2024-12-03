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

            var first_num_regex = new Regex("\\(\\s*(\\d+)\\s*,");
            var second_num_regex = new Regex(",\\s*(\\d+)\\s*\\)");

            var first_num = int.Parse(first_num_regex.Match(match.ToString()).Groups[1].Value.ToString());
            var second_num = int.Parse(second_num_regex.Match(match.ToString()).Groups[1].Value.ToString());

            product += first_num * second_num;

        }

        return product;
    }
}