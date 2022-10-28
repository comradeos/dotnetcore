namespace HelloDotNetWeb.Models;

public class Category {
    public int Id { set; get; }
    public string CategoryName { set; get; }
    public string CategoryDescription { set; get; }
    public List<Car> Cars { set; get; }
}