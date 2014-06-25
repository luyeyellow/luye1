using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPhotos.BLL;
namespace ServerControl
{
    public partial class _06_Repeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //首次加载
            if (!IsPostBack)
            {
                BindRpt();
            }
        }

        private void BindRpt()
        {
            PhotoBLL bll = new PhotoBLL();
            Repeater1.DataSource = bll.GetAllPhotos();
            Repeater1.DataBind();
        }

        protected string GetTitle(object o)
        {
            string s = o.ToString();
            if (s.Length > 5)
            {
                s = s.Substring(0, 5) + "...";
            }
            return s;
        }


        //当项绑定完成后触发
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判断当前绑定完成的项是不是数据项
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //找到当前项中的label
                Label lbl = e.Item.FindControl("lblClicks") as Label;
                if (lbl != null)
                {
                    //判断点击次数
                    int count = int.Parse(lbl.Text);
                    if (count > 2)
                    {
                        lbl.ForeColor = System.Drawing.Color.Red;
                    }
                }
                
            }
        }

        //点击repeater中的按钮的时候会触发该事件
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string name = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);

            PhotoBLL bll = new PhotoBLL();

            switch (name)
            {
                case "delete":
                    bll.Delete(id);
                    break;
                case "up":
                    bll.Update(id, 1);
                    break;
                case "down":
                    bll.Update(id, 2);
                    break;
            }
            //重新绑定
            BindRpt();

            //如果是objectdatasource  
            //Repeater1.DataBind();
            
        }
    }
}