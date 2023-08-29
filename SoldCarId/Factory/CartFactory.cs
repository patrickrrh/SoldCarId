using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int userID, int carID, string location, DateTime appointmentDate)
        {
            Cart cart = new Cart();
            cart.UserID = userID;
            cart.CarID = carID;
            cart.Location = location;
            cart.AppointmentDate = appointmentDate;

            return cart;
        }
    }
}