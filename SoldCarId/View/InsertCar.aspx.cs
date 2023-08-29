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
    public partial class InsertCar : System.Web.UI.Page
    {
        CarController carController = new CarController();
        FileUploadController fileController = new FileUploadController();

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

        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            string newSeller = sellerTbx.Text.Trim();
            string newBrand = brandTbx.Text.Trim();
            string newModel = modelTbx.Text.Trim();
            string newKilometer = kilometerTbx.Text.Trim();
            string newYear = yearTbx.Text.Trim();
            string newDesc = descTbx.Text.Trim();
            string newPrice = priceTbx.Text.Trim();
            string image = "";

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
                    response = carController.InsertCar(int.Parse(newSeller), newBrand, newModel, image, int.Parse(newKilometer), int.Parse(newYear), newDesc, int.Parse(newPrice));

                    if (response == "success") Response.Redirect("~/View/home.aspx");
                    else errorLbl.Text = response;
                }
                else
                {
                    errorLbl.Text = "Please upload your file first!";
                }
            }
            else
            {
                errorLbl.Text = response;
            }
        }
    }
}