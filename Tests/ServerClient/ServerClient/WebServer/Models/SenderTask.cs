namespace WebServer.Models;

enum Status
{
    SUCCESS,
    FAILURE
}

public class SenderTask
{
    public int Id { get; set; }
    public string Device { get; set; } = default!;
    public string Address { get; set; } = default!;
    public decimal Amount { get; set; }
    public int Status { get; set; }
}

