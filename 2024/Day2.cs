using System.ComponentModel.DataAnnotations;

class Day2
{
    private string[] Lines = File.ReadAllLines("./data/day2.txt");

    public int CheckSafetyWithoutDampener()
    {
        int numberOfSafeReactors = 0;
        int safetyCount = 0;
        foreach(var line in Lines)
        {
            int[] intArray = line.Split(" ").Select(int.Parse).ToArray();
            numberOfSafeReactors += CheckSafety(intArray);
        }
        return numberOfSafeReactors;
    }

    public int CheckSafetyWithDampener()
    {
        int safety = 0;
        foreach(var line in Lines)
        {
            int[] intArray = line.Split(" ").Select(int.Parse).ToArray(); // Source of truth array
            int[] clonedArray = (int[])intArray.Clone(); // Use clone array to remove elements
            
            int isSafe = CheckSafety(clonedArray);
            if(isSafe == 0) { // Initial array is not safe
                for(int x = 0; x < clonedArray.Count(); x++)
                {
                    // Remove element by element, check for safety
                    List<int> clone = clonedArray.ToList();
                    clone.RemoveAt(x);
                    if(CheckSafety(clone.ToArray()) == 1) {
                        safety++;
                        break;
                    }
                    clonedArray = (int[])intArray.Clone(); // reset cloned array
                }
            } else {
                safety += CheckSafety(intArray);
            }
        }
        return safety;
    }

    private int CheckSafety(int[] list)
    {
        int safe = 0;
        int safetyCount = 0;

        int order = GetListOrder(list);
        if(order != 0) {
            for(int x = 0; x < list.Count() - 1; x++)
            {
                int dif = Math.Abs(list[x] - list[x + 1]);
                    
                if(dif <= 3 && dif > 0)
                {
                    safetyCount++;
                }
            }

            if(safetyCount == list.Count() - 1)
                safe++;
        }

        return safe;
    }

    private int GetListOrder(int[] values)
    {
        if(values.SequenceEqual(values.Order()))
            return 1;
        else if(values.SequenceEqual(values.OrderDescending()))
            return 2;
        return 0;
    }
}