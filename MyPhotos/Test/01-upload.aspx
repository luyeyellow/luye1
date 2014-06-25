<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01-upload.aspx.cs" Inherits="_01_upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        window.onload = function () {
            document.getElementById("btn").onclick = function () {
                var name = document.getElementById("file").value;
                if (name.length == 0)
                {
                    //没选择文件
                    alert("请选择文件");
                    return false;
                }
                //jpg
                var ext = name.substr(name.lastIndexOf(".") + 1).toLocaleLowerCase();
                if (ext != "jpg") {
                    alert("禁止上传");
                    return false;
                }


                return true;
            }
        }

    </script>
</head>
<body>
   <form method="post" action="01-upload.aspx" enctype="multipart/form-data">
       <input type="text" name="title" />
       <input id="file" name="file" type="file" />
       <input id="btn" type="submit" value="upload" />
   </form>
</body>
</html>
