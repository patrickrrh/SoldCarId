using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Factory
{
    public class AppointmentHeaderFactory
    {
        public static AppointmentHeader createAppointmentHeader(int userID, DateTime bookingDate)
        {
            AppointmentHeader appHeader = new AppointmentHeader();
            appHeader.UserID = userID;
            appHeader.BookingDate = bookingDate;

            return appHeader;
        }
    }
}