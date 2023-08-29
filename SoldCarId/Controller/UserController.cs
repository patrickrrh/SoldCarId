using SoldCarId.Handler;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SoldCarId.Controller
{
    public class UserController
    {
        UserHandler userHan = new UserHandler();
        public User getUserById(int id)
        {
            return userHan.GetUserById(id);
        }


    }
}