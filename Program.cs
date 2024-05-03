using numberAnalyzer;

public class Program
{
    public static void Main()
    {
        var repositoryPath = "";
        var fileAnalyzer = new FileAnalyzer();
        
        Console.WriteLine("=====Choose the option======");
        Console.WriteLine("1: Handle existed data.");
        Console.WriteLine("2. Generate and handle data.");
        
        var command = Console.ReadLine();
        
        switch (command)
        {
            case "1":
                repositoryPath = ConsoleReader.Read();
                fileAnalyzer.DirectoryPath = repositoryPath;
                break;
            case "2":
                repositoryPath = ConsoleReader.Read();
                fileAnalyzer.DirectoryPath = repositoryPath;
                
                Console.WriteLine("====Write amount of files to generate.=====");
                int.TryParse(Console.ReadLine(), out int amountOfFiles);

                for (int i = 0; i < amountOfFiles; i++)
                {
                    string pathToGeneratedFile = Path.Combine(repositoryPath, $"generated_{i}.txt");
                    FileWriter.WriteToFile(pathToGeneratedFile,NumberGenerator.GenerateValues());
                }
                break;
        }

        var resultNumbers = fileAnalyzer.HandleFilesInfo();
        resultNumbers.Reverse();
        string pathToFile = Path.Combine(repositoryPath, "result.txt");
        FileWriter.WriteToFile(pathToFile, resultNumbers);
    }
}