using SoldCarId.Factory;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Repository
{
    public class CarRepository
    {
        Database1Entities db = Database.getDb();

        public List<Car> getAllCar()
        {
            return (from car in db.Cars select car).ToList();
        }

        public Car FindCarById(int id)
        {
            return (from c in db.Cars where c.CarID == id select c).ToList().FirstOrDefault();
        }

        public int InsertCar(int sellerId, string brand, string model, string image, int kilometer, int year, string desc, int price)
        {
            Car car = CarFactory.createCar(sellerId, brand, model, image, kilometer, year, desc, price);
            db.Cars.Add(car);
            return db.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            Car car = FindCarById(id);
            db.Cars.Remove(car);
            db.SaveChanges();
        }

        public int UpdateCar(int id, String brand, String model, String image, int kilometer, int year, String description, int price)
        {
            Car car = FindCarById(id);

            car.Brand = brand;
            car.Model = model;
            car.Image = image;
            car.Kilometer = kilometer;
            car.ProductionYear = year;
            car.Description = description;
            car.Price = price;

            return db.SaveChanges();
        }
    }
}