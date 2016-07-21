<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Operator.aspx.cs" Inherits="foundation_Operator" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="/js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="top">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    &nbsp;操作工档案 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;操作工信息
                </td>
            </tr>
        </table>
    </div>
    <div id="contenttop">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 100px;">
                    操作工姓名：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_name" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 100px;">
                    操作工RFID：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_rfid" runat="server" Width="200px"></asp:TextBox>
                </td> 
                <td style="width: 100px;">
                    员工头像：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:FileUpload ID="Fld_pic" runat="server" />
                </td>
                               
            </tr>
            <tr>
                 <td style="width: 100px;">
                    工位名称：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:DropDownList ID="drp_stname" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                    <td style="width: 100px;">
                    是否管理员：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:DropDownList ID="drp_isoperator" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="width: 100px; text-align: right">
                    <asp:Button ID="BtSave" runat="server" Text="新增员工"  CssClass="addBtn" 
                        onclick="BtSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="op_id" CssClass="gridview" 
        onpageindexchanging="GridView1_PageIndexChanging" >
        <Columns>
            <asp:TemplateField HeaderText="操作工ID"> 
                <ItemTemplate>
                    <asp:Label ID="lb_id" runat="server" Text='<%# Bind("op_id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lb_eid" runat="server" Text='<%# Bind("op_id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作工姓名">
                <ItemTemplate>
                    <asp:Label ID="lb_name" runat="server" Text='<%# Bind("op_name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_ename" runat="server" Text='<%# Bind("op_name") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工RFID">
                <ItemTemplate>
                    <asp:Label ID="lb_rfid" runat="server" Text='<%# Bind("op_no") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_erfid" runat="server" Text='<%# Bind("op_no") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工头像" ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label ID="lb_pic" runat="server" Text='<%# Bind("op_pic") %>' Visible="false"></asp:Label>
                    <img id ="img_pic" height="100px" width="60px" alt="<%#Eval("op_pic")%>" src="./image/operator/<%#Eval("op_pic")%>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="upd_pic" runat="server" /><asp:Label ID="lbl_opic" runat="server" Text='<%# Bind("op_pic") %>' Visible="false"></asp:Label><img id ="img_opic" height="100px" width="60px" alt="<%#Eval("op_pic")%>" src="./image/operator/<%#Eval("op_pic")%>" />
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="工位名称">
                <ItemTemplate>
                    <asp:Label ID="lb_stname" runat="server" Text='<%# Bind("st_name") %>'></asp:Label>
                    <asp:Label ID="lb_stno" runat="server" Text='<%# Bind("st_id") %>' Visible ="false"></asp:Label>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:DropDownList ID="drp_estname" runat="server" Width="200px">
                    </asp:DropDownList>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否管理员">
                <ItemTemplate>
                    <asp:Label ID="lb_operator" runat="server" Text='<%# Bind("isoperator") %>'></asp:Label>
                    <asp:Label ID="lb_isoperator" runat="server" Text='<%# Bind("op_isoperator") %>' Visible ="false"></asp:Label>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:DropDownList ID="drp_eisoperator" runat="server" Width="200px">
                    </asp:DropDownList>
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
