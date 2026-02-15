namespace Demos;

/*
class DiscountService
{
	public int GetDiscount(string type)
	{
		if (type == "Premium") return 20;
		if (type == "Regular") return 10m;
		return 0;
	}
}
*/

interface IDiscounter
{
	int GetDiscount();
}

class RegularDiscounter : IDiscounter
{
	public int GetDiscount()
	{
		return 10;
	}
}

class PremiumDiscounter : IDiscounter
{
	public int GetDiscount()
	{
		return 20;
	}
}

static class OCP
{
	public static void Demo()
 	{
	    IDiscounter discounter = new PremiumDiscounter();
	    Console.WriteLine("discounter: " + discounter.GetDiscount() + "%");
	    
	    IDiscounter discounter2 = new RegularDiscounter();
	    Console.WriteLine("discounter2: " + discounter2.GetDiscount() + "%");
	}
}
