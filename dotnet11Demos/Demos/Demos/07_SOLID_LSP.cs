namespace Demos;

interface IFauna
{
	void PrintName();
}

interface IFlyable
{
	void Fly();
}

interface IUnflyable
{
	void Walk();
}

class Bird : IFauna, IFlyable
{
	public void PrintName()
	{
		Console.WriteLine("I am a bird");
	}

	public void Fly()
	{
		Console.WriteLine("I can fly");
	}
}

class Dog : IFauna, IUnflyable
{
	public void PrintName()
	{
		Console.WriteLine("I am a dog");
	}

	public void Walk()
	{
		Console.WriteLine("I can walk");
	}
}


static class LSP
{
	public static void Demo()
 	{
	    Bird bird = new Bird();
	    Info(bird);
	}

	private static void Info(IFauna fauna)
	{
		fauna.PrintName();
	}
}
