<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="02-dropdownlist.aspx.cs" Inherits="ServerControl._02_dropdownlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>自拍</asp:ListItem>
            <asp:ListItem Selected="True">美女</asp:ListItem>
            <asp:ListItem>风景</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
