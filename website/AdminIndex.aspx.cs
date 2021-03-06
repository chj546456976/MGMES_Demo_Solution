﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminCMS_AdminIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Literal1.Text = "服务器地址: " + Request.ServerVariables.Get("Remote_Host").ToString() + "<br/><br/>"
            + "浏览器: " + Request.Browser.Browser + "<br/><br/>"
            + "浏览器版本号: " + Request.Browser.MajorVersion + "<br/><br/>"
            + "客户端平台: " + Request.Browser.Platform + "<br/><br/>"
            + "服务器ip: " + Request.ServerVariables.Get("Local_Addr").ToString() + "<br/><br/>"
            + "服务器名： " + Request.ServerVariables.Get("Server_Name").ToString() + "<br/><br/>"
            + "服务器地址： " + Request.ServerVariables["Url"].ToString() + "<br/><br/>"
            + "客户端提供的路径信息： " + Request.ServerVariables["Path_Info"].ToString() + "<br/><br/>"
            + "与应用程序元数据库路径相应的物理路径： " + Request.ServerVariables["Appl_Physical_Path"].ToString() + "<br/><br/>"
            + "通过由虚拟至物理的映射后得到的路径： " + Request.ServerVariables["Path_Translated"].ToString() + "<br/><br/>"
            + "执行脚本的名称： " + Request.ServerVariables["Script_Name"].ToString() + "<br/><br/>"
            + "接受请求的服务器端口号： " + Request.ServerVariables["Server_Port"].ToString() + "<br/><br/>"
            + "发出请求的远程主机的IP地址： " + Request.ServerVariables["Remote_Addr"].ToString() + "<br/><br/>"
            + "发出请求的远程主机名称IP地址： " + Request.ServerVariables["Remote_Host"].ToString() + "<br/><br/>"
            + "返回接受请求的服务器地址IP地址： " + Request.ServerVariables["Local_Addr"].ToString() + "<br/><br/>"
            + "返回服务器地址IP地址： " + Request.ServerVariables["Http_Host"].ToString() + "<br/><br/>"
            + "服务器的主机名、DNS地址或IP地址： " + Request.ServerVariables["Server_Name"].ToString() + "<br/><br/>"
            + "提出请求的方法比如GET、HEAD、POST等等： " + Request.ServerVariables["Request_Method"].ToString() + "<br/><br/>"
            + "如果接受请求的服务器端口为安全端口时，则为1，否则为0： " + Request.ServerVariables["Server_Port_Secure"].ToString() + "<br/><br/>"
            + "服务器使用的协议的名称和版本： " + Request.ServerVariables["Server_Protocol"].ToString() + "<br/><br/>"
            + "应答请求并运行网关的服务器软件的名称和版本： " + Request.ServerVariables["Server_Software"].ToString() + "<br/><br/>"
            ;


            if (Request.Cookies["admininfo"] != null)
            {
                this.namelit.Text = Request.Cookies["admininfo"]["name"];
                this.tellit.Text = Request.Cookies["admininfo"]["tel"];
            }


            SetttingMenu();


        }
    }

    private void SetttingMenu()
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Web.Security.FormsAuthentication.SignOut();

        Session.Abandon();
        Session.RemoveAll();
        Session.Clear();

        this.Response.Redirect("/AdminIndex.aspx");
        this.Response.End();
    }
}