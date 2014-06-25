﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MyPhotos.BLL;
using MyPhotos.Model;
namespace WebApp.ajaxAdmin.handler
{
    /// <summary>
    /// _03_getallphotos 的摘要说明
    /// </summary>
    public class _03_getallphotos : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            context.Response.Write(CreateTb());
            
        }
        private string CreateTb()
        {
            //获取所有数据
            PhotoBLL bll = new PhotoBLL();
            List<Photos> list = new List<Photos>();
            try
            {
                list = bll.GetAllPhotos();
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
                sb.Append("<td>" + (i + 1) + "</td>");
                sb.Append("<td><a href='04-details.aspx?id=" + p.PId + "'>" + p.PTitle + "</a></td>");
                sb.Append("<td><a href='04-details.aspx?id=" + p.PId + "'><img src='05-Thumbnail.ashx?path=" + p.PUrl + "' ></a></td>");
                sb.Append("<td>" + p.PClicks + "</td>");
                sb.Append("<td>" + p.PUp + "</td>");
                sb.Append("<td>" + p.PDown + "</td>");
                sb.Append("<td>" + p.PTime.Value.ToString("yyyy-MM-dd hh:mm:ss") + "</td>");
                sb.Append("<td><a href='03-edit.aspx?id=" + p.PId + "'>编辑</a> <a  href='javascript:void(0)' class='del' pid='"+p.PId+"'>删除</a></td>");
                sb.Append("</tr>");
            }

            sb.Append("</table>");
            return sb.ToString();
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