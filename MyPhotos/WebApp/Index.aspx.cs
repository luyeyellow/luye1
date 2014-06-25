using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPhotos.BLL;
using MyPhotos.Model;
using System.Text;
using System.Web.Caching;
namespace WebApp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string str;
            if (Cache["data"] == null)
            {
                //如果缓存中没数据，执行，并缓存
                str = LoadUL();
                //Cache["data"] = str;
               

                //依赖于文件的缓存依赖
                //string path = Request.MapPath("log/test.txt");
                //CacheDependency cd = new CacheDependency(path);
                //Cache.Insert("data", str, cd);

                //依赖于数据库的缓存依赖
                SqlCacheDependency sdc = new SqlCacheDependency("myphotos", "photos");
                Cache.Insert("data", str, sdc);

                
                Response.Write("读取数据库");
                //Context.Cache
            }
            else
            {
                Response.Write("读取缓存");
                str = Cache["data"].ToString();
            }
            //请求开始的时间- 当前时间
            TimeSpan ts = Context.Timestamp - DateTime.Now;
            Response.Write(ts.TotalMilliseconds);

            ltUL.Text = str;
        }

        string LoadUL()
        {
            PhotoBLL bll = new PhotoBLL();
            List<Photos> list = bll.GetAllPhotos();

            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");

            foreach (Photos p in list)
            {
                sb.Append("<li>");
                sb.Append("<div class='name'>"+p.PTitle+"</div>");
                sb.Append("<div class='screen'><a href='photo-"+p.PId+".htm'><img src='images/" + p.PUrl + "' width='200px' height='200px' alt='' /></a></div>");
                sb.Append("</li>");
            }

            sb.Append("</ul>");

            return sb.ToString();
        }
    }
}