using System.Diagnostics;


string content = "welcome";
File.WriteAllText("my_file.txt", content);

string fullPath = Path.GetFullPath("my_file.txt");

string dummyAppPath = @"..\..\..\..\DummyApp\bin\Debug\net6.0\DummyApp.exe";

ProcessStartInfo startInfo = new()
{
    FileName = dummyAppPath,
    Arguments = fullPath
};

Process exeProcess = Process.Start(startInfo);

if (exeProcess != null)
{
    exeProcess.WaitForExit();
}