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
    /// _07_getphotobypid 的摘要说明
    /// </summary>
    public class _07_getphotobypid : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string s = context.Request.QueryString["id"];
            int id;
            if (int.TryParse(s, out id))
            {
                PhotoBLL bll = new PhotoBLL();
                Photos p = bll.GetPhotoByPid(id);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsonStr = jss.Serialize(p);
                context.Response.Write(jsonStr);
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