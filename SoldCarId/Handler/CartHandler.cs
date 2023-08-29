using SoldCarId.Controller;
using SoldCarId.Model;
using SoldCarId.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Handler
{
    public class CartHandler
    {
        UserController custController = new UserController();
        AppointmentHandler appHandler = new AppointmentHandler();

        CartRepository cartRepo = new CartRepository();
        public string AddCarToCart(int userId, int carId, string location, DateTime date)
        {
            if (cartRepo.GetCustomerCarItemCart(carId, userId) == null)
            {
                cartRepo.AddCarToCart(userId, carId, location, date);
                return "success";
            }
            return "Car already in cart!";
        }

        public List<Cart> GetCustomerCart(int customerId)
        {
            return cartRepo.GetCustomerCart(customerId);
        }

        public string DeleteCartItem(int carId, int userId)
        {
            int response = cartRepo.DeleteCartItem(carId, userId);

            if (response > 0)
            {
                return "success";
            }

            return "failed";
        }

        public string Checkout(int customerId)
        {
            List<Cart> cartList = cartRepo.GetCustomerCart(customerId);
            int responseTrs = appHandler.AddToAppointment(customerId, cartList);
            if (responseTrs > 0)
            {
                int responseCart = cartRepo.RemoveAllCartItem(cartList);
                if (responseCart > 0)
                {
                    return "success";
                }

            }
            return "failed";

        }

    }
}