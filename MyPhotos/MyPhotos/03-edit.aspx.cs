using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPhotos.BLL;
using MyPhotos.Model;
using System.Text;
public partial class _03_edit : System.Web.UI.Page
{
    protected Photos p = new Photos();
    protected string options;
    protected string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        string s = Request.QueryString["id"];
        int id;
        if (int.TryParse(s,out id))
        {
            if (!IsPostBack)
            {
                //窗体加载，显示当前要编辑的图片信息
                PhotoBLL bll = new PhotoBLL();
                p = bll.GetPhotoByPid(id);
                options = GetOptions(p.PTypeId);
            }
            else
            { 
                //表单提交
                p.PTypeId = int.Parse(Request.Form["ptype"]);
                p.PTitle = Request.Form["txtTitle"];
                p.PUrl = Request.Form["txtUrl"];
                p.PDes = Request.Form["txtDes"];
                p.PId = id;

                options = GetOptions(p.PTypeId);

                PhotoBLL bll = new PhotoBLL();
                if (bll.Update(p))
                {
                    msg = "<script>alert('修改成功');location.href='01-PhotoList.aspx'</script>";
                }
                else
                {
                    msg = "<script>alert('修改失败');</script>";
                }

            }
        }
    }

    private string GetOptions(int tid)
    {
        PhotoTypeBLL bll = new PhotoTypeBLL();
        List<PhotoType> list = bll.GetAllPhotoTypes();
        StringBuilder sb = new StringBuilder();
        foreach (PhotoType pt in list)
        {
            //显示当前图片对应的相册
            string selected = "";
            if (pt.TypeId == tid)
            {
                selected = "selected";
            }
            sb.Append("<option "+selected+" value='" + pt.TypeId + "'>" + pt.TypeName + "</option>");
        }
        return sb.ToString();
    }
}