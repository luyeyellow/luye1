using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControl
{
    public partial class _02_dropdownlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //清空
            DropDownList1.Items.Clear();


            ListItem li = new ListItem();
            li.Text = "幼儿园";
            li.Value = "1";
            DropDownList1.Items.Add(li);

            li = new ListItem();
            li.Text = "小学";
            li.Value = "2";
            DropDownList1.Items.Add(li);

            li = new ListItem();
            li.Text = "中学";
            li.Value = "3";
            li.Selected = true;
            DropDownList1.Items.Add(li);

        }
    }
}