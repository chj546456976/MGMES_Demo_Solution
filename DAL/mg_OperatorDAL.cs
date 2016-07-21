using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tools;
using DBUtility;
using Model;

namespace DAL
{
    public class mg_OperatorDAL
    {


        public static int AddOperatorByName(string name, string rfid, int stid, int isoperator, string pic)
        {
            string sql = @"INSERT INTO [mg_Operator] ([op_name],[op_no],[st_id],[op_isoperator],[op_pic]) VALUES ('" + name + "','" + rfid + "'," + stid + "," + isoperator + ",'" + pic + "')";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetAllData()
        {
            string sql = @"select o.*,s.st_name,case o.op_isoperator when 1 then 'True' else 'False' end isoperator from [mg_Operator] o left join [mg_station] s on o.st_id = s.st_id order by op_id";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int UpdateOperatorByName(int id, string name, string rfid, int stid, int isoperator, string pic)
        {
            string sql = @"update [mg_Operator] set op_name = '" + name + "',op_no='" + rfid + "',op_pic='" + pic + "',op_isoperator=" + isoperator + ",st_id=" + stid + " where op_id='" + id + "'";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int DelOperatorByName(int user_id)
        {
            string sql = @"delete from [mg_Operator] where op_id=" + user_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int CheckOperatorByName(int a, int userid, string name)
        {
            string sql = "";
            DataTable tb;
            int i;
            if (a == 1)
            {
                sql = @"select * from [mg_Operator] where op_name='" + name + "'";
            }
            if (a == 2)
            {
                sql = @"select * from [mg_Operator] where op_name='" + name + "' and op_id <>" + userid;
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

        public static DataTable GetStName()
        {
            string sql = @"select st_id,st_name from [mg_station] order by [st_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static bool CheckPicName(string name)
        {
            string sql = @"select count(*) from [mg_Operator] where op_pic='" + name + "'";
            DataTable tb;

            tb = SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
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

