using SoldCarId.Handler;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Controller
{
    public class CarController
    {
        CarHandler carHan = new CarHandler();

        public List<Car> getAllCar()
        {
            return carHan.getAllCar();
        }

        public Car getCarById(int id)
        {
            return carHan.getCarById(id);
        }

        public string InsertCar(int sellerId, string brand, string model, string image, int kilometer, int year, string desc, int price)
        {
            if (brand == null)
            {
                return "Brand name must be filled!";
            }

            string response = carHan.InsertCar(sellerId, brand, model, image, kilometer, year, desc, price);

            return CheckReturnString(response);
        }

        public String CheckUpdateCar(int artistId, string brand, string model, string image, int kilometer, int year, string description, int price)
        {
            string response = carHan.UpdateCar(artistId, brand, model, image, kilometer, year, description, price);

            return CheckReturnString(response);
        }

        public String CheckReturnString(string response)
        {
            if (response == "success") return "success";
            else return "Failed, please try again!";
        }

        public void DeleteCar(int id)
        {
            carHan.DeleteCar(id);
        }
    }
}