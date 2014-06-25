using MyPhotos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyPhotos.DAL
{
    public class PhotoTypeDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PhotoType> GetAllPhotoTypes()
        {
            string sql = "select * from phototype";

            DataTable dt = SQLHelper.ExecuteTable(sql);

            return DTToList(dt);
        }

        private List<PhotoType> DTToList(DataTable dt)
        {
            List<PhotoType> list = new List<PhotoType>();

            foreach (DataRow dr in dt.Rows)
            {
                PhotoType pt = new PhotoType();
                pt.TCover = dr["TCover"].ToString();
                pt.TypeDes = dr["TypeDes"].ToString();
                pt.TypeId = Convert.ToInt32(dr["TypeId"]);
                pt.TypeName = dr["TypeName"].ToString();
                list.Add(pt);
            }


            return list;
        }
    }
}
