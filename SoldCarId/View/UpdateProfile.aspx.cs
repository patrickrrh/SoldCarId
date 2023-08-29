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
    public partial class UpdateProfile : System.Web.UI.Page
    {

        UserController userController = new UserController();
        RegisController regisController = new RegisController();
        User user;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
            else
            {
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

                if (user.UserRole == "admin")
                {
                    MasterPageFile = "~/View/Master/Admin.Master";
                }
                else MasterPageFile = "~/View/Master/Customer.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                nameTbx.Text = user.UserName;
                emailTbx.Text = user.UserEmail;
                passTbx.Text = user.UserPassword;
                addressTbx.Text = user.UserAddress;

            }

        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            String name = nameTbx.Text;
            String email = emailTbx.Text;
            String password = passTbx.Text;
            String address = addressTbx.Text;


            String responseText = regisController.CheckUpdate(user.UserID, name, email, address, password);
            errorLbl.Visible = true;

            errorLbl.Text = responseText;

            if (responseText == "")
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void updateBtn_Click1(object sender, EventArgs e)
        {
            String name = nameTbx.Text;
            String email = emailTbx.Text;
            String password = passTbx.Text;
            String address = addressTbx.Text;


            String responseText = regisController.CheckUpdate(user.UserID, name, email, address, password);
            errorLbl.Visible = true;

            errorLbl.Text = responseText;

            if (responseText == "")
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}