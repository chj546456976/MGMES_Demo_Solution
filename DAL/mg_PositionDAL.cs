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
    public class mg_PositionDAL
    {
        public static int AddPositionByName(string posi_name)
        {
            string maxidSql = @"declare @i int;
                                SELECT @i=max([posi_id])  FROM [mg_Position];
                                if @i is null
                                    begin
                                        set @i=1
                                    end
                                else
                                    begin
                                        set @i=@i+1
                                    end;";
            string sql = maxidSql + @"INSERT INTO [mg_Position] ([posi_id],[posi_name]) VALUES (@i,'" + posi_name + @"')";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetAllData()
        {
            string sql = @"select * from [mg_Position] order by posi_id";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int UpDatePositionByName(int posi_id, string posi_name)
        {
            string sql = @"update [mg_Position] set posi_name='" + posi_name + "' where posi_id=" + posi_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int DelPositionByName(int posi_id)
        {
            string sql = @"delete from [mg_Position] where posi_id=" + posi_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int CheckPositionByName(int a,int posi_id, string posi_name)
        {
            string sql="";
            DataTable tb;
            int i;
            if (a == 1)
            {
                sql = @"select * from [mg_Position] where posi_name='" + posi_name + "'";
            }
            if (a == 2)
            {
                sql = @"select * from [mg_Position] where posi_name='" + posi_name + "' and posi_id <>" + posi_id;
            }
            tb = SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
            if (tb.Rows.Count != 0)
            {
                i= 1;
            }
            else
            {
                i= 0;
            }
            tb.Dispose();
            return i;
        }
    }
}
