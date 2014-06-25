using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControl
{
    public partial class _09_作业1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlPhotoTypes.AppendDataBoundItems = true;

                ListItem li = new ListItem();
                li.Text = "请选择";
                li.Value = "-1";

                ddlPhotoTypes.Items.Add(li);


                BindRpt(-1);
            }
        }

        void BindRpt(int tid)
        {
            MyPhotos.BLL.PhotoBLL bll = new MyPhotos.BLL.PhotoBLL();
            rptPhotos.DataSource = bll.GetPhotosByTypeId(tid);
            rptPhotos.DataBind();
        }

        protected void ddlPhotoTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tid = int.Parse(ddlPhotoTypes.SelectedValue);

            BindRpt(tid);

           

        }
    }
}