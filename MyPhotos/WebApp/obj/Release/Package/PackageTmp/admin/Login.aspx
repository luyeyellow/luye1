<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        用户名：<input type="text" name="txtName" /><br />
        密码：<input type="text" name="txtPwd" /><br />
        验证码：<input type="text" name="txtCode" /><img title="看不清？" style="cursor:pointer" onclick="this.src='ValidateCode.ashx?_='+Math.random()" src="ValidateCode.ashx" /><br />
        <input type="submit" value="Login" />
    </form>
</body>
</html>
