<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stafftable.aspx.cs" Inherits="StaffTracker.WebForm1" %>
<%@ Import Namespace="StaffTracker.StaffServiceReference" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Staff table</title>
    <link rel="Stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <p><a href="editstaff.aspx">Add staff</a></p>

    <table>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Last name</th>
            <th>Room</th>
            <th>IP address</th>
        </tr>
        <%
            StaffServiceClient staffServiceClient = new StaffServiceClient();
            Staff[] staffMembers = staffServiceClient.QueryAllStaff();

            foreach (Staff staff in staffMembers)
            {
                %>
                <tr>
                    <td><a href="displaystaff.aspx?id=<%= staff.Id %>"><%= staff.Id %></a></td>
                    <td><%= staff.Name %></td>
                    <td><%= staff.LastName %></td>
                    <td><%= staff.Room %></td>
                    <td><%= staff.IpAddress %></td>
                    <td><a href="editstaff.aspx?id=<%= staff.Id %>">Edit</a></td>
                    <td><a href="modifystaff.aspx?action=delete&amp;id=<%= staff.Id %>">Delete</a></td>
                </tr>
                <%
            }

            staffServiceClient.Close();
        %>
    </table>
</body>
</html>
