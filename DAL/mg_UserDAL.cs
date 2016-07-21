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
    public class mg_UserDAL
    {

            public static Model.mg_userModel GetUserForUID(string uid)
            {

                string sql = @" select * from mg_User where user_id='" + uid + "' ";
                DataTable dt = SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, System.Data.CommandType.Text, sql, null);
                if (DataHelper.HasData(dt))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        mg_userModel model = new mg_userModel();
                        model.user_id = NumericParse.StringToInt(DataHelper.GetCellDataToStr(row, "user_id"));
                        model.user_pwd = DataHelper.GetCellDataToStr(row, "user_pwd");
                        model.user_name = DataHelper.GetCellDataToStr(row, "user_name");
                        model.user_no = DataHelper.GetCellDataToStr(row, "user_no");
                        model.user_pic = DataHelper.GetCellDataToStr(row, "user_pic");
                        model.user_email = DataHelper.GetCellDataToStr(row, "user_email");
                        model.user_depid = Convert.ToInt32(DataHelper.GetCellDataToStr(row, "user_depid"));
                        model.user_posiid = Convert.ToInt32(DataHelper.GetCellDataToStr(row, "user_posiid"));
                        model.user_menuids = DataHelper.GetCellDataToStr(row, "user_menuids");
                        return model;
                    }
                }
                return null;
            }

            /// <summary>
            /// 读取用户信息
            /// </summary>
            /// <param name="uid"></param>
            /// <returns></returns>
            public static Model.mg_userModel GetUserForUName(string uname)
            {
                string sql = @" select * from mg_User where user_name='" + uname + "' ";
                DataTable dt = SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, System.Data.CommandType.Text, sql, null);
                if (DataHelper.HasData(dt))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        mg_userModel model = new mg_userModel();
                        model.user_id = NumericParse.StringToInt(DataHelper.GetCellDataToStr(row, "user_id"));
                        model.user_pwd = DataHelper.GetCellDataToStr(row, "user_pwd");
                        model.user_name = uname;
                        model.user_no = DataHelper.GetCellDataToStr(row, "user_no");
                        model.user_pic = DataHelper.GetCellDataToStr(row, "user_pic");
                        model.user_email = DataHelper.GetCellDataToStr(row, "user_email");
                        model.user_depid = NumericParse.StringToInt(DataHelper.GetCellDataToStr(row, "user_depid"));
                        model.user_posiid = NumericParse.StringToInt(DataHelper.GetCellDataToStr(row, "user_posiid"));
                        model.user_menuids = DataHelper.GetCellDataToStr(row, "user_menuids");
                        return model;
                    }
                }
                return null;
            }
        public static int AddUserByName(string name, string pwd, string rfid, string email, int depid, int posiid, string pic, string menuids)
        {
            string sql = @"INSERT INTO [mg_User] ([user_name],[user_pwd],[user_no],[user_pic],[user_email],[user_depid],[user_posiid],[user_menuids]) VALUES ('" + name + "','" + pwd + "','" + rfid + "','" + pic + "','" + email + "'," + depid + "," + posiid + ",'" + menuids + "')";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetAllData()
        {
            string sql = @"select u.*,d.dep_name,p.posi_name from [mg_User] u left join mg_Department d on u.user_depid=d.dep_id left join mg_Position p on u.user_posiid=p.posi_id order by [user_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int UpdateUserByName(int id, string name, string pwd, string rfid, string email, string menuids, int depid, int posiid, string pic)
        {
            string sql = @"update [mg_user] set user_name = '" + name + "',user_pwd='" + pwd + "',user_no='" + rfid + "',user_pic='" + pic + "',user_email='" + email + "',user_depid=" + depid + ",user_posiid=" + posiid + ",user_menuids='" + menuids + "' where user_id='" + id + "'";
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int DelUserByName(int user_id)
        {
            string sql = @"delete from [mg_user] where user_id=" + user_id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static int CheckUserByName(int a, int userid, string name)
        {
            string sql = "";
            DataTable tb;
            int i;
            if (a == 1)
            {
                sql = @"select * from [mg_User] where user_name='" + name + "'";
            }
            if (a == 2)
            {
                sql = @"select * from [mg_User] where user_name='" + name + "' and user_id <>" + userid;
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

        public static DataTable GetPosiName()
        {
            string sql = @"select posi_id,posi_name from [mg_Position] order by [posi_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetDepName()
        {
            string sql = @"select dep_id,dep_name from [mg_Department] order by [dep_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static DataTable GetUserName()
        {
            string sql = @"select bom_id,bom_name from [mg_bom] order by [bom_id]";
            return SqlHelper.GetDataDataTable(SqlHelper.SqlConnString, CommandType.Text, sql, null);
        }

        public static bool CheckPicName(string name)
        {
            string sql = @"select count(*) from [mg_user] where user_pic='" + name + "'";
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

