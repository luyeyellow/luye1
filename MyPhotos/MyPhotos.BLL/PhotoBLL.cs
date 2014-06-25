using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPhotos.Model;
using MyPhotos.DAL;
namespace MyPhotos.BLL
{
    public class PhotoBLL
    {
        PhotoDAL dal = new PhotoDAL();
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="p"></param>
        /// <param name="action">add 添加  update修改</param>
        /// <returns></returns>
        public bool Save(Photos p, string action)
        {
            bool r = false;
            if (action == "add")
            {
                r = Add(p);
            }
            else if (action == "update")
            {
                r = Update(p);
            }
            return r;
        }

        /// <summary>
        /// 根据相册id，查询该相册下所有的图片
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public List<Photos> GetPhotosByTypeId(int tid)
        {
            if (tid == -1)
            {
                return GetAllPhotos();
            }
            else
            {
                return dal.GetPhotosByTypeId(tid);
            }
        }

        public List<Photos> GetPaged(int startIndex, int pageSize)
        {
            return dal.GetPaged(startIndex, pageSize);
        }

        public int GetCount()
        {
            return dal.GetCount();
        }
        /// <summary>
        /// 支持1或反对2
        /// </summary>
        /// <returns></returns>
        public bool Update(int id, int flag)
        {
            bool r = false;
            if (flag == 1)
            {
                r = dal.UpdateUp(id) > 0;
            }
            else if (flag == 2)
            {
                r = dal.UpdateDown(id) > 0;
            }
            return r;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="pageCount">总页数，输出参数</param>
        /// <returns></returns>
        public List<Photos> GetPagedPhotos(int pageIndex, int pageSize, out int pageCount)
        {
            return dal.GetPagedPhotos(pageIndex, pageSize, out pageCount);
        }
        /// <summary>
        /// 更新点击次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateClicks(int id)
        {
            return dal.UpdateClicks(id) > 0;
        }
        public bool Update(Photos p)
        {
            return dal.Update(p) > 0;
        }


        public Photos GetPhotoByPid(int id)
        {
            return dal.GetPhotoByPid(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Add(Photos p)
        {
            return dal.Add(p) > 0;
        }

        public bool Delete(int id)
        {
            //判断 该图片下是否有评论
            return dal.Delete(id) > 0;
        }


        public bool Delete(Photos p)
        {
            //判断 该图片下是否有评论
            return Delete(p.PId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Photos> GetAllPhotos()
        {
            return dal.GetAllPhotos();
        }
    }
}
