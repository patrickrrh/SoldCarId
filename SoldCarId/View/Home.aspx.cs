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
    public partial class Home : System.Web.UI.Page
    {
        CarController carController = new CarController();
        UserController userController = new UserController();
        User user;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                MasterPageFile = "~/View/Master/Guest.Master";
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
                DataRebinding();
                if (user != null && user.UserRole == "admin")
                {
                    insertBtn.Visible = true;
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Button updateBtn = (Button)item.FindControl("updateBtn");
                        Button deleteBtn = (Button)item.FindControl("deleteBtn");

                        updateBtn.Visible = true;
                        deleteBtn.Visible = true;
                    }
                }
            }
        }

        protected void DataRebinding()
        {
            List<Car> car = carController.getAllCar();
            Repeater1.DataSource = car;
            Repeater1.DataBind();
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertCar.aspx");
        }

        protected void detailBtn_Click(object sender, EventArgs e)
        {
            Button btnDetail = (Button)sender;
            int carId = Convert.ToInt32(btnDetail.CommandArgument);
            Response.Redirect("~/View/CarDetail.aspx?ID=" + carId);
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Button btnUpdate = (Button)sender;
            int carId = Convert.ToInt32(btnUpdate.CommandArgument);
            Response.Redirect("~/View/EditCar.aspx?ID=" + carId);
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            Button btnRemove = (Button)sender;
            int carId = Convert.ToInt32(btnRemove.CommandArgument);
            carController.DeleteCar(carId);

            DataRebinding();
        }
    }
}