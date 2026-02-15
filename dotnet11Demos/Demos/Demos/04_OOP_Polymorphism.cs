using System.Globalization;

namespace Demos;

abstract class Discount
{
	protected double Amount { get; set; } 
	public abstract double Calculate();

	public void Print()
	{
		Console.WriteLine($"Discount: {Amount.ToString(CultureInfo.CurrentCulture)}");
	}
}

class RegularDiscount : Discount
{
	public RegularDiscount()
	{
		Amount = 0.5;
	}
	
	public override double Calculate()
	{
		return Amount;
	}
}

class PremiumDiscount : Discount
{
	public PremiumDiscount()
	{
		Amount = 0.75;
	}
	
	public override double Calculate()
	{
		return Amount * 2;
	}
}

static class Polymorphism
{
	public static void Demo()
 	{
	    RegularDiscount regularDiscount = new RegularDiscount();
	    regularDiscount.Print();
	    
	    PremiumDiscount premiumDiscount = new PremiumDiscount();
	    premiumDiscount.Print();
	}
}
