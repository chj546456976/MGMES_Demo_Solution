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
    public class mg_FlowLineDAL
    {
        public static int AddflByName(string fl_name)
        {
            string maxidSql = @"declare @i int;
                                SELECT @i=max([fl_id])  FROM [mg_FlowLine];
                                if @i is null
                                    begin
                                        set @i=1
                                    end
                                else
                                    begin
                                        set @i=@i+1
                                    end;";
            string sql = maxidSql + @"INSERT INTO [mg_FlowLine] ([fl_id],[fl_name]) VALUES (@i,'" + fl_name + @"')";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetAllData()
        {
            string sql = @"select * from [mg_FlowLine] order by [fl_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int UpDateflByName(int fl_id, string fl_name)
        {
            string sql = @"update [mg_FlowLine] set fl_name='" + fl_name + "' where fl_id=" + fl_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int DelflByName(int fl_id)
        {
            string sql = @"delete from [mg_FlowLine] where fl_id=" + fl_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int CheckflByName(int a, int fl_id, string fl_name)
        {
            string sql = "";
            DataTable tb;
            int i;
            if (a == 1)
            {
                sql = @"select * from [mg_FlowLine] where fl_name='" + fl_name + "'";
            }
            if (a == 2)
            {
                sql = @"select * from [mg_FlowLine] where fl_name='" + fl_name + "' and fl_id <>" + fl_id;
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
    }
}
