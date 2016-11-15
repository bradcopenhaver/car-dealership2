using System;
using System.Collections.Generic;

namespace carDealership.Objects
{
  class Car
  {
    private string _makeModel;
    private int _price;
    private int _miles;
    private static List<Car> _inventory = new List<Car> {};

    public Car(string carMakeModel, int carPrice, int carMiles)
    {
      _makeModel = carMakeModel;
      _price = carPrice;
      _miles = carMiles;

      _inventory.Add(this);
    }

    public void SetModel(string carMakeModel) {
      _makeModel = carMakeModel;
    }

    public string GetModel() {
      return _makeModel;
    }

    public void SetPrice(int carPrice) {
      _price = carPrice;
    }

    public int GetPrice() {
      return _price;
    }

    public void SetMiles(int carMiles) {
      _miles = carMiles;
    }

    public int GetMiles() {
      return _miles;
    }

    public static List<Car> GetAll()
    {
      return _inventory;
    }
    public static void ClearAll()
    {
      _inventory.Clear();
    }

    // public void PrintInfo() {
    //   Console.WriteLine("The car you selected is a " + _makeModel + ".");
    //   Console.WriteLine("Its price is $" + _price + ".");
    //   Console.WriteLine("It has " + _miles + " miles on it.");
    // }
  }

}
