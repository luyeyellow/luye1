using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MyPhotos.BLL;
using MyPhotos.Model;
namespace WebApp.ajaxAdmin.handler
{
    /// <summary>
    /// _01_login 的摘要说明
    /// </summary>
    public class _01_login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string name = context.Request.Form["name"];
            string pwd = context.Request.Form["pwd"];
            string code = context.Request.Form["code"];
            //1 成功 2用户名不正确  3 密码错误 4 验证码错误
            if (context.Session["code"] != null && code.ToLower() == context.Session["code"].ToString().ToLower())
            {
                context.Session.Remove("code");
                int msg;
                User user;
                UserBLL bll = new UserBLL();
                if (bll.Login(name, pwd, out msg, out user))
                {
                    //记录登陆状态
                    context.Session["user"] = user;
                }
                context.Response.Write(msg);
            }
            else
            {
                context.Response.Write(4);
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