using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MyPhotos.BLL;
using MyPhotos.Model;
namespace WebApp.ajaxAdmin.handler
{
    /// <summary>
    /// _06_add 的摘要说明
    /// </summary>
    public class _06_add : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string jsonStr = context.Request.Form["json"];
            //add 添加  update 修改
            string action = context.Request.Form["action"];
            //  json={"PTitle":"123","":""}
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Photos p = jss.Deserialize<Photos>(jsonStr);

            PhotoBLL bll = new PhotoBLL();
            if (bll.Save(p,action))
            {
                context.Response.Write(1);
            }
            else
            {
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