namespace numberAnalyzer;

public class FileWriter
{
    public static void WriteToFile(string pathToFile, IEnumerable<int> resultNumbers)
    {
        using StreamWriter writer = new StreamWriter(pathToFile);
        foreach (int value in resultNumbers)
        {
            writer.WriteLine(value);
        }
    }
}