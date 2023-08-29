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
    public partial class Login : System.Web.UI.Page
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

        protected void loginPageBtn_Click(object sender, EventArgs e)
        {
            dynamic user = regisContoller.CheckLogin(emailTbx.Text, passTbx.Text);

            if (user is User)
            {
                if (user != null)
                {
                    Session["user"] = user;
                    if (rememberMeCbx.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("user_cookie");
                        cookie.Value = user.UserID.ToString();
                        cookie.Expires = DateTime.Now.AddDays(3);
                        Response.Cookies.Add(cookie);
                    }

                    if (Application["user_count"] == null)
                    {
                        Application["user_count"] = 1;
                    }
                    else
                    {
                        Application["user_count"] = (int)Application["user_count"] + 1;
                    }

                    Response.Redirect("~/View/home.aspx");
                }
            }
            else
            {
                errorLbl.Visible = true;
                errorLbl.Text = user;
            }
        }
    }
}