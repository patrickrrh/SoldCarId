using SoldCarId.Model;
using SoldCarId.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Handler
{
    public class CarHandler
    {
        CarRepository carRepo = new CarRepository();
        public List<Car> getAllCar()
        {
            return carRepo.getAllCar();
        }

        public Car getCarById(int id)
        {
            return carRepo.FindCarById(id);
        }

        public string InsertCar(int sellerId, string brand, string model, string image, int kilometer, int year, string desc, int price)
        {
            // status > 0 == success, status == 0 failed
            int status = carRepo.InsertCar(sellerId, brand, model, image, kilometer, year, desc, price);
            if (status > 0) return "success";
            else return "failed";
        }

        public void DeleteCar(int id)
        {
            Car car = carRepo.FindCarById(id);

            if (car == null) return;

            carRepo.DeleteCar(id);
        }

        public string UpdateCar(int artistId, string brand, string model, string image, int kilometer, int year, string description, int price)
        {
            Car car = carRepo.FindCarById(artistId);

            // status > 0 == success, status == 0 failed
            int status = carRepo.UpdateCar(artistId, brand, model, image, kilometer, year, description, price);
            if (status > 0) return "success";
            else return "failed";
        }

    }
}