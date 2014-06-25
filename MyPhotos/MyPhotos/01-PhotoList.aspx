<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01-PhotoList.aspx.cs" Inherits="_01_PhotoList" %>

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
    <script src="jquery-1.7.2.js"></script>
    <script>
        $(function () {
            //设置表头
            $("#tb tr:eq(0)").css("background-color", "gray").css("height", "50");

            //隔行变色
            $("#tb tr:not(:first):even").css("background-color", "#DBB");
            $("#tb tr:not(:first):odd").css("background-color", "#AFA");

            //鼠标高亮显示
            var bg;
            $("#tb tr:not(:first)").hover(function () {
                bg = $(this).css("background-color");
                $(this).css("background-color", "white");

            }, function () {
                $(this).css("background-color", bg);
            });
        })
    </script>
</head>
<body>
    <center>
        <h3>教瘦de相册</h3>

        <br />
        <br />
        <a href="02-add.aspx">添加</a>
        <br />
        <%= table %>

        <%= pageBar %>

        <%= msg %>

    </center>
</body>
</html>
