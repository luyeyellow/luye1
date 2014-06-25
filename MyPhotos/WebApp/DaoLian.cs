using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class DaoLian:IHttpModule
    {

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            //判断请求是否是访问images/*.jpg
            string rawUrl = app.Request.RawUrl.ToLower();
            if (rawUrl.Contains("/images/"))
            {
                //当前请求
                Uri url = app.Request.Url;
                //上一次请求
                Uri referrer = app.Request.UrlReferrer;
                if (!CompareUrl(url, referrer))
                {
                    app.Response.ContentType = "image/jpeg";
                    //输出盗链图片
                    string path = app.Request.MapPath("~/images/daolian.jpg");
                    app.Response.WriteFile(path);
                    //结束
                    app.Response.End();
                }
            }
        }
        private bool CompareUrl(Uri u1, Uri u2)
        {
            return Uri.Compare(u1, u2, UriComponents.HostAndPort, UriFormat.SafeUnescaped, StringComparison.CurrentCultureIgnoreCase) == 0;
        }
    }
}