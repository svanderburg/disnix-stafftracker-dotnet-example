using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffTracker.StaffServiceReference;

namespace StaffTracker
{
    public partial class ModifyStaffForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String action = Request.Params["action"];

            if (action != null)
            {
                StaffServiceClient staffServiceClient = new StaffServiceClient();

                if (action.Equals("insert"))
                {
                    Staff staff = new Staff();
                    staff.Id = Int32.Parse(Request.Params["td_Id"]);
                    staff.Name = Request.Params["td_Name"];
                    staff.LastName = Request.Params["td_LastName"];
                    staff.Room = Request.Params["td_Room"];
                    staff.IpAddress = Request.Params["td_ipAddress"];

                    staffServiceClient.InsertStaff(staff);
                }
                else if (action.Equals("update"))
                {
                    Staff staff = new Staff();
                    staff.Id = Int32.Parse(Request.Params["td_Id"]);
                    staff.Name = Request.Params["td_Name"];
                    staff.LastName = Request.Params["td_LastName"];
                    staff.Room = Request.Params["td_Room"];
                    staff.IpAddress = Request.Params["td_ipAddress"];

                    staffServiceClient.UpdateStaff(Int32.Parse(Request.Params["old_Id"]), staff);
                }
                else if (action.Equals("delete"))
                {
                    staffServiceClient.DeleteStaff(Int32.Parse(Request.Params["Id"]));
                }

                staffServiceClient.Close();

                Response.Status = "301 Moved Permanently";
                Response.AddHeader("Location", Request.ApplicationPath.TrimEnd('/') + "/stafftable.aspx");
            }
        }
    }
}