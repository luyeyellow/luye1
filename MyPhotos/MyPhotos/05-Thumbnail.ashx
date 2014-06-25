<%@ WebHandler Language="C#" Class="_05_Thumbnail" %>

using System;
using System.Web;
using System.Drawing;
public class _05_Thumbnail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/jpeg";

        string path = context.Request.QueryString["path"];
        path = context.Request.MapPath("images/"+path);
        //原图
        using (Image bigImg = Image.FromFile(path))
        {
            //保持横纵比例
            int width = 150;
            int height = 100;

            if (bigImg.Width > bigImg.Height)
            {
                height = width * bigImg.Height / bigImg.Width;
            }
            else
            {
                width = height * bigImg.Width / bigImg.Height;
            }
            
            
            //缩略图
            using (Bitmap smallImg = new Bitmap(width,height))
            {
                using (Graphics g = Graphics.FromImage(smallImg))
                {
                    g.DrawImage(bigImg, 0, 0, smallImg.Width, smallImg.Height);

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