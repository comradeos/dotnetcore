namespace Demos;

/*
 class Machine {
	void Print();
	void Copy();
	void Scan();
 }
 */

interface IPrinter
{
	void Print();
}

interface IScanner
{
	void Scan();
}

interface ICopier
{
	void Copy();
}

class Printer : IPrinter
{
	public void Print()
	{
		Console.WriteLine("Printing...");
	}
}

class ISP
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
