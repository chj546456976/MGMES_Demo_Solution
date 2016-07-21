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
    public class Part_Bom_RelDAL
    {


        public static int AddRelByPartidAndBomid(int partid, int bomid, int count)
        {
            string sql = @"INSERT INTO [mg_part_bom_rel] ([part_id],[bom_id],[bom_count]) VALUES (" + partid + "," + bomid + "," + count+")";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetAllData()
        {
            string sql = @"select pb.*,p.part_name,b.bom_name from [mg_part_bom_rel] pb left join [mg_part] p on pb.part_id = p.part_id left join [mg_BOM] b on pb.bom_id=b.bom_id order by pb.part_id,pb.bom_id";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int UpdateRelByPartidAndBomid(int partid, int bomid,int obomid, int count)
        {
            string sql = @"update [mg_part_bom_rel] set bom_id = " + bomid + ",bom_count=" + count + " where part_id=" + partid + " and bom_id =" + obomid;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int DelRelByPartidAndBomid(int partid, int bomid)
        {
            string sql = @"delete from [mg_part_bom_rel] where part_id=" + partid + " and bom_id ="+bomid;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int CheckRelByPartidAndBomid(int a, int partid, int bomid)
        {
            string sql = "";
            DataTable tb;
            int i=1;

            sql = @"select * from [mg_part_bom_rel] where part_id =" + partid + " and bom_id =" + bomid;
            tb = SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);

            if (a == 1 )
            {
                if (tb.Rows.Count == 0)
                {
                    i = 0;
                }
                else
                {
                    i = 1;
                }
                
            }

            if (a == 2)
            {
                if(tb.Rows.Count <= 1)
                {
                    i = 0;
                }
                else
                {
                    i = 1;
                }
                
            }

            tb.Dispose();
            return i;
        }

        public static DataTable GetBomName(string partid, string bomid)
        {
            //string sql = @"select bom_id,bom_name from [mg_BOM] order by [bom_id]";
            string sql = @"select b.bom_id,b.bom_name from mg_BOM b except select bb.bom_id,bb.bom_name from mg_part_bom_rel pb join mg_BOM bb on pb.bom_id = bb.bom_id where pb.part_id = '"+partid+"' and pb.bom_id <> '"+bomid+"' order by 1";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }
        public static DataTable GetBomName()
        {
            string sql = @"select bom_id,bom_name from [mg_BOM] order by [bom_id]";
            
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetPartName()
        {
            string sql = @"select part_id,part_name from [mg_part] order by [part_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }
    }
}

