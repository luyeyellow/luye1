<%@ WebHandler Language="C#" Class="_07_download" %>

using System;
using System.Web;

public class _07_download : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";


        string filename = context.Request.QueryString["url"];
        string path = context.Request.MapPath("images/" + filename);

        //url编码 ，解决ie中中文文件名乱码的问题
        filename = HttpUtility.UrlEncode(filename);
        //设置相应头
        context.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        
        context.Response.WriteFile(path);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}