namespace numberAnalyzer;

public static class NumberGenerator
{
    public static int[] GenerateValues()
    {
        Random rnd = new Random();
        int amount = rnd.Next(100, 1001);

        int[] generatedValues = new int[amount];

        for (int i = 0; i < amount; i++)
        {
            generatedValues[i] = rnd.Next();
        }

        return generatedValues;
    }
}