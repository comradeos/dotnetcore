using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Runtime.CompilerServices;
using System.Text;

class Program
{
    public static void Main()
    {
        // BenchmarkRunner.Run<StringTest>();

        string str = "hello world";

        byte[] bytesArray = Encoding.ASCII.GetBytes(str);

        foreach (byte item in bytesArray)
        {
            Console.WriteLine($"{item}");
        }

        Console.WriteLine();

        BinaryWriter binaryWriter = new(File.Open("my_file", FileMode.Create));
        binaryWriter.Write(bytesArray);
        binaryWriter.Close();

        BinaryReader binaryReader = new(File.Open("my_file", FileMode.Open));
        byte[] reader = binaryReader.ReadBytes(200);
        foreach (byte item in reader)
        {
            Console.WriteLine($"{item}");
        }

        string s = Encoding.ASCII.GetString(reader);
        Console.WriteLine(s);
        Console.ReadLine();

    }
}

public class StringTest
{
    string[] numbers =
    {
       "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"
    };
    [Benchmark]
    public string WithStringBuilder()
    {
        StringBuilder stringBuilder = new();
        
        foreach (string line in numbers)
        {
            stringBuilder.Append(line);
            stringBuilder.Append(" ");
        }
        
        return stringBuilder.ToString();
    }
    [Benchmark]
    public string WithConcatenation()
    {
        string result = "";
        foreach (string line in numbers) result += line + " ";
        return result;
    }
    [Benchmark]
    public string WithInterpolation()
    {
        string result = "";
        foreach (string line in numbers) result +=  $"{result}{line} ";
        return result;
    }
}