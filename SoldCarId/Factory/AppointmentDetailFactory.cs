using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Factory
{
    public class AppointmentDetailFactory
    {
        public static AppointmentDetail createAppointmentDetail(int appointmetID, int carID, string location, DateTime appointmentDate)
        {
            AppointmentDetail appDetail = new AppointmentDetail();
            appDetail.AppointmentID = appointmetID;
            appDetail.CarID = carID;
            appDetail.Location = location;
            appDetail.AppointmentDate = appointmentDate;

            return appDetail;
        }
    }
}