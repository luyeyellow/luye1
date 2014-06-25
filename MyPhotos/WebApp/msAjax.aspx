<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msAjax.aspx.cs" Inherits="WebApp.msAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllPhotos" TypeName="MyPhotos.BLL.PhotoBLL"></asp:ObjectDataSource>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
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
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>
            &nbsp;</p>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                </asp:Timer>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
