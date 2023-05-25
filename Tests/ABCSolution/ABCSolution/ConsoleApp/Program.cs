using Celerint;

public class Program
{

    public static void Main(String[] args)
    {
        ConformanceDataV2 data = new();


        data.ConformanceTestList.Add(new());

        if (data.ConformanceTestList[^1].TesterSetup != null)
        {
            if (data.ConformanceTestList[^1].TesterSetup?.DigitalInstrument != null)
            {
                if (data.ConformanceTestList[^1].TesterSetup?.DigitalInstrument?.Driver != null) 
                {
                    Console.WriteLine(111111);
                }
            }
        }








        /*
        MyModel myModel = new()
        {
            Id = 5532,
            Name = "MyModel1Name"
        };

        Console.WriteLine($"{myModel.Id} :: {myModel.Name}");

        TesterSetup testerSetup = new();

        if (testerSetup.DigitalInstrument != null)
        {
            if (testerSetup.DigitalInstrument.Driver != null)
                testerSetup.DigitalInstrument.Driver.DeviceInputVoltageHigh = 0;
        }

        */
    }
}

public class TesterSetup
{
    public DigitalInstrument? DigitalInstrument { get; set; }
}

public class DigitalInstrument
{
    public Driver? Driver { get; set; }
}

public class Driver
{
    public decimal? DeviceInputVoltageHigh { get; set; }
}