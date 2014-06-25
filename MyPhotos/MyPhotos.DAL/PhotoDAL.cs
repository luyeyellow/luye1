using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyPhotos.Model;
namespace MyPhotos.DAL
{
    public class PhotoDAL
    {
        /// <summary>
        /// 根据相册id，查询该相册下所有的图片
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public List<Photos> GetPhotosByTypeId(int tid)
        {
            string sql = "select * from photos where pTypeId="+tid+" order by ptime desc";
            DataTable dt = SQLHelper.ExecuteTable(sql);
            return DTToList(dt);
        }


        public List<Photos> GetPaged(int startIndex, int pageSize)
        {
            string sql = "select * from (select *,row_number() over(order by pid desc) as num from photos) as t where num > @startIndex and num<= @startIndex +@pageSize  order by pid desc";
            SqlParameter[] param = { 
                                        new SqlParameter("@startIndex",SqlDbType.Int){Value=startIndex},
                                        new SqlParameter("@pageSize",SqlDbType.Int){Value=pageSize},
                                   };

            DataTable dt = SQLHelper.ExecuteTable(sql, param);
            return DTToList(dt);
        }

        public int GetCount()
        {
            string sql = "select count(*) from photos";
            object o = SQLHelper.ExecuteScalar(sql);
            return Convert.ToInt32(o);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="pageCount">总页数，输出参数</param>
        /// <returns></returns>
        public List<Photos> GetPagedPhotos(int pageIndex,int pageSize,out int pageCount)
        { 
            SqlParameter[] param = {
                                        new SqlParameter("@pageIndex",SqlDbType.Int),
                                        new SqlParameter("@pageSize",SqlDbType.Int),
                                        new SqlParameter("@pageCount",SqlDbType.Int)
                                   };
            //输入参数
            param[0].Value = pageIndex;
            param[1].Value = pageSize;
            //输出参数
            param[2].Direction = ParameterDirection.Output;
            //执行存储过程
            DataTable dt =  SQLHelper.ExecuteTable("usp_GetPagedPhotos", CommandType.StoredProcedure,param);
            //获取输出参数的值
            pageCount = Convert.ToInt32(param[2].Value);
            return DTToList(dt);
        }

        /// <summary>
        /// 支持
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateUp(int id)
        {
            string sql = "update photos set pup=pup+1 where pid=" + id;
            return SQLHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 反对
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateDown(int id)
        {
            string sql = "update photos set pdown=pdown+1 where pid=" + id;
            return SQLHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 更新点击次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateClicks(int id)
        {
            string sql = "update photos set pclicks=pclicks+1 where pid=" + id;
            return SQLHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Update(Photos p)
        {
            string sql = "update photos set PTypeId=@PTypeId, PTitle=@PTitle, PUrl=@PUrl, PDes=@PDes  where pid=@pid";
            SqlParameter[] param = { 
                                        new SqlParameter("@PTypeId",SqlDbType.Int){Value=p.PTypeId},
                                        new SqlParameter("@PTitle",p.PTitle),
                                        new SqlParameter("@PUrl",p.PUrl),
                                        new SqlParameter("@PDes",p.PDes),
                                        new SqlParameter("@pid",SqlDbType.Int){Value=p.PId}
                                   };
            return SQLHelper.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Photos GetPhotoByPid(int id)
        {
            string sql = "select * from photos where pid="+id;
            DataTable dt = SQLHelper.ExecuteTable(sql);
            List<Photos> list = DTToList(dt);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Add(Photos p)
        {
            string sql = "insert into photos (PTypeId, PTitle, PUrl, PDes) values(@PTypeId, @PTitle, @PUrl, @PDes)";
            SqlParameter[] param = { 
                                        new SqlParameter("@PTypeId",SqlDbType.Int){Value=p.PTypeId},
                                        new SqlParameter("@PTitle",p.PTitle),
                                        new SqlParameter("@PUrl",p.PUrl),
                                        new SqlParameter("@PDes",p.PDes)
                                   };
            return SQLHelper.ExecuteNonQuery(sql, param);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from photos where pid="+id;
            return SQLHelper.ExecuteNonQuery(sql);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Photos> GetAllPhotos()
        {
            string sql = "select * from photos order by PTime desc";

            DataTable dt = SQLHelper.ExecuteTable(sql);

            return DTToList(dt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<Photos> DTToList(DataTable dt)
        {
            List<Photos> list = new List<Photos>();
            foreach (DataRow dr in dt.Rows)
            {
                Photos p = new Photos();
                p.PClicks = Convert.ToInt32( dr["PClicks"]);
                p.PDes = dr["PDes"].ToString();
                p.PDown = Convert.ToInt32(dr["PDown"]);
                p.PId = Convert.ToInt32(dr["PId"]);
                p.PTime = Convert.ToDateTime(dr["PTime"]);
                p.PTitle = dr["PTitle"].ToString();

                p.PTypeId = Convert.ToInt32(dr["PTypeId"]);
                p.PUp = Convert.ToInt32(dr["PUp"]);
                p.PUrl = dr["PUrl"].ToString();

                list.Add(p);

            }
            return list;
        }
    }
}
