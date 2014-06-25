using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class 页面缓存 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int n = 0;
            int m = 5 / n;

            //页面缓存：  页面数据不经常发生变化，页面执行速度比较慢
            Response.Write(DateTime.Now.ToString());
        }
    }
}