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
    public partial class Carts : System.Web.UI.Page
    {
        UserController userController = new UserController();
        CartController cartController = new CartController();
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
                    Response.Redirect("~/View/Home.aspx");
                }
                else MasterPageFile = "~/View/Master/Customer.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataRebinding();
            }
        }

        protected void DataRebinding()
        {
            List<Cart> cart = cartController.GetCustomerCart(user.UserID);
            cartGrid.DataSource = cart;
            cartGrid.DataBind();
            if (cartGrid.Rows.Count == 0)
            {
                isEmptyLbl.Text = "Your cart is empty. Add a car first!";
            }
        }



        protected void cartGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = cartGrid.Rows[e.RowIndex];
            int carId = int.Parse(row.Cells[1].Text);
            errorLbl.Visible = true;
            errorLbl.CssClass = "success-message";
            errorLbl.Text = cartController.DeleteCartItem(carId, user.UserID);

            DataRebinding();
        }

        protected void checkoutBtn_Click(object sender, EventArgs e)
        {
            errorLbl.Visible = true;
            if (cartGrid.Rows.Count == 0)
            {
                errorLbl.CssClass = "error-message";
                errorLbl.Text = "Your cart is empty!";
            }
            else
            {
                string response = cartController.Checkout(user.UserID);
                errorLbl.CssClass = response.Contains("An error occured, please try again later!") ? "error-message" : "success-message";
                errorLbl.Text = response;
                DataRebinding();
            }
        }
    }
}