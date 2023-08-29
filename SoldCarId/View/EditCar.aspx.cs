using SoldCarId.Controller;
using SoldCarId.Handler;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoldCarId.View
{
    public partial class EditCar : System.Web.UI.Page
    {
        private CarController carController = new CarController();
        private FileUploadController fileController = new FileUploadController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            UserController userController = new UserController();

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                MasterPageFile = "~/View/Master/Guest.Master";
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
            int id = int.Parse(Request["ID"]);
            CarHandler carHan = new CarHandler();
            if (!IsPostBack)
            {
                Car car = carHan.getCarById(id);

                BrandTbx.Text = car.Brand;
                ModelTbx.Text = car.Model;
                kilometerTbx.Text = car.Kilometer.ToString();
                yearTbx.Text = car.ProductionYear.ToString();
                descTbx.Text = car.Description;
                priceTbx.Text = car.Price.ToString();
                carImage.ImageUrl = car.Image;
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["ID"]);
            string newBrand = BrandTbx.Text.Trim();
            string newModel = ModelTbx.Text.Trim();
            string newKilometer = kilometerTbx.Text.Trim();
            string newYear = yearTbx.Text.Trim();
            string newDesc = descTbx.Text.Trim();
            string newPrice = priceTbx.Text.Trim();
            string image = carImage.ImageUrl;

            string response = "";
            errorLbl.Visible = true;
            if (imageUpload.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(imageUpload.FileName);
                int fileSize = imageUpload.PostedFile.ContentLength;

                response = fileController.IsFileValid(fileExtension, fileSize);
            }

            if (response == "")
            {
                if (imageUpload.HasFile)
                {
                    imageUpload.SaveAs(Server.MapPath("~/Assets/" + imageUpload.FileName));
                    image = "~/Assets/" + imageUpload.FileName;

                    carImage.ImageUrl = image;
                }

                response = carController.CheckUpdateCar(id, newBrand, newModel, image, int.Parse(newKilometer), int.Parse(newYear), newDesc, int.Parse(newPrice));

                if (response == "success") Response.Redirect("~/View/Home.aspx");
                else errorLbl.Text = response;

            }
            else
            {
                imageErrorLbl.Visible = true;
                imageErrorLbl.Text = response;
            }
        }
    }
}