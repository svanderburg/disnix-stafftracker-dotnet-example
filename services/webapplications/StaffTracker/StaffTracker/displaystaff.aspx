<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="displaystaff.aspx.cs" Inherits="StaffTracker.DisplayStaffForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Display staff</title>
    <link rel="Stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <%
        String id = Request.Params["Id"];
        if (id == null)
        {
            %>
            <p>A staff identifier parameter needs to be specified!</p>
            <%
        }
        else
        {
            %>
            <table>
                <tr>
                    <th>Id</th>
                    <td runat="server" id="td_Id"></td>
                </tr>
                <tr>
                    <th>Name</th>
                    <td runat="server" id="td_Name"></td>
                </tr>
                <tr>
                    <th>Last name</th>
                    <td runat="server" id="td_LastName"></td>
                </tr>
                <tr>
                    <th>Room</th>
                    <td runat="server" id="td_Room"></td>
                </tr>
                <tr>
                    <th>Zip code</th>
                    <td runat="server" id="td_Zipcode"></td>
                </tr>
                <tr>
                    <th>Street</th>
                    <td runat="server" id="td_Street"></td>
                </tr>
                <tr>
                    <th>City</th>
                    <td runat="server" id="td_City"></td>
                </tr>
                <tr>
                    <th>IP address</th>
                    <td runat="server" id="td_ipAddress"></td>
                </tr>
                <tr>
                    <th>Computer location</th>
                    <td runat="server" id="td_location"></td>
                </tr>
            </table>
            <%
        }
    %>
    
</body>
</html>
