<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="07-ListView.aspx.cs" Inherits="ServerControl._07_ListView" %>

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
        <asp:ListView DataKeyNames="pid" ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="PIdLabel" runat="server" Text='<%# Eval("PId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PTypeIdLabel" runat="server" Text='<%# Eval("PTypeId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PTitleLabel" runat="server" Text='<%# Bind("PTitle") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PUrlLabel" runat="server" Text='<%# Eval("PUrl") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PDesLabel" runat="server" Text='<%# Eval("PDes") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PClicksLabel" runat="server" Text='<%# Eval("PClicks") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PTimeLabel" runat="server" Text='<%# Eval("PTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PUpLabel" runat="server" Text='<%# Eval("PUp") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PDownLabel" runat="server" Text='<%# Eval("PDown") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td>
                        <asp:TextBox ID="PIdTextBox" runat="server" Text='<%# Bind("PId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PTypeIdTextBox" runat="server" Text='<%# Bind("PTypeId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PTitleTextBox" runat="server" Text='<%# Eval("PTitle") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PUrlTextBox" runat="server" Text='<%# Bind("PUrl") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PDesTextBox" runat="server" Text='<%# Bind("PDes") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PClicksTextBox" runat="server" Text='<%# Bind("PClicks") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PTimeTextBox" runat="server" Text='<%# Bind("PTime") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PUpTextBox" runat="server" Text='<%# Bind("PUp") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PDownTextBox" runat="server" Text='<%# Bind("PDown") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>未返回数据。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <td>
                        <asp:TextBox ID="PIdTextBox" runat="server" Text='<%# Bind("PId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PTypeIdTextBox" runat="server" Text='<%# Bind("PTypeId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PTitleTextBox" runat="server" Text='<%# Bind("PTitle") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PUrlTextBox" runat="server" Text='<%# Bind("PUrl") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PDesTextBox" runat="server" Text='<%# Bind("PDes") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PClicksTextBox" runat="server" Text='<%# Bind("PClicks") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PTimeTextBox" runat="server" Text='<%# Bind("PTime") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PUpTextBox" runat="server" Text='<%# Bind("PUp") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PDownTextBox" runat="server" Text='<%# Bind("PDown") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="PIdLabel" runat="server" Text='<%# Eval("PId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PTypeIdLabel" runat="server" Text='<%# Eval("PTypeId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PTitleLabel" runat="server" Text='<%# Eval("PTitle") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PUrlLabel" runat="server" Text='<%# Eval("PUrl") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PDesLabel" runat="server" Text='<%# Eval("PDes") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PClicksLabel" runat="server" Text='<%# Eval("PClicks") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PTimeLabel" runat="server" Text='<%# Eval("PTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PUpLabel" runat="server" Text='<%# Eval("PUp") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PDownLabel" runat="server" Text='<%# Eval("PDown") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server"></th>
                                    <th runat="server">PId</th>
                                    <th runat="server">PTypeId</th>
                                    <th runat="server">PTitle</th>
                                    <th runat="server">PUrl</th>
                                    <th runat="server">PDes</th>
                                    <th runat="server">PClicks</th>
                                    <th runat="server">PTime</th>
                                    <th runat="server">PUp</th>
                                    <th runat="server">PDown</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="PIdLabel" runat="server" Text='<%# Eval("PId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PTypeIdLabel" runat="server" Text='<%# Eval("PTypeId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PTitleLabel" runat="server" Text='<%# Eval("PTitle") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PUrlLabel" runat="server" Text='<%# Eval("PUrl") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PDesLabel" runat="server" Text='<%# Eval("PDes") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PClicksLabel" runat="server" Text='<%# Eval("PClicks") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PTimeLabel" runat="server" Text='<%# Eval("PTime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PUpLabel" runat="server" Text='<%# Eval("PUp") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PDownLabel" runat="server" Text='<%# Eval("PDown") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="MyPhotos.Model.Photos" DeleteMethod="Delete" InsertMethod="Add" SelectMethod="GetAllPhotos" TypeName="MyPhotos.BLL.PhotoBLL" UpdateMethod="Update"></asp:ObjectDataSource>
    </form>
</body>
</html>
