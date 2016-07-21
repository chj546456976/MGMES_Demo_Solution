using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class mg_FlowLineBLL
    {
        public static bool AddPositionByName(string posiname)
        {
            return mg_FlowLineDAL.AddflByName(posiname) > 0 ? true : false;
        }

        public static DataTable GetAllData()
        {
            return mg_FlowLineDAL.GetAllData();
        }

        public static bool UpdatePositionByName(int posi_id, string posi_name)
        {
            return mg_FlowLineDAL.UpDateflByName(posi_id, posi_name) > 0 ? true : false;
        }

        public static bool DelPositionByName(int posi_id)
        {
            return mg_FlowLineDAL.DelflByName(posi_id) > 0 ? true : false;
        }

        public static bool CheckPositionByName(int a, int posi_id, string posi_name)
        {
            return mg_FlowLineDAL.CheckflByName(a, posi_id, posi_name) == 0 ? true : false;
        }
    }
}
