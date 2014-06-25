using MyPhotos.BLL;
using MyPhotos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //页面首次加载
                string s = Request.QueryString["id"];
                int pid;
                if (int.TryParse(s, out pid))
                {
                    ltUL.Text = GetPhotoByPid(pid);
                }
                else
                {
                    Response.Write("<script>alert('参数错误！！');location.href='Index.aspx'</script>");
                }
            }
        }
        private string GetPhotoByPid(int pid)
        {
            StringBuilder sb = new StringBuilder();

            PhotoBLL bll = new PhotoBLL();
            Photos p = bll.GetPhotoByPid(pid);

            sb.Append("<h1>" + p.PTitle + "</h1>");
            sb.Append(" <div id='screen'><a href='#'><img src='images/" + p.PUrl + "' width='660'  alt='" + p.PTitle + "' /></a></div>");
            sb.Append("<div id='info'>");
            sb.Append("<p>" + p.PDes + "</p>");
            sb.Append("</div><input type='hidden' id='hdPid' value='" + p.PId + "'/>");
            return sb.ToString();
        }
    }
}