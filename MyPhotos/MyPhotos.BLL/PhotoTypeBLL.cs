using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPhotos.DAL;
using MyPhotos.Model;
namespace MyPhotos.BLL
{
    public class PhotoTypeBLL
    {
        PhotoTypeDAL dal = new PhotoTypeDAL();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PhotoType> GetAllPhotoTypes()
        {
            return dal.GetAllPhotoTypes();
        }
    }
}
