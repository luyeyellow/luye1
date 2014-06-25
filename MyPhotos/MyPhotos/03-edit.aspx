<%@ Page Language="C#" AutoEventWireup="true" CodeFile="03-edit.aspx.cs" Inherits="_03_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        相册：<select name="ptype"><%=options %></select><br />
        标题：<input type="text" name="txtTitle" value="<%=p.PTitle  %>" /><br />
        路径：<input type="text" name="txtUrl" value="<%= p.PUrl  %>" /><br />
        描述：<input type="text" name="txtDes" value="<%= p.PDes %>" /><br />
        <input type="submit" value="修改" /> <%=msg %>
    </form>
</body>
</html>
