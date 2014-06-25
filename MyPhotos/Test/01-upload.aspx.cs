using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _01_upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //上传文件注意
        //1 客户端判断是否选择了文件
        //2 设置允许上传文件的大小
        //3 生成唯一的文件名
        //4 判断文件类型（服务器和客户端都要判断）

        if (Request.Files.Count > 0)
        {
            //浏览器上传的文件
            HttpPostedFile file = Request.Files[0];
            //判断是否选择了文件
            if (file.ContentLength > 0)
            {

                //判断文件的类型 
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/pjpeg")
                {
                    //获取浏览器上传过来的文件的名字
                    //string name = Path.GetFileName(file.FileName);
                    //生成唯一的文件名
                    //  .jpg
                    string ext = Path.GetExtension(file.FileName);

                    Random random = new Random();
                    string name = DateTime.Now.ToString("yyyyMMddhhmmss") + random.Next(10000, 100000) + ext;

                    string path = Request.MapPath("upload/" + name);
                    //保存文件
                    file.SaveAs(path);

                    Response.Write("保存成功");
                }
                else
                {
                    Response.Write("禁止上传");
                }
            }
            else
            {
                Response.Write("请选择文件");
            }
        }
    }
}