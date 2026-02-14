namespace Demo2;

class Program {
    public delegate void MyAction();
    public static event Action MyEvent;
    
    public static void Main() {
        // Console.WriteLine("Hellllo");
        // Demo2.MyFolder.Program.Hello();

        SportCar sc = new SportCar("Ferrari");
        DescribeVehicle(sc);
        DescribeVehicle2(sc);

        Point p1 = new();
        Point p2 = new();

        Console.WriteLine(p1 == p2);



        RPoint rp1 = new();
        RPoint rp2 = new();
        Console.WriteLine(rp1 == rp2);
        rp1.X = 111;
        Console.WriteLine(rp1 == rp2);

        MyEvent += MyAction1;
        MyEvent += MyAction2;
        MyEvent.Invoke();
    }

    private static void DescribeVehicle(IVehicle vehicle) {
        Console.WriteLine($"VEHICLE: {vehicle.GetName()}");
        vehicle.Move();
        Console.WriteLine($"----------------------------");
    }

    private static void DescribeVehicle2(Car car) {
        car.GetFuelCapacity();
    }

    private static void MyAction1() {
        Console.WriteLine("Action1 ... ");
    }
    
    private static void MyAction2() {
        Console.WriteLine("Action2 ... ");
    }
}

interface IVehicle {
    string GetName();
    void Move();
}

abstract class Car : IVehicle {
    protected string Name {get;} = default!;
    protected int FuelCapacity {get;set;} = 0;

    public Car(string name, int fuelCapacity) {
        Name = name;
        FuelCapacity = fuelCapacity;
    }

    public string GetName() {
        return Name;
    }

    public void Move() {
        Console.WriteLine($"{this.Name} is moving");
    }

    public int GetFuelCapacity() {
        return FuelCapacity;
    }
}

class SportCar : Car {
    public SportCar(string name) : base(name, 100) {}
}


class Point {
    public int X {get;set;} = 0;
    public int Y {get;set;} = 0;
}


record RPoint {
    public int X {get;set;} = 0;
    public int Y {get;set;} = 0;
}
