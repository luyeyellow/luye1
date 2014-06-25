using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControl
{
    public partial class _03_ddl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //追加数据绑定项
                DropDownList1.AppendDataBoundItems = true;

                //请选择
                ListItem li = new ListItem();
                li.Text = "请选择";
                li.Value = "-1";
                DropDownList1.Items.Add(li);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write(DropDownList1.SelectedItem.Text + "<br>");

            Response.Write(DropDownList1.SelectedValue);
        }
    }
}