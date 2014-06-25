<%@ Page Language="C#" AutoEventWireup="true" CodeFile="04-details.aspx.cs" Inherits="_04_details" %>

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
   <center>
       <h3>图片详细信息</h3>

       <a href="01-PhotoList.aspx">返回列表</a>

       <%= table %>
   </center>
</body>
</html>
