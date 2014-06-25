using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyPhotos.Model;
namespace MyPhotos.DAL
{
    public class UserDAL
    {
        public User GetUserByName(string name)
        {
            string sql = "select * from [user] where uName=@name";
            SqlParameter sp = new SqlParameter("@name",name);
            DataTable dt = SQLHelper.ExecuteTable(sql,sp);
            List<User> list = DTToList(dt);

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        private List<User> DTToList(DataTable dt)
        {
            List<User> list = new List<User>();
            foreach (DataRow dr in dt.Rows)
            {
                User u = new User();
                u.UId = Convert.ToInt32(dr["UId"]);
                u.UName = dr["UName"].ToString();
                u.UPwd = dr["UPwd"].ToString();
                list.Add(u);
            }
            return list;
        }
    }
}
