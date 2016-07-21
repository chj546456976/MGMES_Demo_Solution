<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="foundation_User" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="/js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="top">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    &nbsp;员工档案 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;员工信息
                </td>
            </tr>
        </table>
    </div>
    <div id="contenttop">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 100px;">
                    员工姓名：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_name" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 100px;">
                    登录密码：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_pwd" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 100px;">
                    员工RFID：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_rfid" runat="server" Width="200px"></asp:TextBox>
                </td> 
                <td style="width: 100px;">
                    员工Email：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_email" runat="server" Width="200px"></asp:TextBox>
                </td> 
            </tr>

            <tr>
                <td style="width: 100px;">
                    员工头像：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:FileUpload ID="Fld_pic" runat="server" />
                </td>
                <td style="width: 100px;">
                    所属部门：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:DropDownList ID="drp_depname" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="width: 100px;">
                    所属职位：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:DropDownList ID="drp_posiname" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="width: 100px;">
                    用户可见：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_menuids" runat="server" Width="200px"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td style="width: 100px; text-align: right">
                    <asp:Button ID="BtSave" runat="server" Text="新增员工"  CssClass="addBtn" 
                        onclick="BtSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="user_id" CssClass="gridview" 
        onpageindexchanging="GridView1_PageIndexChanging" >
        <Columns>
            <asp:TemplateField HeaderText="员工ID"> 
                <ItemTemplate>
                    <asp:Label ID="lb_id" runat="server" Text='<%# Bind("user_id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lb_eid" runat="server" Text='<%# Bind("user_id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工姓名">
                <ItemTemplate>
                    <asp:Label ID="lb_name" runat="server" Text='<%# Bind("user_name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_ename" runat="server" Text='<%# Bind("user_name") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="登录密码">
                <ItemTemplate>
                    <asp:Label ID="lb_pwd" runat="server" Text='<%# Bind("user_pwd") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_epwd" runat="server" Text='<%# Bind("user_pwd") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工RFID">
                <ItemTemplate>
                    <asp:Label ID="lb_rfid" runat="server" Text='<%# Bind("user_no") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_erfid" runat="server" Text='<%# Bind("user_no") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工Email">
                <ItemTemplate>
                    <asp:Label ID="lb_email" runat="server" Text='<%# Bind("user_email") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_eemail" runat="server" Text='<%# Bind("user_email") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工头像" ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label ID="lb_pic" runat="server" Text='<%# Bind("user_pic") %>' Visible="false"></asp:Label>
                    <img id ="img_pic" height="100px" width="60px" alt="<%#Eval("user_pic")%>" src="./image/user/<%#Eval("user_pic")%>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="upd_pic" runat="server" /><asp:Label ID="lbl_opic" runat="server" Text='<%# Bind("user_pic") %>' Visible="false"></asp:Label><img id ="img_opic" height="100px" width="60px" alt="<%#Eval("user_pic")%>" src="./image/user/<%#Eval("user_pic")%>" />
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="所属部门">
                <ItemTemplate>
                    <asp:Label ID="lb_depname" runat="server" Text='<%# Bind("dep_name") %>'></asp:Label>
                    <asp:Label ID="lb_depno" runat="server" Text='<%# Bind("user_depid") %>' Visible ="false"></asp:Label>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:DropDownList ID="drp_edepname" runat="server" Width="200px">
                    </asp:DropDownList>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属职位">
                <ItemTemplate>
                    <asp:Label ID="lb_posiname" runat="server" Text='<%# Bind("posi_name") %>'></asp:Label>
                    <asp:Label ID="lb_posino" runat="server" Text='<%# Bind("user_posiid") %>' Visible ="false"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="drp_eposiname" runat="server" Width="200px">
                    </asp:DropDownList>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用户可见">
                <ItemTemplate>
                    <asp:Label ID="lb_menuids" runat="server" Text='<%# Bind("user_menuids") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_emenuids" runat="server" Text='<%# Bind("user_menuids") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="功能">
                <ItemTemplate>
                    <asp:ImageButton ID="BtEdit" runat="server" ImageUrl="~/image/admin/pen.png" 
                        onclick="BtEdit_Click"  />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="BtDel" runat="server" ImageUrl="~/image/admin/delete1.png" 
                        onclick="BtDel_Click"  />
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/image/admin/save.png" onclick="BtSave_Click1" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="BtCancel" runat="server" 
                        ImageUrl="~/image/admin/undo.png"  />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </EditItemTemplate>
                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
