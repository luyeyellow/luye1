using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace MyPhotos.DAL
{
    class SQLHelper
    {
        /// <summary>
        /// 读取配置文件中的连接字符串
        /// </summary>
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["jian"].ConnectionString;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string sql,CommandType ct, params SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, conn))
                {
                    sda.SelectCommand.Parameters.AddRange(param);
                    //设置 执行存储过程或sql语句
                    sda.SelectCommand.CommandType = ct;

                    try
                    {
                        sda.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return dt;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string sql, params SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, conn))
                {
                    sda.SelectCommand.Parameters.AddRange(param);


                    try
                    {
                        sda.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    
                    return dt;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(param);

                    conn.Open();

                   return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(param);


                    conn.Open();

                    return cmd.ExecuteScalar();
                }
            }
        }


    }
}
