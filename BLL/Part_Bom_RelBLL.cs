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
    public class Part_Bom_RelBLL
    {
        public static bool AddRelByPartidAndBomid(int partid, int bomid, int count)
        {
            return Part_Bom_RelDAL.AddRelByPartidAndBomid(partid, bomid, count) > 0 ? true : false;
        }

        public static DataTable GetAllData()
        {
            return Part_Bom_RelDAL.GetAllData();
        }

        public static bool UpdateRelByPartidAndBomid(int partid, int bomid, int obomid, int count)
        {
            return Part_Bom_RelDAL.UpdateRelByPartidAndBomid(partid, bomid,obomid, count) > 0 ? true : false;
        }

        public static bool DelRelByPartidAndBomid(int partid,int bomid)
        {
            return Part_Bom_RelDAL.DelRelByPartidAndBomid(partid, bomid) > 0 ? true : false;
        }

        public static bool CheckRelByPartidAndBomid(int a, int partid, int bomid)
        {
            return Part_Bom_RelDAL.CheckRelByPartidAndBomid(a, partid, bomid) == 0 ? true : false;
        }

        public static DataTable GetBomName(string partid, string bomid)
        {
            return Part_Bom_RelDAL.GetBomName(partid,bomid);
        }

        public static DataTable GetBomName()
        {
            return Part_Bom_RelDAL.GetBomName();
        }
        public static DataTable GetPartName()
        {
            return Part_Bom_RelDAL.GetPartName();
        }

    }
}
