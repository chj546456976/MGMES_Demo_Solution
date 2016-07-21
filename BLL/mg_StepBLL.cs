using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class mg_StepBLL
    {
        public static bool AddStepByName(string name,int clock, string desc, string pic,int stid,int bomid,int bomcount)
        {
            return mg_StepDAL.AddStepByName(name, clock, desc, pic, stid, bomid, bomcount) > 0 ? true : false;
        }

        public static DataTable GetAllData()
        {
            return mg_StepDAL.GetAllData();
        }

        public static bool UpdateStepByName(int id,string name, int clock, string desc, string pic,int stid, int bomid, int count)
        {
            return mg_StepDAL.UpdateStepByName(id, name, clock, desc, pic,stid,bomid,count) > 0 ? true : false;
        }

        public static bool DelStepByName(int step_id)
        {
            return mg_StepDAL.DelStepByName(step_id) > 0 ? true : false;
        }

        public static bool CheckStepByName(int a, int stepid, string name)
        {
            return mg_StepDAL.CheckStepByName(a, stepid, name) == 0 ? true : false;
        }

        public static DataTable GetStationID()
        {
            return mg_StepDAL.GetStationID();
        }

        public static DataTable GetBomName()
        {
            return mg_StepDAL.GetBomName();
        }

        public static bool CheckPicName(string name)
        {
            return mg_StepDAL.CheckPicName(name);
        }
    }
}
