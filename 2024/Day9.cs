class Day9
{
    private string data = File.ReadAllText("./data/day9_demo.txt");

    public int CalculateFileChecksum()
    {
        int checksum = 0;

        string mapping = CalculateFileAndSpace(data);

        return checksum;
    }

    private string CalculateFileAndSpace(string data)
    {
        int fileNum = 0;
        string mapping = "";
        bool emptyBlock = false;

        for(int x = 0; x < data.Length; x ++)
        {
            int temp = int.Parse(data[x].ToString());
            if(temp != 0)
            {
                if(!emptyBlock)
                {
                    for(int y = 0; y < temp; y++)
                    {
                        mapping += fileNum;
                    }
                    fileNum++;
                    emptyBlock = true;
                }
                
                else
                {
                    for(int y = 0; y < temp; y++)
                    {
                        mapping += ".";
                        emptyBlock = false;
                    }
                }
            }
        }

        return mapping;
    }
}