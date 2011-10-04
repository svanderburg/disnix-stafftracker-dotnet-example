using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffTracker.StaffServiceReference;
using StaffTracker.RoomServiceReference;
using StaffTracker.ZipcodeServiceReference;
using StaffTracker.GeolocationServiceReference;

namespace StaffTracker
{
    public partial class DisplayStaffForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request.Params["Id"];
            if (id != null)
            {
                StaffServiceClient staffServiceClient = new StaffServiceClient();
                Staff staff = staffServiceClient.QueryStaff(Int32.Parse(id));

                RoomServiceClient roomServiceClient = new RoomServiceClient();
                Room room = roomServiceClient.QueryRoom(staff.Room);

                ZipcodeServiceClient zipcodeServiceClient = new ZipcodeServiceClient();
                Zipcode zipcode = zipcodeServiceClient.QueryZipcode(room.Zipcode);

                GeolocationServiceClient geolocationServiceClient = new GeolocationServiceClient();
                String location = geolocationServiceClient.GetCountry(staff.IpAddress);

                td_Id.InnerText = staff.Id.ToString();
                td_Name.InnerText = staff.Name;
                td_LastName.InnerText = staff.LastName;
                td_Room.InnerText = staff.Room;
                td_Zipcode.InnerText = room.Zipcode;
                td_Street.InnerText = zipcode.Street;
                td_City.InnerText = zipcode.City;
                td_ipAddress.InnerText = staff.IpAddress;
                td_location.InnerText = location;

                geolocationServiceClient.Close();
                zipcodeServiceClient.Close();
                roomServiceClient.Close();
                staffServiceClient.Close();
            }
        }
    }
}