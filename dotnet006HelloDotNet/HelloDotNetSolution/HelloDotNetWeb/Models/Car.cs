namespace HelloDotNetWeb.Models;

public class Car {
    public int Id { set; get; }
    public string Name { set; get; }
    public string ShortDescription { set; get; }
    public string LongDescription { set; get; }
    public string Image { set; get; }
    public ushort Price { set; get; }
    public bool IsFavorite { set; get; }
    public int Avalible { set; get; }
    public int CategoryId { set; get; }

    public virtual Category Category { set; get; }
}