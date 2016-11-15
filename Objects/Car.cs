using System;
using System.Collections.Generic;

namespace carDealership.Objects
{
  public class Car
  {
    private string _makeModel;
    private int _price;
    private int _miles;
    private int _id;
    private static List<Car> _inventory = new List<Car> {};

    public Car(string carMakeModel, int carPrice, int carMiles)
    {
      _makeModel = carMakeModel;
      _price = carPrice;
      _miles = carMiles;

      _inventory.Add(this);
      _id = _inventory.Count;
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

    public int GetID()
    {
      return _id;
    }

    public static Car SearchID(int SearchID)
    {
      return _inventory[SearchID-1];
    }

    public static List<Car> FindCars(int price, int miles)
    {
      List<Car> returnedCars = new List<Car> {};
      for (int index = 0; index < _inventory.Count; index++) {
        if (price > _inventory[index].GetPrice() && miles > _inventory[index].GetMiles()) {
          returnedCars.Add(_inventory[index]);
        }
      }
      return returnedCars;
    }

    // public void PrintInfo() {
    //   Console.WriteLine("The car you selected is a " + _makeModel + ".");
    //   Console.WriteLine("Its price is $" + _price + ".");
    //   Console.WriteLine("It has " + _miles + " miles on it.");
    // }
  }

}
