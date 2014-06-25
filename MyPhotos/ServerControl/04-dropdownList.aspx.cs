using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPhotos.BLL;
namespace ServerControl
{
    public partial class _04_dropdownList : System.Web.UI.Page
    {
        // LoadAllState()  还原了控件的状态

        protected void Page_Load(object sender, EventArgs e)
        {
            //首次加载
            if (!IsPostBack)
            {
                //追加数据绑定项
                DropDownList1.AppendDataBoundItems = true;

                //请选择
                ListItem li = new ListItem();
                li.Text = "请选择";
                li.Value = "-1";
                DropDownList1.Items.Add(li);

                //1 告诉它显示什么
                DropDownList1.DataTextField = "typeName";
                DropDownList1.DataValueField = "typeid";
                //2 给数据   数据绑定之前，会先清空下拉框
                PhotoTypeBLL bll = new PhotoTypeBLL();
                DropDownList1.DataSource = bll.GetAllPhotoTypes();
                DropDownList1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write(DropDownList1.SelectedItem.Text + "<br>");

            Response.Write(DropDownList1.SelectedValue);
        }
    }
}