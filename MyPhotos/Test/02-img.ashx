<%@ WebHandler Language="C#" Class="_02_img" %>

using System;
using System.Web;
using System.Drawing;  //gdi+
public class _02_img : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/jpeg";

        //画板
        using (Bitmap bitmap = new Bitmap(100, 30))
        { 
            //画笔
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                
                g.FillRectangle(Brushes.Red, 0, 0, bitmap.Width, bitmap.Height);
                g.FillRectangle(Brushes.White, 1, 1, bitmap.Width-2, bitmap.Height-2);
                
                
                g.DrawString("挨踢教瘦", new Font("微软雅黑", 15), Brushes.Red, 3, 3);

                bitmap.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}