using System.Net.Http.Headers;
using System.Text.RegularExpressions;

class Day3
{
    private string data = File.ReadAllText("./data/day3.txt");

    public int ParseData()
    {
        string pattern = @"mul\(\d+,\d+\)";
        MatchCollection matches = Regex.Matches(data, pattern);
        return GetProduct(matches.Select(m => m.Value).ToList());;
    }

    public int ParseDataRefined()
    {
        string pattern = @"(do\(\)|don't\(\)|mul\(\d+,\d+\))";
        MatchCollection matches = Regex.Matches(data, pattern);

        bool isEnabled = true;  // Start with mul instructions enabled
        List<string> enabledMulInstructions = new List<string>(); // Create a list to store enabled instructions

        foreach (Match match in matches)
        {
            string value = match.Value;
            if (value == "do()")
            {
                isEnabled = true;
            }
            else if (value == "don't()")
            {
                isEnabled = false;
            }
            else if (value.StartsWith("mul("))
            {
                if (isEnabled)
                {
                    enabledMulInstructions.Add(value);
                }
            }
        }

        return GetProduct(enabledMulInstructions);
    }

    private int GetProduct(List<string> matches)
    {
        int product = 0;
        foreach(var match in matches)
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