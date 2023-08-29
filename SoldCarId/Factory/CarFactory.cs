using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Factory
{
    public class CarFactory
    {
        public static Car createCar(int sellerId, string brand, string model, string image, int kilometer, int productionYear, string description, int price)
        {
            Car car = new Car();
            car.SellerID = sellerId;
            car.Brand = brand;
            car.Model = model;
            car.Image = image;
            car.Kilometer = kilometer;
            car.ProductionYear = productionYear;
            car.Description = description;
            car.Price = price;

            return car;
        }
    }
}