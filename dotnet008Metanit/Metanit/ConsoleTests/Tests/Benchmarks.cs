using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

namespace ConsoleTests.Tests;

internal class Benchmarks
{
    public Benchmarks()
    {
        BenchmarkRunner.Run<StringTest>();
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
        foreach (string line in numbers) result += $"{result}{line} ";
        return result;
    }
}