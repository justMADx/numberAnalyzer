namespace numberAnalyzer;

public static class ConsoleReader
{
    public static string Read()
    {
        string repositoryPath;
        do
        {
            Console.WriteLine("====Enter an absolute path to repository====");
            repositoryPath = Console.ReadLine();
        } while (string.IsNullOrEmpty(repositoryPath.Trim()));

        return repositoryPath;
    }
}