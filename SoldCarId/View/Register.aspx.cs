using SoldCarId.Controller;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoldCarId.View
{
    public partial class Register : System.Web.UI.Page
    {
        RegisController regisContoller = new RegisController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            UserController userController = new UserController();

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                MasterPageFile = "~/View/Master/Guest.Master"; ;
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    int id = int.Parse(Request.Cookies["user_cookie"].Value);
                    user = userController.getUserById(id);
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                if (user.UserRole == "admin") MasterPageFile = "~/View/Master/Admin.Master";
                else MasterPageFile = "~/View/Master/Regis.Master";

                Response.Redirect("~/View/home.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            String name = nameTbx.Text.Trim();
            String email = emailTbx.Text.Trim();
            String password = passTbx.Text;
            String address = addressTbx.Text.Trim();


            String responseText = regisContoller.CheckRegister(name, email, password, address);
            errorLbl.Visible = true;
            if (responseText == "Registered")
            {
                Response.Redirect("Login.aspx");
            }
            else errorLbl.Text = responseText;
        }
    }
}