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
    public partial class AppointmentHistory : System.Web.UI.Page
    {
        UserController userController = new UserController();
        AppointmentController appController = new AppointmentController();
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
            List<AppointmentHeader> trs = appController.GetCustomerAppointment(user.UserID);
            transactionGrid.DataSource = trs;
            transactionGrid.DataBind();
            if (transactionGrid.Rows.Count == 0)
            {
                isEmptyLbl.Text = "Your dont have appointment. Checkout first!";
            }
            else
            {
                transactionGrid.RowDataBound += transactionGrid_RowDataBound;
            }
        }

        protected void transactionGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AppointmentHeader appointmentHeader = (AppointmentHeader)e.Row.DataItem;

                List<AppointmentDetail> AppointmentDetails = appointmentHeader.AppointmentDetails.ToList();

                GridView transactionDetailGrid = (GridView)e.Row.FindControl("transactionDetailGrid");

                transactionDetailGrid.DataSource = AppointmentDetails;
                transactionDetailGrid.DataBind();
            }
        }
    }
}