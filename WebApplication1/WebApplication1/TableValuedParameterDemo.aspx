<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableValuedParameterDemo.aspx.cs" Inherits="WebApplication1.TableValuedParameterDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			iu<asp:Button ID="btnFillDummyData" runat="server" Text="Fill Dummy Data"
    OnClick="btnFillDummyData_Click" />
<br /><br />
<table>
    <tr>
        <td>
            ID : <asp:TextBox ID="txtId1" runat="server"></asp:TextBox>
        </td>
        <td>
            Name : <asp:TextBox ID="txtName1" runat="server"></asp:TextBox>
        </td>
        <td>
            Gender : <asp:TextBox ID="txtGender1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            ID : <asp:TextBox ID="txtId2" runat="server"></asp:TextBox>
        </td>
        <td>
            Name : <asp:TextBox ID="txtName2" runat="server"></asp:TextBox>
        </td>
        <td>
            Gender : <asp:TextBox ID="txtGender2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            ID : <asp:TextBox ID="txtId3" runat="server"></asp:TextBox>
        </td>
        <td>
            Name : <asp:TextBox ID="txtName3" runat="server"></asp:TextBox>
        </td>
        <td>
            Gender : <asp:TextBox ID="txtGender3" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            ID : <asp:TextBox ID="txtId4" runat="server"></asp:TextBox>
        </td>
        <td>
            Name : <asp:TextBox ID="txtName4" runat="server"></asp:TextBox>
        </td>
        <td>
            Gender : <asp:TextBox ID="txtGender4" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            ID : <asp:TextBox ID="txtId5" runat="server"></asp:TextBox>
        </td>
        <td>
            Name : <asp:TextBox ID="txtName5" runat="server"></asp:TextBox>
        </td>
        <td>
            Gender : <asp:TextBox ID="txtGender5" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
<br />
<asp:Button ID="btnInsert" runat="server" Text="Insert Employees"
    OnClick="btnInsert_Click" />
        </div>
    </form>
</body>
</html>
