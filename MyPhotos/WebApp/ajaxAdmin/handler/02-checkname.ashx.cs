using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPhotos.BLL;
namespace WebApp.ajaxAdmin.handler
{
    /// <summary>
    /// _02_checkname 的摘要说明
    /// </summary>
    public class _02_checkname : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string name = context.Request.QueryString["n"];

            UserBLL bll = new UserBLL();
            if (bll.CheckName(name))
            {
                //用户名可用
                context.Response.Write(1);
            }
            else
            {
                //不可用
                context.Response.Write(0);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}