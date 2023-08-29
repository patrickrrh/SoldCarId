using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Factory
{
    public class UserFactory
    {
        public static User createUser(string userName, string userEmail, string userPassword, string userAddress, string userRole)
        {
            User user = new User();
            user.UserName = userName;
            user.UserEmail = userEmail;
            user.UserPassword = userPassword;
            user.UserAddress = userAddress;
            user.UserRole = userRole;

            return user;
        }
    }
}