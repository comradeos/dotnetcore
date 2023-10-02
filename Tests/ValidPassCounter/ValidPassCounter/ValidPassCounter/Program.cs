using System.Text.RegularExpressions;

namespace ValidPassCounter;

internal static class Program
{
    private const string FileName = @"_passwords.txt";
    private static readonly List<string> Lines = File.ReadAllLines(FileName).ToList();
    
    private static int _validPasswordsCounter = 0;
    private static int _invalidPasswordsCounter = 0;
    
    private static string GetTargetChars(string line)
    {
        string[] lineParts = line.Split(' ');
        return lineParts[0];
    }
    
    private static string GetPassword(string line)
    {
        string[] lineParts = line.Split(' ');
        return lineParts[2];
    }
        
    private static int CountCharInPassword(string sub, string line)
    {
        return Regex.Matches(line, sub).Count;
    }
    
    private static int? GetMinValue(string line)
    {
        string[] lineParts = line.Split(' ');
        string subString = lineParts[1].Split('-')[0];

        int? minValue = null;

        try
        {
            minValue = Convert.ToInt32(subString);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return minValue;
    }
        
    private static int? GetMaxValue(string line)
    {
        string[] lineParts = line.Split(' ');
        string subString = lineParts[1].Split('-')[1].Replace(':', ' ');
        
        int? maxValue = null;
        
        try
        {
            maxValue = Convert.ToInt32(subString);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        return maxValue;
    }
    
    public static void Main(string[] args)
    {
        foreach (string line in Lines)
        {
            int? min = GetMinValue(Lines[0]);
            int? max = GetMaxValue(Lines[0]);
            
            string targetChar = GetTargetChars(line);
            string password = GetPassword(line);

            int targetCharCounter = CountCharInPassword(targetChar, password);

            if (min <= targetCharCounter && targetCharCounter <= max)
            {
                ++_validPasswordsCounter;
            }
            else
            {
                ++_invalidPasswordsCounter;
            }
        }
        
        Console.WriteLine($"ValidPasswordsCounter: {_validPasswordsCounter}");
        Console.WriteLine($"InvalidPasswordsCounter: {_invalidPasswordsCounter}");
    }
}