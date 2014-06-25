using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using u = MyPhotos.Model;
using MyPhotos.BLL;
namespace WebApp.admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string code = Request.Form["txtCode"].ToLower();
                //判断验证码
                if (Session["code"] != null && code == Session["code"].ToString().ToLower())
                {
                    Session.Remove("code");
                    //
                    string name = Request.Form["txtName"];
                    string pwd = Request.Form["txtPwd"];
                    string msg;
                    u.User user;
                    UserBLL bll = new UserBLL();
                    if (bll.Login(name, pwd, out msg, out user))
                    {
                        //记录登陆状态
                        Session["user"] = user;
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Response.Write(msg);
                    }

                }
                else
                {
                    Response.Write("验证码错误");
                }
            }
        }
    }
}