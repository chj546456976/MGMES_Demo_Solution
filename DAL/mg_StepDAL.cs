using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tools;
using DBUtility;

namespace DAL
{
    public class mg_StepDAL
    {
        public static int AddStepByName(string name, int clock, string desc, string pic,int stid,int bomid,int bomcount)
        {
            string sql = @"INSERT INTO [mg_step] ([step_name],[step_clock],[step_desc],[step_pic],[st_id],[bom_id],[bom_count]) VALUES ('" + name + "'," + clock + ",'" + desc + "','" + pic + "'," + stid + "," + bomid +","+bomcount+ ")";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetAllData()
        {
            string sql = @"select s1.*,s2.st_name,b.bom_name from [mg_step] s1 left join [mg_station] s2 on s1.st_id = s2.st_id left join [mg_BOM] b on s1.bom_id = b.bom_id order by [step_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int UpdateStepByName(int step_id, string step_name, int step_clock,string step_desc, string step_pic,int stid,int bomid,int count)
        {
            string sql = @"update [mg_step] set step_name='" + step_name + "',step_clock=" + step_clock + ",step_desc='" + step_desc + "',Step_pic='" + step_pic + "',st_id=" + stid + ",bom_id=" + bomid + ",bom_count="+count+" where step_id=" + step_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int DelStepByName(int step_id)
        {
            string sql = @"delete from [mg_step] where step_id=" + step_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int CheckStepByName(int a, int stepid, string name)
        {
            string sql = "";
            DataTable tb;
            int i;
            if (a == 1)
            {
                sql = @"select * from [mg_step] where step_name='" + name + "'";
            }
            if (a == 2)
            {
                sql = @"select * from [mg_step] where step_name='" + name + "' and step_id <>" + stepid;
            }
            tb = SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
            if (tb.Rows.Count != 0)
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
            tb.Dispose();
            return i;
        }

        public static DataTable GetStationID()
        {
            string sql = @"select st_id,st_name from [mg_station] order by [st_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetBomName()
        {
            string sql = @"select bom_id,bom_name from [mg_bom] order by [bom_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static bool CheckPicName(string name)
        {
            string sql = @"select count(*) from [mg_step] where Step_pic='" + name + "'";
            DataTable tb;

            tb = SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
            string zz= tb.Rows[0][0].ToString();
            if (tb.Rows[0][0].ToString()=="0")
            {
                tb.Dispose();
                return false;
            }
            else
            {
                tb.Dispose();
                return true;
            }
        }
    }
}
