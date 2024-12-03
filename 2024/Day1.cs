public class Day1
{
    public int CalcDif()
    {
        var input = File.ReadAllText("values.txt");

        List<int> left_values = new List<int>();
        List<int> right_values = new List<int>();

        int sum = 0;

        foreach (var line in input.Split('\n'))
        {
            left_values.Add(int.Parse(line.Substring(0, 5)));
            right_values.Add(int.Parse(line.Substring(8, 5)));
        }

        left_values.Sort();
        right_values.Sort();

        for (int x = 0; x < right_values.Count; x++)
        {
            if (left_values[x] < right_values[x])
                sum += right_values[x] - left_values[x];
            else
                sum += left_values[x] - right_values[x];
        }

        return sum;
    }

    public int calcSimilarityScore()
    {
        var input = File.ReadAllText("values.txt");

        List<int> left_values = new List<int>();
        List<int> right_values = new List<int>();

        int similarityScore = 0;

        foreach (var line in input.Split('\n'))
        {
            left_values.Add(int.Parse(line.Substring(0, 5)));
            right_values.Add(int.Parse(line.Substring(8, 5)));
        }

        left_values.Sort();
        right_values.Sort();

        for (int x = 0; x < left_values.Count; x++)
        {
            int count = right_values.Count(n => n == left_values[x]);
            similarityScore += count * left_values[x];
        }


        return similarityScore;

    }

}