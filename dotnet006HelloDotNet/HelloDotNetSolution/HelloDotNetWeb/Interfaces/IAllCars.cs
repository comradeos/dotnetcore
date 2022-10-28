using HelloDotNetWeb.Models; 

namespace HelloDotNetWeb.Interfaces; 

public interface IAllCars {
    IEnumerable<Car> Cars { set; get; }
    IEnumerable<Car> GetFavoriteCars { set; get; }
    Car GetObjectCar(int id);
}