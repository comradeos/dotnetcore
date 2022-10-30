namespace BulkyBookWeb.Models; 

public class Category {
    public int Id { set; get; }
    public string Name { set; get; }
    public int DisplayOrder { set; get; }
    public DateTime CreatedDateTime { set; get; } = DateTime.Now; // значение по умолчанию
    
}