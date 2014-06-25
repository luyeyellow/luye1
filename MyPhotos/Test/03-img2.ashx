<%@ WebHandler Language="C#" Class="_03_img2" %>

using System;
using System.Web;
using System.Drawing;
public class _03_img2 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/jpeg";

        string path = context.Request.MapPath("jk.jpg");
        using (Image img = Image.FromFile(path))
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawString("蒋坤", new Font("楷体", 30), Brushes.Red, 170, 80);

                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}