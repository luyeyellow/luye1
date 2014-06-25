<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebApp.Details" %>
<%@ OutputCache Duration="20" VaryByParam="*" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="content">
         <asp:Literal ID="ltUL" runat="server"></asp:Literal>

         <div id="comments">
            <h2>评论列表</h2>
        </div>
        <h2>
            发表评论：</h2>
        <div id="respond">
           
            <p>
               
                <textarea name="message" id="message" cols="100%" rows="10"></textarea>
                <label id="lbl" for="message" style="display: none;">
                    <small>请输入评论内容！</small></label>
            </p>
            <p>
                <input name="button" type="button" id="submit" value="&#21457;&#34920;" />
                &nbsp;
                <input name="reset" type="reset" id="reset" tabindex="5" value="&#37325;&#32622;" />

              <span id="msg"></span>
            </p>
            
        </div>
     </div>
</asp:Content>
