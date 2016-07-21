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
    public class mg_BomDAL
    {
        public static int AddBomByName(string name, string no, int level, string desc, string pic, string material, string profile, int weight, string supplier, string category, string comments)
        {
            string sql = @"INSERT INTO [mg_BOM] ([bom_name],[bom_no],[bom_leve],[bom_desc],[bom_picture],[bom_material],[bom_profile],[bom_weight],[bom_suppller],[bom_category],[bom_comments]) VALUES ('" + name + "','" + no + "'," + level + ",'" + desc + "','" + pic + "','" + material + "','" + profile + "'," + weight + ",'" + supplier + "','" + category +"','" + comments + "')";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetAllData()
        {
            string sql = @"select * from [mg_BOM] order by [bom_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int UpdateBomByName(int id, string name, string no, int level, string desc, string material, string profile, int weight, string supplier, string category, string comments,string pic)
        {
            string sql = @"update [mg_Bom] set bom_name = '"+name+"',bom_no='"+no+"',bom_leve="+level+",bom_desc='"+desc+"',bom_picture='"+pic+"',bom_material='"+material+"',bom_profile='"+profile+"',bom_weight="+weight+",bom_suppller='"+supplier+"',bom_category='"+category+"',bom_comments='"+comments+"' where bom_id='"+id+"'";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int DelBomByName(int bom_id)
        {
            string sql = @"delete from [mg_bom] where bom_id=" + bom_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int CheckBomByName(int a, int bomid, string name)
        {
            string sql = "";
            DataTable tb;
            int i;
            if (a == 1)
            {
                sql = @"select * from [mg_bom] where bom_name='" + name + "'";
            }
            if (a == 2)
            {
                sql = @"select * from [mg_bom] where bom_name='" + name + "' and bom_id <>" + bomid;
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
            string sql = @"select count(*) from [mg_bom] where bom_picture='" + name + "'";
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
