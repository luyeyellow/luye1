using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPhotos.Model;
using MyPhotos.BLL;
using System.Text;
public partial class _04_details : System.Web.UI.Page
{
    protected string table;
    protected void Page_Load(object sender, EventArgs e)
    {
        string s = Request.QueryString["id"];
        int id;
        if (int.TryParse(s, out id))
        {
            PhotoBLL bll = new PhotoBLL();
            Photos p = bll.GetPhotoByPid(id);

            if (p != null)
            {
                //更新点击次数
                bll.UpdateClicks(id);
                //获取表格
                table = GetTable(p);
            }
            else
            {
                table = "对不起，没找到您要查看的图片";
            }
        }
        else
        {
            table = "参数错误！！！！";
        }
    }

    private string GetTable(Photos p)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<table id='tb' cellspacing='0px'>");
        sb.Append("<tr><td>标题</td><td>"+p.PTitle+"</td></tr>");

        sb.Append("<tr><td>图片</td><td><img src='images/"+p.PUrl+"' width='600px'></td></tr>");
        sb.Append("<tr><td>时间</td><td>" + p.PTime.Value + "</td></tr>");
        sb.Append("<tr><td>描述</td><td>" + p.PDes + "</td></tr>");
        sb.Append("</table>");
        return sb.ToString();
    }
}