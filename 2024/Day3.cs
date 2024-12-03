using System.Net.Http.Headers;
using System.Text.RegularExpressions;

class Day3
{
    // TODO: Regex through text file
    private string data = File.ReadAllText("./data/day3.txt");

    public int ParseData()
    {
        // Value = 153469856
        string pattern = @"mul\(\d+,\d+\)";
        MatchCollection matches = Regex.Matches(data, pattern);
        return GetProduct(matches);;
    }

    public int ParseDataRefined()
    {
        // Bad value = 6589693

        // Must use look aheads and look behinds
        // string pattern = @"do\(\)\s+(.*?)(?:\s+don't\(\)|\s+do\(\))";
        // string pattern = @"do\(\)(?:(?!don't\(\)).)*?mul\(\d+,\d+\)"; // use positive look behind
        // string pattern = @"do\((.*?)don't\(";
        // MatchCollection matches = Regex.Matches(data, pattern);

        // return GetProduct(matches);

        string pattern = @"(do\(\)|don't\(\)|mul\(\d+,\d+\))";
        MatchCollection matches = Regex.Matches(data, pattern);

        bool isEnabled = true;  // Start with mul instructions enabled
        List<string> enabledMulInstructions = new List<string>();

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

        int product = 0;
        foreach (string mul in enabledMulInstructions)
        {
            var first_num_regex = new Regex("\\(\\s*(\\d+)\\s*,");
            var second_num_regex = new Regex(",\\s*(\\d+)\\s*\\)");

            var first_num = int.Parse(first_num_regex.Match(mul.ToString()).Groups[1].Value.ToString());
            var second_num = int.Parse(second_num_regex.Match(mul.ToString()).Groups[1].Value.ToString());

            product += first_num * second_num;
        }

        return product;
    }

    private int GetProduct(MatchCollection matches)
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