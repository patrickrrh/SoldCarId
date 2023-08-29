using SoldCarId.Model;
using SoldCarId.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Handler
{
    public class UserHandler
    {
        UserRepository userRepo = new UserRepository();

        public User GetUserById(int id)
        {
            return userRepo.GetUserById(id);
        }

        public dynamic DoLogin(String email, String password)
        {
            User user = userRepo.GetUserLogin(email, password);
            if (user != null) return user;

            return "No credential found for that user!";
        }

        public String DoRegister(String name, String email, String password, String address)
        {
            bool isEmailDuplicate = userRepo.isDuplicateUser(email);
            if (isEmailDuplicate) return "Email already registered!";

            userRepo.RegisterUser(name, email, password, address);
            return "Registered";
        }

        public String DoUpdate(int custId, String name, String email, String password, String address)
        {
            User user = userRepo.GetUserById(custId);
            if (email == user.UserEmail)
            {
                userRepo.UpdateUser(custId, name, email, password, address);
            }
            else
            {
                bool isEmailDuplicate = userRepo.isDuplicateUser(email);

                if (isEmailDuplicate) return "Email duplicated!";
                int response = userRepo.UpdateUser(custId, name, email, password, address);
                if (response > 0) return "";
            }
            return "Failed to update!";
        }
    }
}