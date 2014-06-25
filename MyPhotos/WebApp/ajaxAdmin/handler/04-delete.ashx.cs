using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPhotos.BLL;
namespace WebApp.ajaxAdmin.handler
{
    /// <summary>
    /// _04_delete 的摘要说明
    /// </summary>
    public class _04_delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string s = context.Request.QueryString["id"];
            int id;
            if (int.TryParse(s,out id))
            {
                PhotoBLL bll = new PhotoBLL();
                if (bll.Delete(id))
                {
                    context.Response.Write(1);
                }
                else
                {
                    context.Response.Write(0);
                }
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