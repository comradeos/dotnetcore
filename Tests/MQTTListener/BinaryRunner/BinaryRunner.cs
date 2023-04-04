using System.Diagnostics;

ProcessStartInfo startInfo = new()
{
    FileName = "DummyApp.exe",
    Arguments = "arg1 arg2 arg3"
};

Process exeProcess = Process.Start(startInfo);

if (exeProcess != null)
{
    exeProcess.WaitForExit();
}