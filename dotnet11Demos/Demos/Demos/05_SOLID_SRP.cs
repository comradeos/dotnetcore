namespace Demos;

/*
class User
{
	public void Register();
	public void Report();
}
*/

class User
{
	public string? Name { get; set; }
}

interface IReporter
{
	static abstract void Report(User user);
}

interface IRegistrator
{
	static abstract void Register(User user);
}

class Reporter : IReporter
{
	public static void Report(User user)
	{
		Console.WriteLine("Reporting... " + user.Name);
	}
}

class Registrator : IRegistrator
{
	public static void Register(User user)
	{
		Console.WriteLine("Registering... " + user.Name);
	}
}

static class SRP
{
	public static void Demo()
 	{
	    User user = new User { Name = "John" };
	    Registrator.Register(user);
	    Reporter.Report(user);
	}
}
