using Nancy;
using System.Collections.Generic;
using carDealership.Objects;

namespace carDealership
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/add_car"] = _ => View["add_car.cshtml"];
      Get["/current_inventory"] = _ =>
      {
        List<Car> allCars = Car.GetAll();
        return View["current_inventory.cshtml", allCars];
      };
      Post["/current_inventory"] = _ =>
      {
        Car newCar = new Car(Request.Form["makeModel"], int.Parse(Request.Form["price"]), int.Parse(Request.Form["miles"]));
        List<Car> allCars = Car.GetAll();
        return View["current_inventory.cshtml", allCars];
      };
      Get["/car_details/{id}"] = parameters =>
      {
        Car currentCar = Car.SearchID(parameters.id);
        return View["car_details.cshtml", currentCar];
      };
      Post["/search_results"] = _ =>
      {
        List<Car> filteredCars = Car.FindCars(int.Parse(Request.Form["price"]), int.Parse(Request.Form["miles"]));
        return View["current_inventory.cshtml", filteredCars];
      };
      Get["/car_search"] = _ => View["car_search.cshtml"];
    }
  }
}
