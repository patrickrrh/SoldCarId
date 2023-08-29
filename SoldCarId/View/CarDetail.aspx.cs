using SoldCarId.Controller;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SoldCarId.View
{
    public partial class CarDetail : System.Web.UI.Page
    {

        CarController carController = new CarController();
        UserController userController = new UserController();
        CartController cartController = new CartController();
        User user;

        Car car;
        int carId;

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
            if (Request["ID"] == null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
            carId = int.Parse(Request["ID"]);
            if (!IsPostBack)
            {
                car = carController.getCarById(carId);

                carImg.ImageUrl = car.Image;
                carBrand.Text = $"Brand name: {car.Brand}";
                carModel.Text = $"Model name: {car.Model}";
                carKilometer.Text = $"Kilometer: {car.Kilometer}";
                carYear.Text = $"Production year: {car.ProductionYear}";
                carDesc.Text = $"Description: {car.Description}";
                carPrice.Text = $"Price: Rp. {car.Price}";

                if (user == null || user.UserRole != "Cust")
                {
                    addToStockBtn.Visible = false;
                    isAdmin.Visible = false;
                }
            }
        }

        protected void addToStockBtn_Click(object sender, EventArgs e)
        {
            string location = locationTB.Text;
            string date = Button1.Value;

            string response = cartController.AddCarToCart(user.UserID, carId, location, DateTime.Parse(date));
            errorLbl.Text = response;
        }
    }
}