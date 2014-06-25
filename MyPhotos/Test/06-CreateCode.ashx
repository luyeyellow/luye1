<%@ WebHandler Language="C#" Class="_06_CreateCode" %>

using System;
using System.Web;
using System.Drawing;
public class _06_CreateCode : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";
        string code = CreateCode();

        using (Image img = CreateImg(code))
        {
            img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }

    Image CreateImg(string code)
    {
        Bitmap bitmap = new Bitmap(80, 30);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.Black, 0, 0, bitmap.Width, bitmap.Height);
                g.FillRectangle(Brushes.White, 1,1 , bitmap.Width-2, bitmap.Height-2);

                g.DrawString(code, new Font("宋体", 20), Brushes.Red, 3, 3);
                return bitmap;
            }
    }
    
    string CreateCode()
    {
        string result = "";
        string s = "01234567abcdefgh";
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            int index = random.Next(0, s.Length);
            result += s[index];
        }
        return result;
    }
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}