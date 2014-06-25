<%@ WebHandler Language="C#" Class="_06_WaterMaker" %>

using System;
using System.Web;
using System.Drawing;
public class _06_WaterMaker : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/jpeg";
        //原图
        string path = context.Request.QueryString["path"];
        path = context.Request.MapPath("images/"+path);
        //水印
        string logoPath = context.Request.MapPath("images/logo.png");

        //原图
        using (Image img = Image.FromFile(path))
        {
            //logo
            using (Image logoImg = Image.FromFile(logoPath))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    int x = img.Width - logoImg.Width;
                    int y = img.Height - logoImg.Height;
                    g.DrawImage(logoImg, x, y, logoImg.Width, logoImg.Height);
                    img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}