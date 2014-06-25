using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyPhotos.Model.User u = Session["user"] as MyPhotos.Model.User;
            if (u != null)
            {
                Response.Write("欢迎" + u.UName + "登陆");
            }
            else
            {
                Response.Write("<script>alert('三八快乐');location.href='Login.aspx'</script>");
            }
        }
    }
}