using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffTracker.StaffServiceReference;
using StaffTracker.RoomServiceReference;

namespace StaffTracker
{
    public partial class EditStaffForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoomServiceClient roomServiceClient = new RoomServiceClient();
            string[] roomIdentifiers = roomServiceClient.QueryAllRoomIdentifiers();
            
            td_Room.DataSource = roomIdentifiers;
            td_Room.DataBind();

            String id = Request.Params["id"];

            if (id == null)
            {
                action.Value = "insert";
            }
            else
            {
                StaffServiceClient staffServiceClient = new StaffServiceClient();
                Staff staff = staffServiceClient.QueryStaff(Int32.Parse(id));

                action.Value = "update";
                old_Id.Value = id;

                td_Id.Text = staff.Id.ToString();
                td_Name.Text = staff.Name;
                td_LastName.Text = staff.LastName;
                td_Room.SelectedValue = staff.Room;
                td_ipAddress.Text = staff.IpAddress;

                staffServiceClient.Close();
            }

            roomServiceClient.Close();
        }
    }
}