using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class mg_BomBLL
    {
        public static bool AddBomByName(string name, string no, int level, string desc, string pic, string material, string profile, int weight, string supplier, string category, string comments)
        {
            return mg_BomDAL.AddBomByName(name, no, level, desc, pic, material, profile, weight, supplier, category, comments) > 0 ? true : false;
        }

        public static DataTable GetAllData()
        {
            return mg_BomDAL.GetAllData();
        }

        public static bool UpdateBomByName(int id, string name, string no, int level, string desc, string material, string profile, int weight, string supplier, string category, string comments,string pic)
        {
            return mg_BomDAL.UpdateBomByName(id, name, no, level, desc, material, profile, weight, supplier, category, comments,pic) > 0 ? true : false;
        }

        public static bool DelBomByName(int bom_id)
        {
            return mg_BomDAL.DelBomByName(bom_id) > 0 ? true : false;
        }

        public static bool CheckBomByName(int a, int bomid, string name)
        {
            return mg_BomDAL.CheckBomByName(a, bomid, name) == 0 ? true : false;
        }

        public static DataTable GetStationID()
        {
            return mg_BomDAL.GetStationID();
        }

        public static DataTable GetBomName()
        {
            return mg_BomDAL.GetBomName();
        }

        public static bool CheckPicName(string name)
        {
            return mg_BomDAL.CheckPicName(name);
        }
    }
}
