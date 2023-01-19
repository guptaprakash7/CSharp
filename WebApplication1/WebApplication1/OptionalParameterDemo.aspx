<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OptionalParameterDemo.aspx.cs" Inherits="WebApplication1.OptionalParameterDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
<table style="font-family:Arial; border:1px solid black">
    <tr>
        <td colspan="4" style="border-bottom: 1px solid black">
            <b>Search Employees</b>
        </td>
    </tr>
    <tr>
        <td>
            <b>Name</b>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </td>
        <td>
            <b>Email</b>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <b>Age</b>
        </td>
        <td>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
        </td>
        <td>
            <b>Gender</b>
        </td>
        <td>
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Text="Any Gender" Value="-1"></asp:ListItem>
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                          <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Button ID="btnSerach" runat="server" Text="Search" 
                onclick="btnSerach_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:GridView ID="gvEmployees" runat="server">
            </asp:GridView>
        </td>
    </tr>
</table>
        </div>
    </form>
</body>
</html>
