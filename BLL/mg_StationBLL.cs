using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class mg_StationBLL
    {
        public static DataTable GetStationID()
        {
            return mg_StationDAL.GetStationID();
        }
    }
}
