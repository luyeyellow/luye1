<%@ WebHandler Language="C#" Class="_04_thumbnail" %>

using System;
using System.Web;
using System.Drawing;
public class _04_thumbnail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/jpeg";

        string path = context.Request.MapPath("03.jpg");

       
        
        //原图
        using (Image bigImg = Image.FromFile(path))
        { 
            //小图
            using (Bitmap smallImg = new Bitmap(150, 100))
            {
                using (Graphics g = Graphics.FromImage(smallImg))
                {
                    g.DrawImage(bigImg, 0, 0,smallImg.Width,smallImg.Height);

                    smallImg.Save(context.Response.OutputStream,System.Drawing.Imaging.ImageFormat.Jpeg);
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