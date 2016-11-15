using Nancy;
using System.Collections.Generic;
using Car.Objects;

namespace carDealership
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/add_car"] = _ => View["add_car.cshtml"];

      Post["/current_inventory"] = _ =>
      {
        Car newCar = new Car(Request.Form["makeModel"], int.Parse(Request.Form["price"]), int.Parse(Request.Form["miles"]));
        List<Car> allCars = Car.GetAll();
        return View["current_inventory.cshtml", allCars];
      }
    }
  }
}
