using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //Response.Write("hello world");

            //判断请求是否是访问images/*.jpg
            //string rawUrl = Request.RawUrl.ToLower();
            //if (rawUrl.Contains("/images/"))
            //{
            //    //当前请求
            //    Uri url = Request.Url;
            //    //上一次请求
            //    Uri referrer = Request.UrlReferrer;
            //    if (!CompareUrl(url, referrer))
            //    {
            //        Response.ContentType = "image/jpeg";
            //        //输出盗链图片
            //        string path = Request.MapPath("~/images/daolian.jpg");
            //        Response.WriteFile(path);
            //    }
            //}
        }

        private bool CompareUrl(Uri u1, Uri u2)
        {
            return Uri.Compare(u1, u2, UriComponents.HostAndPort, UriFormat.SafeUnescaped, StringComparison.CurrentCultureIgnoreCase) == 0;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

       


        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

       

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}