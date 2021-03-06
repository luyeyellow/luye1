﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="09-作业1.aspx.cs" Inherits="ServerControl._09_作业1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style>
        #tb {
            border:1px solid red;
            border-collapse:collapse;
            width:700px;
        }
        #tb td, #tb th {
           border:1px solid red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:DropDownList ID="ddlPhotoTypes" runat="server" AutoPostBack="True" DataSourceID="odsPhotoType" DataTextField="TypeName" DataValueField="TypeId" OnSelectedIndexChanged="ddlPhotoTypes_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="odsPhotoType" runat="server" SelectMethod="GetAllPhotoTypes" TypeName="MyPhotos.BLL.PhotoTypeBLL"></asp:ObjectDataSource>
        <asp:Repeater ID="rptPhotos" runat="server">
                 <HeaderTemplate>
                <table id="tb" cellspacing="0px">
                    <tr>
                        <th>序号</th><th>标题</th><th>图片</th><th>点击次数</th><th>支持</th><th>反对</th><th>时间</th><th>操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td><%# Container.ItemIndex + 1 %></td>
                        <td><%#  Eval("PTitle") %></td>
                        <td><img src="images/<%# Eval("PUrl") %>" width="150px" height="100px" /></td>
                        <td>
                            <asp:Label ID="lblClicks" runat="server" Text='<%# Eval("PClicks") %>'></asp:Label>
                        </td>
                        <td><%# Eval("PUp") %>

                            <asp:ImageButton CommandName="up" CommandArgument='<%# Eval("Pid") %>' ID="btnUp" ImageUrl="~/85.gif" runat="server" />
                        </td>
                        <td><%# Eval("PDown") %>

                            <asp:ImageButton CommandName="down" CommandArgument='<%# Eval("Pid") %>' ID="btnDown" ImageUrl="~/86.gif" runat="server" />
                        </td>
                        <td><%# Eval("Ptime","{0:yyyy-MM-dd hh:mm:ss}") %></td>
                        <td>
                            <asp:LinkButton OnClientClick="return confirm('确认删除')" CommandName="delete" CommandArgument='<%# Eval("Pid") %>' ID="btnDelete" runat="server">删除</asp:LinkButton>
                            </td>
                    </tr>
            </ItemTemplate>
           <%-- <SeparatorTemplate>
                    <tr>
                       <td colspan="8">
                           <hr />
                       </td>
                    </tr>
            </SeparatorTemplate>--%>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
