<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="05-Repeater.aspx.cs" Inherits="ServerControl._05_Repeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        * {
            margin:0px;
            padding:0px;
        }
        #p {
            list-style-type:none;
            width:700px;
        }
        #p li {
            float:left;
            margin-bottom:10px;
            margin-right:5px;
            border:1px solid red;
            text-align:center;
            width:150px;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
            <HeaderTemplate>
                <ul id="p">
            </HeaderTemplate>
            <ItemTemplate>
                    <li>
                        <img src="images/<%# Eval("PUrl") %>" width="150px" height="100px" />
                        <br />
                        <%# Eval("PTitle") %>
                    </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
   
        <asp:ObjectDataSource EnableCaching="true" CacheDuration="20" ID="ObjectDataSource1" runat="server" SelectMethod="GetAllPhotos" TypeName="MyPhotos.BLL.PhotoBLL"></asp:ObjectDataSource>
   
    </form>
</body>
</html>
