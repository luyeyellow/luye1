using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
namespace WebApp
{
    public class UrlRewriter:IHttpModule
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
            //   
            string rawUrl = app.Request.RawUrl;
            Regex regex = new Regex("/photo\\-(\\d{1,5})\\.htm");
            Match m =regex.Match(rawUrl);
            if (m.Success) 
            {
                string id = m.Groups[1].Value;
                app.Context.RewritePath("~/Details.aspx?id="+id);
            }
        }
    }
}