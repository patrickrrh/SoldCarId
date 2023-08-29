using SoldCarId.Factory;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Repository
{
    public class CartRepository
    {

        Database1Entities db = Database.getDb();
        public int AddCarToCart(int userId, int carId, string location, DateTime date)
        {
            Cart cart = CartFactory.createCart(userId, carId, location, date);
            db.Carts.Add(cart);
            return db.SaveChanges();
        }

        public List<Cart> GetCustomerCart(int customerId)
        {
            return (from c in db.Carts where c.UserID.Equals(customerId) select c).ToList();
        }

        public Cart GetCustomerCarItemCart(int carId, int userId)
        {
            return (from c in db.Carts where c.CarID.Equals(carId) && c.UserID.Equals(userId) select c).ToList().FirstOrDefault();
        }

        public int DeleteCartItem(int carId, int userId)
        {
            Cart cart = GetCustomerCarItemCart(carId, userId);
            db.Carts.Remove(cart);
            return db.SaveChanges();
        }

        public int RemoveAllCartItem(List<Cart> cartList)
        {
            db.Carts.RemoveRange(cartList);
            return db.SaveChanges();
        }

    }
}