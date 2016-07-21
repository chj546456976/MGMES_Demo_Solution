using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using DBUtility;
using Tools;

namespace DAL
{
    public class mg_DepartmentDAL
    {
        public static int AddDepartmentByName(string depname)
        {
            string maxidSql = @"declare @i int;
                                SELECT @i=max([dep_id])  FROM [mg_Department];
                                if @i is null
                                    begin
                                        set @i=1
                                    end
                                else
                                    begin
                                        set @i=@i+1
                                    end;";
            string sql = maxidSql + @"INSERT INTO [mg_Department] ([dep_id],[dep_name]) VALUES (@i,'" + depname + @"')";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetAllData()
        {
            string sql = @"select * from [mg_Department] order by dep_id";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int UpDateDepartmentByName(int dep_id,string dep_name)
        {
            string sql = @"update [mg_Department] set dep_name='" + dep_name + "' where dep_id="+dep_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int DelDepartmentByName(int dep_id)
        {
            string sql = @"delete from [mg_Department] where dep_id=" + dep_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static  int CheckDepartmentByName(int a, int dep_id, string dep_name)
        {
            string sql="";
            DataTable tb ;
            
            if (a == 1)
            {
                sql = @"select * from [mg_Department] where dep_name='" + dep_name + "'";
            }
            else if (a==2)
            {
                sql = @"select * from [mg_Department] where dep_name='" + dep_name + "' and dep_id <>" + dep_id;
            }
            tb = SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
            if (tb.Rows.Count != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

