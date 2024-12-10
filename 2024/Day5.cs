class Day5
{
    private string[] Lines = File.ReadAllLines("./data/day5demo.txt");

    public List<string> GetListOfRules()
    {
        List<string> rules = new List<string>();
        int count = 1;
        foreach(var line in Lines)
        {
            if(string.IsNullOrWhiteSpace(line)) break;
            string[] parts = line.Split("|");
            string rule = parts[0] + " " + parts[1];
            rules.Add(rule);
            count++;
        }

        List<string> printMessages = new List<string>();
        for(int x = count; x < Lines.Count(); x++)
        {
            printMessages.Add(Lines[x]);
        }

        Dictionary<string, string[]> ruleDict = ConvertRuleToDictionary(rules);

        var validRules = GetValidPrintingJobs(ruleDict, printMessages);

        return rules;
    }

    private Dictionary<string, string[]> ConvertRuleToDictionary(List<string> rules)
    {
        Dictionary<string, string[]> ruleDict = new Dictionary<string, string[]>();

        foreach(string rule in rules)
        {
            string[] parts = rule.Split(" ");
            if(ruleDict.ContainsKey(parts[0]))
            {
                // string[] ruleValues = ruleDict[parts[0]];
                List<string> ruleValues = ruleDict[parts[0]].ToList();
                ruleValues.Add(parts[1]);
                ruleDict[parts[0]] = ruleValues.ToArray();
            } else {
                ruleDict.Add(parts[0], new string[] { parts[1] });
            }
        }

        return ruleDict;
    }

    private List<List<string>> GetValidPrintingJobs(Dictionary<string, string[]> ruleDict, List<string> printMessages)
    {
        List<List<string>> validRules = new List<List<string>>();
        
        foreach(string message in printMessages)
        {
            string[] pages = message.Split(",");
            int startIndex = pages.Length - 2;

            List<string> validRulesForMessage = new List<string>();

            List<string> preceedingPages = new List<string>();

            while(startIndex > 0)
            {
                for(int x = startIndex; x < pages.Length; x++)
                {
                    preceedingPages.Add(pages[x]);
                }

                if(!InCorrectOrder(preceedingPages, ruleDict)) break;

                startIndex--;
            }

            if(InCorrectOrder(preceedingPages, ruleDict)) validRulesForMessage.Add(message);
        }

        return validRules;
    }

    private bool InCorrectOrder(List<string> preceedingPages, Dictionary<string, string[]> ruleDict)
    {
        if(preceedingPages.Count == 0) return true;

        for(int x = 0; x < preceedingPages.Count; x++)
        {
            if(!ruleDict.ContainsKey(preceedingPages[x])) return false;
        }

        // foreach(string page in preceedingPages)
        // {
        //     if(!ruleDict.ContainsKey(page)) return false;
        //     if(!ruleDict[page].Contains(firstPage)) return false;
        // }

        return true;
    }
}



