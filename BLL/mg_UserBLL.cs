using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace BLL
{
    public class mg_UserBLL
    {
        public static mg_userModel GetUserForUID(string uid)
        {
            return mg_UserDAL.GetUserForUID(uid);
        }

        public static mg_userModel GetUserForUName(string uname)
        {
            return mg_UserDAL.GetUserForUName(uname);
        }

        public static bool AddUserByName(string name, string pwd, string rfid, string email, int depid, int posiid, string pic, string menuids)
        {
            return mg_UserDAL.AddUserByName(name, pwd, rfid, email, depid, posiid, pic, menuids) > 0 ? true : false;
        }

        public static DataTable GetAllData()
        {
            return mg_UserDAL.GetAllData();
        }

        public static bool UpdateUserByName(int id, string name, string pwd, string rfid, string email, string menuids, int depid, int posiid, string pic)
        {
            return mg_UserDAL.UpdateUserByName(id, name, pwd, rfid, email, menuids, depid, posiid, pic) > 0 ? true : false;
        }

        public static bool DelUserByName(int user_id)
        {
            return mg_UserDAL.DelUserByName(user_id) > 0 ? true : false;
        }

        public static bool CheckUserByName(int a, int userid, string name)
        {
            return mg_UserDAL.CheckUserByName(a, userid, name) == 0 ? true : false;
        }

        public static DataTable GetDepName()
        {
            return mg_UserDAL.GetDepName();
        }

        public static DataTable GetPosiName()
        {
            return mg_UserDAL.GetPosiName();
        }

        public static DataTable GetUserName()
        {
            return mg_UserDAL.GetUserName();
        }

        public static bool CheckPicName(string name)
        {
            return mg_UserDAL.CheckPicName(name);
        }
    }
}
