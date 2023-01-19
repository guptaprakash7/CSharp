<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisconnectedDatabaseDemo.aspx.cs" Inherits="WebApplication1.DisconnectedDatabaseDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <asp:Button ID="btnGetDataFromDB" runat="server" Text="Get Data from Database" 
        onclick="btnGetDataFromDB_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" onrowediting="GridView1_RowEditing" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdeleting="GridView1_RowDeleting" 
        onrowupdating="GridView1_RowUpdating">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" 
                SortExpression="Gender" />
            <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" 
                SortExpression="TotalMarks" />
        </Columns>
    </asp:GridView>
              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <asp:Button ID="btnUpdateDatabaseTable" runat="server" 
        Text="Update Database Table" onclick="btnUpdateDatabaseTable_Click" />
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
              <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
