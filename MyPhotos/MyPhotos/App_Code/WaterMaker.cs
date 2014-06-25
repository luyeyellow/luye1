using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
/// <summary>
/// WaterMaker 的摘要说明
/// </summary>
public class WaterMaker:IHttpHandler
{

    public bool IsReusable
    {
        get {
            return true;
        }
    }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";

        //获取请求文件的绝对路径
        string path = context.Request.MapPath(context.Request.RawUrl);
        //
        string logoPath = context.Request.MapPath("logo.png");

        //原图
        using (Image img = Image.FromFile(path))
        {
            //logo
            using (Image logoImg = Image.FromFile(logoPath))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    int x = 0;
                    int y = 0;
                    g.DrawImage(logoImg, x, y, logoImg.Width, logoImg.Height);
                    img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
}