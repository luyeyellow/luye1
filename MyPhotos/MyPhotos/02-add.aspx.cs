using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MyPhotos.Model;
using MyPhotos.BLL;
using System.Text;
public partial class _02_add : System.Web.UI.Page
{
    protected string options;
    protected string msg;
    protected Photos p = new Photos();
    protected void Page_Load(object sender, EventArgs e)
    {

        //加载下拉框中的项
        options = GetOptions();
        //表单提交
        if (IsPostBack)
        {
            p = new Photos();
            p.PTypeId = int.Parse(Request.Form["ptype"]);
            p.PTitle = Request.Form["txtTitle"];
            p.PDes = Request.Form["txtDes"];
            p.PUrl = Request.Form["txtUrl"];
            PhotoBLL bll = new PhotoBLL();
            if (bll.Add(p))
            {
                msg = "<script>alert('添加成功');location.href='01-PhotoList.aspx'</script>";
                //Response.Redirect("01-PhotoList.aspx");
            }
            else 
            {
                msg = "<script>alert('添加失败');</script>";
            }
            
        }
        else
        { 
            //页面第一次加载
        }


    }
    /// <summary>
    /// 加载下拉框中的项
    /// </summary>
    /// <returns></returns>
    private string GetOptions()
    {
        PhotoTypeBLL bll = new PhotoTypeBLL();
        List<PhotoType> list = bll.GetAllPhotoTypes();
        StringBuilder sb = new StringBuilder();
        foreach (PhotoType pt in list)
        {
            sb.Append("<option value='"+pt.TypeId+"'>"+pt.TypeName+"</option>");
        }
        return sb.ToString();
    }
}