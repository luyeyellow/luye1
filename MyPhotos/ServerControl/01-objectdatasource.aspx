<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="01-objectdatasource.aspx.cs" Inherits="ServerControl._01_objectdatasource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllPhotos" TypeName="MyPhotos.BLL.PhotoBLL">
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:BoundField DataField="PId" HeaderText="PId" SortExpression="PId" />
                <asp:BoundField DataField="PTypeId" HeaderText="PTypeId" SortExpression="PTypeId" />
                <asp:BoundField DataField="PTitle" HeaderText="PTitle" SortExpression="PTitle" />
                <asp:BoundField DataField="PUrl" HeaderText="PUrl" SortExpression="PUrl" />
                <asp:BoundField DataField="PDes" HeaderText="PDes" SortExpression="PDes" />
                <asp:BoundField DataField="PClicks" HeaderText="PClicks" SortExpression="PClicks" />
                <asp:BoundField DataField="PTime" HeaderText="PTime" SortExpression="PTime" />
                <asp:BoundField DataField="PUp" HeaderText="PUp" SortExpression="PUp" />
                <asp:BoundField DataField="PDown" HeaderText="PDown" SortExpression="PDown" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
