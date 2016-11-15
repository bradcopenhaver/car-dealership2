using Nancy;
using System.Collections.Generic;
using carDealership.Objects;

namespace carDealership
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Car car1 = new Car("Ford", 15000, 1000);
      Car car2 = new Car("Chevy", 17000, 2000);
      Get["/"] = _ =>
      {
        if (Car.GetAll().Count > 0) {
          return View["index.cshtml", true];
        }
        else
        {
          return View["index.cshtml", false];
        }
      };
      Get["/add_car"] = _ => View["add_car.cshtml"];
      Get["/current_inventory"] = _ =>
      {
        List<Car> allCars = Car.GetAll();
        return View["current_inventory.cshtml", allCars];
      };
      Post["/current_inventory"] = _ =>
      {
        string makeModel = Request.Form["makeModel"];
        string price = Request.Form["price"];
        string miles = Request.Form["miles"];
        if (makeModel != "" && price != "" & miles != "") {
          Car newCar = new Car(makeModel, int.Parse(price), int.Parse(miles));
          List<Car> allCars = Car.GetAll();
          return View["current_inventory.cshtml", allCars];
        }
        else
        {
          return View["add_car.cshtml"];
        }
      };
      Get["/car_details/{id}"] = parameters =>
      {
        Car currentCar = Car.SearchID(parameters.id);
        return View["car_details.cshtml", currentCar];
      };
      Post["/search_results"] = _ =>
      {
        if (Request.Form["price"] != "" || Request.Form["miles"] != "")
        {
          List<Car> filteredCars = Car.FindCars(Request.Form["price"], Request.Form["miles"]);
          return View["current_inventory.cshtml", filteredCars];
        }
        else
        {
          return View["car_search.cshtml", true];
        }
      };
      Get["/car_search"] = _ => View["car_search.cshtml", false];
      Get["/clear_inventory"] = _ =>
      {
        Car.ClearAll();
        List<Car> allCars = Car.GetAll();
        return View["current_inventory", allCars];
      };
    }
  }
}
