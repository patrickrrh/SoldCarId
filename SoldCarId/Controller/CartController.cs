using SoldCarId.Handler;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Controller
{
    public class CartController
    {

        CartHandler cartHandler = new CartHandler();
        public string AddCarToCart(int userId, int carId, string location, DateTime date)
        {
            string response = cartHandler.AddCarToCart(userId, carId, location, date);
            if (response == "success")
            {
                return "Added To Cart!";
            }
            else if (response == "Car already in cart!")
            {
                return response;
            }
            return "An error has occured! Please try again later";
        }

        public List<Cart> GetCustomerCart(int customerId)
        {
            return cartHandler.GetCustomerCart(customerId);
        }

        public string DeleteCartItem(int carId, int userId)
        {
            string response = cartHandler.DeleteCartItem(carId, userId);
            if (response == "success")
            {
                return "";
            }
            return "Failed to delete cart. Please try again later!";
        }

        public string Checkout(int customerId)
        {
            string response = cartHandler.Checkout(customerId);
            if (response == "success")
            {
                return "You have checkout succesfully!";
            }
            return "An error occured, please try again later!";
        }

    }
}