using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPhotos.BLL;
using MyPhotos.Model;
using System.Text;
public partial class _01_PhotoList : System.Web.UI.Page
{
    protected string table;
    protected string msg;
    protected string pageBar;
    protected void Page_Load(object sender, EventArgs e)
    {
        //接收页码
        string ss = Request.QueryString["page"];
        if (!int.TryParse(ss, out pageIndex))
        {
            //转换失败，获取第一页数据
            pageIndex = 1;
        }


        //接收url上的id
        string s = Request.QueryString["id"];
        int id;
        if (int.TryParse(s, out id))
        {
            PhotoBLL bll = new PhotoBLL();
            if (bll.Delete(id))
            {
                //Response.Write("删除成功");
                msg = "<script>alert('删除成功')</script>";
            }
            else
            {
                //Response.Write("删除失败");
                msg = "<script>alert('删除失败')</script>";
            }
        }

        table = CreateTb();

        //生成页码条
        pageBar = CreatePagebar();
    }


    private int pageIndex=1;
    private int pageSize=10;
    private int pageCount;

    /// <summary>
    /// 生成页码条
    /// </summary>
    /// <returns></returns>
    private string CreatePagebar()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<a href='01-PhotoList.aspx?page=1'>首页</a>");

        //上一页
        int n = pageIndex;
        if (n > 1)
        {
            n = pageIndex - 1;
        }
        sb.Append("&nbsp;&nbsp;<a href='01-PhotoList.aspx?page=" + n + "'>上一页</a>");

        //下一页
        n = pageIndex;
        if (n < pageCount)
        {
            n = pageIndex + 1;
        }
        sb.Append("&nbsp;&nbsp;<a href='01-PhotoList.aspx?page=" + n + "'>下一页</a>");

        sb.Append("&nbsp;&nbsp;<a href='01-PhotoList.aspx?page="+pageCount+"'>尾页</a>");

        sb.Append("&nbsp;&nbsp;<span>"+pageIndex+"/"+pageCount+"</span>");
        return sb.ToString();
    }

    private string CreateTb()
    { 
        //获取所有数据
        PhotoBLL bll = new PhotoBLL();
        List<Photos> list = new List<Photos>();
        try
        {
             list = bll.GetPagedPhotos(pageIndex,pageSize,out pageCount);
        }
        catch (Exception ex)
        {
            //把错误记录日志  log.txt ex.StackTrace
            return ex.Message;
        }

        

        StringBuilder sb = new StringBuilder();
        sb.Append("<table id='tb' cellspacing='0px'>");
        //表头
        sb.Append("<tr><th>序号</th><th>标题</th><th>图片</th><th>点击次数</th><th>支持</th><th>反对</th><th>时间</th><th>操作</th></tr>");
        //数据行
        for (int i = 0; i < list.Count; i++)
        {
            Photos p = list[i];
            sb.Append("<tr>");
            sb.Append("<td>"+ (i+1) +"</td>");
            sb.Append("<td><a href='04-details.aspx?id="+p.PId+"'>" + CutTitle(p.PTitle) + "</a></td>");
            sb.Append("<td><a href='04-details.aspx?id=" + p.PId + "'><img src='05-Thumbnail.ashx?path=" + p.PUrl + "' ></a></td>");
            sb.Append("<td>" + p.PClicks +"</td>");
            sb.Append("<td>" + p.PUp +"</td>");
            sb.Append("<td>" + p.PDown +"</td>");
            sb.Append("<td>" + p.PTime.Value.ToString("yyyy-MM-dd hh:mm:ss")+"</td>");
            sb.Append("<td><a href='03-edit.aspx?id=" + p.PId + "'>编辑</a> <a onclick='return confirm(\"确定删除？\")' href='01-PhotoList.aspx?id=" + p.PId + "'>删除</a><a href='07-download.ashx?url="+p.PUrl+"'>下载</a></td>");
            sb.Append("</tr>");
        }

        sb.Append("</table>");
        return sb.ToString();
    }

    private string CutTitle(string title)
    {
        if (title.Length > 8)
        {
           title =  title.Substring(0, 8) + "...";
        }

        return title;
    }
}