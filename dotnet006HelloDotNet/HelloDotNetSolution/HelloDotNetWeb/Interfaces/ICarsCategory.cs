using HelloDotNetWeb.Models;

namespace HelloDotNetWeb.Interfaces; 

public interface ICarsCategory {
    IEnumerable<Category> AllCategories { set; get; }
}