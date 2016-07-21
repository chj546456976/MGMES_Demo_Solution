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
    public class mg_OperatorBLL
    {
        public static bool AddOperatorByName(string name, string rfid, int stid, int isoperator, string pic)
        {
            return mg_OperatorDAL.AddOperatorByName(name, rfid, stid, isoperator, pic) > 0 ? true : false;
        }

        public static DataTable GetAllData()
        {
            return mg_OperatorDAL.GetAllData();
        }

        public static bool UpdateOperatorByName(int id, string name, string rfid, int stid, int isoperator, string pic)
        {
            return mg_OperatorDAL.UpdateOperatorByName(id, name, rfid, stid, isoperator, pic) > 0 ? true : false;
        }

        public static bool DelOperatorByName(int user_id)
        {
            return mg_OperatorDAL.DelOperatorByName(user_id) > 0 ? true : false;
        }

        public static bool CheckOperatorByName(int a, int userid, string name)
        {
            return mg_OperatorDAL.CheckOperatorByName(a, userid, name) == 0 ? true : false;
        }

        public static DataTable GetStName()
        {
            return mg_OperatorDAL.GetStName();
        }

        public static bool CheckPicName(string name)
        {
            return mg_OperatorDAL.CheckPicName(name);
        }
    }
}
