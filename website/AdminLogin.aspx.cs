﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;
using Model;
using Tools;

public partial class AdminCMS_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    /// <summary>
    /// 登陆
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        #region
        if (this.name.Text.Trim() == "")
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "名称", "<script language='javascript'> alert('用户名不能为空！');</script>");
            this.name.Focus();
            return;
        }

        if (this.pwd.Text.Trim() == "")
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "名称", "<script language='javascript'> alert('密码不能为空！');</script>");
            this.pwd.Focus();
            return;
        }

        if (FormatHelper.CheckPunctuation(this.name.Text.Trim())==false)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "名称", "<script language='javascript'> alert('用户名不能包含单引号！');</script>");
            this.name.Focus();
            return;
        }

        if (FormatHelper.CheckPunctuation(this.pwd.Text.Trim()) == false)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "名称", "<script language='javascript'> alert('密码不能包含单引号！');</script>");
            this.pwd.Focus();
            return;
        }

        #endregion

        //验证用户名、密码规则
        string uid = this.name.Text.Trim();
        string pwd = this.pwd.Text.Trim();
        mg_userModel usermodel= mg_UserBLL.GetUserForUName(uid);
        if (uid == usermodel.user_name && pwd == usermodel.user_pwd)
        {
            HttpCookie cookie = new HttpCookie("admininfo");
            cookie.Values["name"] = uid;
            cookie.Values["id"] = "0";
            cookie.Values["tel"] = "666666";
            cookie.Values["tel1"] = "666666";
            cookie.Values["webChatName"] = "666666";
            cookie.Values["password"] = "666666";
            cookie.Values["isFreezed"] = "0";
            //cookie.Value[""]

            Response.Cookies.Add(cookie);


            FormsAuthentication.RedirectFromLoginPage(uid, false);
        }
        else if (uid == usermodel.user_name && pwd != usermodel.user_pwd)
        {
            string message = "帐号或密码错误，登录失败！";
            Response.Write("<script>alert('" + message + "');location.href='/AdminIndex.aspx';</script>");
            Response.End();
        }
        else if (uid != usermodel.user_name && pwd == usermodel.user_pwd)
        {
            string message = "帐号或密码错误，登录失败！";
            Response.Write("<script>alert('" + message + "');location.href='/AdminIndex.aspx';</script>");
            Response.End();
        }
    }
}