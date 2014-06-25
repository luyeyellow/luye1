using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControl
{
    public partial class _10_作业2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = Request.QueryString["page"];
                if (!int.TryParse(s, out pageIndex))
                {
                    pageIndex = 1;
                }

                BindRpt();
            }
        }
        int pageIndex = 1;
        int pageSize = 10;
        int pageCount;

        void BindRpt()
        {
            MyPhotos.BLL.PhotoBLL bll = new MyPhotos.BLL.PhotoBLL();
            Repeater1.DataSource = bll.GetPagedPhotos(pageIndex, pageSize, out pageCount);
            Repeater1.DataBind();


            CreatePageBar();
        }


        void CreatePageBar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<a href='10-作业2.aspx?page=1'>首页</a>");

            //上一页
            int n = pageIndex;
            if (n > 1) {
                n = n - 1;
            }
            sb.Append("&nbsp;&nbsp;<a href='10-作业2.aspx?page=" + n + "'>上一页</a>");

            //下一页
            n = pageIndex;
            if (n < pageCount)
            {
                n = n + 1;
            }

            sb.Append("&nbsp;&nbsp;<a href='10-作业2.aspx?page=" + n + "'>下一页</a>");

            sb.Append("&nbsp;&nbsp;<a href='10-作业2.aspx?page=" + pageCount + "'>尾页</a>");

            sb.Append("&nbsp;&nbsp;<span>"+pageIndex+"/"+pageCount+"</span>");

            sb.Append("&nbsp;&nbsp;<input id='t' type='text' value='"+pageIndex+"' style='width:50px' ><input type='button' id='btn' value='go' style='width:30px' >");

            ltPager.Text = sb.ToString();
        }

    }
}