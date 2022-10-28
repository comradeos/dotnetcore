using HelloDotNetWeb.Interfaces;
using HelloDotNetWeb.Models;

namespace HelloDotNetWeb.Mocks; 

public class MockCategory : ICarsCategory {
    
    public IEnumerable<Category> AllCategories {
        set {
            
        }
        get {
            return new List<Category> {
                new Category {
                    CategoryName = "Элекстромобили",
                    CategoryDescription = "Современный вид транспорта"
                },
                new Category() {
                    CategoryName = "Классические автомобили",
                    CategoryDescription = "Машины с двигателем внутреннего сгорания"
                }
            };
        }
    }
    
    
    
    
    
}