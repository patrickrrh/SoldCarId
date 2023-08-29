using SoldCarId.Factory;
using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Repository
{
    public class AppointmentRepository
    {
        Database1Entities db = Database.getDb();

        public int AddAppointment(int customerId, List<Cart> cartList)
        {
            AddToAppointmentHeader(customerId, cartList);
            return db.SaveChanges();
        }

        public void AddToAppointmentHeader(int customerId, List<Cart> cartList)
        {
            AppointmentHeader appHeader = AppointmentHeaderFactory.createAppointmentHeader(customerId, DateTime.Now);
            db.AppointmentHeaders.Add(appHeader);

            AddToAppointmentDetail(appHeader.AppointmentID, cartList);
        }

        public void AddToAppointmentDetail(int appId, List<Cart> cartList)
        {
            List<AppointmentDetail> appDetailList = new List<AppointmentDetail>();
            for (int i = 0; i < cartList.Count; i++)
            {
                AppointmentDetail appDetail = AppointmentDetailFactory.createAppointmentDetail(appId, cartList[i].CarID, cartList[i].Location, cartList[i].AppointmentDate);
                appDetailList.Add(appDetail);
            }

            db.AppointmentDetails.AddRange(appDetailList);
        }

        public List<AppointmentHeader> GetCustomerAppointment(int custId)
        {
            return (from app in db.AppointmentHeaders
                    where app.UserID.Equals(custId)
                    orderby app.BookingDate descending
                    select app).ToList();
        }

        public List<AppointmentHeader> GetAllAppointment()
        {
            return db.AppointmentHeaders.ToList();
        }


    }
}