using System.ComponentModel.DataAnnotations;  // для анотаций типа [Key] [Required]
namespace BulkyBookWeb.Models; 

public class Category {
    [Key]
    public int Id { set; get; }
    [Required]
    public string Name { set; get; }
    public int DisplayOrder { set; get; }
    public DateTime CreatedDateTime { set; get; } = DateTime.Now; // значение по умолчанию
    
}