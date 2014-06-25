using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPhotos.DAL;
using MyPhotos.Model;
namespace MyPhotos.BLL
{
    public class UserBLL
    {
        UserDAL dal = new UserDAL();
        /// <summary>
        /// 判断用户名是否可用  true 可用  false 不可用
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckName(string name)
        {
            User u =   dal.GetUserByName(name);
            if (u != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="msg">1 成功 2用户名不正确  3 密码错误</param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Login(string name, string pwd, out int msg, out User user)
        {
            bool result = false;
            user = dal.GetUserByName(name);
            if (user != null)
            {
                //1 成功 2用户名不正确  3 密码错误
                if (user.UPwd == pwd)
                {
                    msg = 1;
                    result = true;
                }
                else
                {
                    msg = 3;
                }
            }
            else
            {
                msg = 2;
            }
            return result;
        }


        public bool Login(string name, string pwd, out string msg, out User user)
        {
            bool result = false;
            user = dal.GetUserByName(name);
            if (user != null)
            {
                if (user.UPwd == pwd)
                {
                    msg = "登陆成功";
                    result = true;
                }
                else
                {
                    msg = "密码错误";
                }
            }
            else
            {
                msg = "用户名不存在";
            }
            return result;
        }
    }
}
