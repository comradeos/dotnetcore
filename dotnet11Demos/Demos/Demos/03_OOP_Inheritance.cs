namespace Demos;

class Vehicle
{
	public void Drive() {
		Console.WriteLine("Driving,,.");
	}
    	public void Stop() {
		Console.WriteLine("Stopped");
	}
}

class Car:Vehicle
{
	public string Name { get; set; } = "aaaa";
}

class Inheritance
{
	public static void Demo()
 	{
	    Car car = new Car();
		car.Drive();
		car.Stop();
		Console.WriteLine(car.Name);
	}
}
