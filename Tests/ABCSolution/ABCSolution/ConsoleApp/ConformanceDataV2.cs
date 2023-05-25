namespace Celerint;

public class ConformanceDataV2
{
    public List<ConformanceTest> ConformanceTestList { get; set; } = new();
}

public class ConformanceTest
{
    public int? ConformanceTestCount { get; set; }
    public string? TestName { get; set; }
    public string? TestType { get; set; }
    public TesterSetup? TesterSetup { get; set; }
}

public class TesterSetup
{
    public int? NumberOfSites { get; set; }
    public DigitalInstrument? DigitalInstrument { get; set; }
}

public class DigitalInstrument
{
    public string? Name { get; set; }
    public Driver? Driver { get; set; }
}

public class Driver
{
    public decimal? DeviceInputVoltageHigh { get; set; }
    public decimal? DeviceInputVoltageClampHigh { get; set; }
    public decimal? DeviceInputVoltageLow { get; set; }
    public decimal? DeviceInputVoltageClampLow { get; set; }
}
