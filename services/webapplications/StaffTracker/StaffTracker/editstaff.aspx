<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editstaff.aspx.cs" Inherits="StaffTracker.EditStaffForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Edit staff</title>
    <link rel="Stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="staffForm" action="modifystaff.aspx" runat="server">
        <p>
            <asp:HiddenField runat="server" ID="old_Id" />
            <asp:HiddenField runat="server" ID="action" />
        </p>
        <table>
            <tr>
                <th>Id</th>
                <td><asp:TextBox runat="server" ID="td_Id" /></td>
            </tr>
            <tr>
                <th>Name</th>
                <td><asp:TextBox runat="server" ID="td_Name" /></td>
            </tr>
            <tr>
                <th>Last name</th>
                <td><asp:TextBox runat="server" ID="td_LastName" /></td>
            </tr>
            <tr>
                <th>Room</th>
                <td><asp:DropDownList runat="server" ID="td_Room" /></td>
            </tr>
            <tr>
                <th>IP address</th>
                <td><asp:TextBox runat="server" ID="td_ipAddress" /></td>
            </tr>
            <tr>
                <td><input type="submit" value="Submit" /></td>
                <td><input type="reset" value="Reset" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
