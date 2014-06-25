<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="03-ddl.aspx.cs" Inherits="ServerControl._03_ddl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="TypeName" DataValueField="TypeId" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllPhotoTypes" TypeName="MyPhotos.BLL.PhotoTypeBLL"></asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
