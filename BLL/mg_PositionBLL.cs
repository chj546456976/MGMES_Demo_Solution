using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class mg_PositionBLL
    {
        public static bool AddPositionByName(string flname)
        {
            return mg_FlowLineDAL.AddflByName(flname) > 0 ? true : false;
        }

        public static DataTable GetAllData()
        {
            return mg_FlowLineDAL.GetAllData();
        }

        public static bool UpdatePositionByName(int flid, string flname)
        {
            return mg_FlowLineDAL.UpDateflByName(flid, flname) > 0 ? true : false;
        }

        public static bool DelPositionByName(int flid)
        {
            return mg_FlowLineDAL.DelflByName(flid) > 0 ? true : false;
        }

        public static bool CheckPositionByName(int a, int flid, string flname)
        {
            return mg_FlowLineDAL.CheckflByName(a, flid, flname) == 0 ? true : false;
        }
    }
}
