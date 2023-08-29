using SoldCarId.Factory;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Repository
{
    public class UserRepository
    {
        Database1Entities db = new Database1Entities();

        public User GetUserLogin(string email, string password)
        {
            User user = (from u in db.Users
                         where u.UserEmail == email && u.UserPassword == password
                         select u).ToList().LastOrDefault();

            return user;
        }

        public bool isDuplicateUser(String email)
        {
            User user = (from u in db.Users where u.UserEmail == email select u).ToList().FirstOrDefault();
            if (user == null) return false;
            return true;
        }

        public User GetUserById(int id)
        {
            User user = (from u in db.Users where u.UserID == id select u).ToList().FirstOrDefault();
            return user;
        }

        public void RegisterUser(String name, String email, String password, String address)
        {
            string role = "Cust";
            User user = UserFactory.createUser(name, email, password, address, role);

            db.Users.Add(user);
            db.SaveChanges();

        }

        public int UpdateUser(int userId, String name, String email, String password, String address)
        {
            User user = GetUserById(userId);

            user.UserName = name;
            user.UserEmail = email;
            user.UserPassword = password;
            user.UserAddress = address;

            return db.SaveChanges();
        }
    }
}