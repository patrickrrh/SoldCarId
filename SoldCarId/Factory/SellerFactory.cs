using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Factory
{
    public class SellerFactory
    {
        public static Seller createSeller(string sellerName, string address, string phoneNumber)
        {
            Seller seller = new Seller();
            seller.SellerName = sellerName;
            seller.Address = address;
            seller.PhoneNumber = phoneNumber;

            return seller;
        }
    }
}