using System.Text;

namespace ConsoleTests.Tests;

internal class BiraryReadWrite
{
    public BiraryReadWrite()
    {
        string str = "hello world";

        byte[] bytesArray = Encoding.ASCII.GetBytes(str);

        foreach (byte item in bytesArray) Console.WriteLine($"{item}");

        Console.WriteLine();

        BinaryWriter binaryWriter = new(File.Open("my_file", FileMode.Create));
        binaryWriter.Write(bytesArray);
        binaryWriter.Close();

        BinaryReader binaryReader = new(File.Open("my_file", FileMode.Open));
        byte[] reader = binaryReader.ReadBytes(200);
        binaryReader.Close();
        foreach (byte item in reader) Console.WriteLine($"{item}");

        string s = Encoding.ASCII.GetString(reader);
        Console.WriteLine(s);
    }
}
