namespace numberAnalyzer;

public class FileAnalyzer
{
    public string DirectoryPath { get; set; }
    private SortedSet<int> NumberSet { get ; set; } = new();

    public List<int> HandleFilesInfo()
    {
        var files = ReadFilesFromDirectory();
        foreach (var filePath in files)
        {
            var numbersFromSingleFile = ReadInfoFromSingleFile(filePath);
            foreach (var value in numbersFromSingleFile.Where(value =>
                         !NumberSet.Contains(value)).Where(IsNumberRight))
            {
                NumberSet.Add(value);
            }
        }
        
        return NumberSet.ToList();
    }

    private bool IsNumberRight(int number)
    {
        return number % 4 == 3;
    }
    
    private SortedSet<int> ReadInfoFromSingleFile(string pathToFile)
    {
        var uniqueNumbers = new SortedSet<int>();
        using StreamReader sr = new StreamReader(pathToFile);
        string? str;
        while ((str = sr.ReadLine()) != null)
        {
            if (int.TryParse(str, out var number))
            {
                uniqueNumbers.Add(number);
            }
        }

        return uniqueNumbers;
    }
    
    private IEnumerable<string> ReadFilesFromDirectory()
    {
        var files = Array.Empty<string>();
        if (!Directory.Exists(DirectoryPath))
        {
            Console.WriteLine("Directory not exist!");
            return files;
        }
        files = Directory.GetFiles(DirectoryPath);
        if (files.Length == 0)
        {
            Console.WriteLine("Directory is empty!");
            return files;
        }

        return files;
    }
}