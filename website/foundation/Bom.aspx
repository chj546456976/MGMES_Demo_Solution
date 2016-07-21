<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Bom.aspx.cs" Inherits="foundation_Bom" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="/js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="top">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    &nbsp;部件档案 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;部件信息
                </td>
            </tr>
        </table>
    </div>
    <div id="contenttop">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 100px;">
                    部件名称：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_name" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 100px;">
                    部件编号：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_no" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 100px;">
                    部件等级：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_level" runat="server" Width="200px"></asp:TextBox>
                </td> 
                <td style="width: 100px;">
                    部件描述：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_desc" runat="server" Width="200px"></asp:TextBox>
                </td> 
            </tr>

            <tr>
                <td style="width: 100px;">
                    部件图片：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:FileUpload ID="Fld_pic" runat="server" />
                </td>
                <td style="width: 100px;">
                    部件材质：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_material" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 100px;">
                    部件说明：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_profile" runat="server" Width="200px"></asp:TextBox>
                </td> 
                <td style="width: 100px;">
                    部件重量：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_weight" runat="server" Width="200px"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td style="width: 100px;">
                    部件供应商：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_supplier" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 100px;">
                    部件品类：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_category" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td style="width: 100px;">
                    备注：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_comments" runat="server" Width="200px"></asp:TextBox>
                </td> 
                <td style="width: 100px; text-align: right">
                    <asp:Button ID="BtSave" runat="server" Text="新增部件"  CssClass="addBtn" 
                        onclick="BtSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="bom_id" CssClass="gridview" 
        onpageindexchanging="GridView1_PageIndexChanging" >
        <Columns>
            <asp:TemplateField HeaderText="部件ID"> 
                <ItemTemplate>
                    <asp:Label ID="lb_id" runat="server" Text='<%# Bind("bom_id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lb_eid" runat="server" Text='<%# Bind("bom_id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部件名称">
                <ItemTemplate>
                    <asp:Label ID="lb_name" runat="server" Text='<%# Bind("bom_name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_ename" runat="server" Text='<%# Bind("bom_name") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部件编号">
                <ItemTemplate>
                    <asp:Label ID="lb_no" runat="server" Text='<%# Bind("bom_no") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_eno" runat="server" Text='<%# Bind("bom_no") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部件等级">
                <ItemTemplate>
                    <asp:Label ID="lb_level" runat="server" Text='<%# Bind("bom_leve") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_elevel" runat="server" Text='<%# Bind("bom_leve") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部件描述">
                <ItemTemplate>
                    <asp:Label ID="lb_desc" runat="server" Text='<%# Bind("bom_desc") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_edesc" runat="server" Text='<%# Bind("bom_desc") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部件图片" ItemStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label ID="lb_pic" runat="server" Text='<%# Bind("bom_picture") %>' Visible="false"></asp:Label>
                    <img id ="img_pic" height="100px" width="60px" alt="<%#Eval("bom_picture")%>" src="./image/bom/<%#Eval("bom_picture")%>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="upd_pic" runat="server" /><asp:Label ID="lbl_opic" runat="server" Text='<%# Bind("bom_picture") %>' Visible="false"></asp:Label><img id ="img_opic" height="100px" width="60px" alt="<%#Eval("bom_picture")%>" src="./image/bom/<%#Eval("bom_picture")%>" />
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="部件材质">
                <ItemTemplate>
                    <asp:Label ID="lb_material" runat="server" Text='<%# Bind("bom_material") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_ematerial" runat="server" Text='<%# Bind("bom_material") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="部件说明">
                <ItemTemplate>
                    <asp:Label ID="lb_profile" runat="server" Text='<%# Bind("bom_profile") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_eprofile" runat="server" Text='<%# Bind("bom_profile") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="部件重量">
                <ItemTemplate>
                    <asp:Label ID="lb_weight" runat="server" Text='<%# Bind("bom_weight") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_eweight" runat="server" Text='<%# Bind("bom_weight") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="部件供应商">
                <ItemTemplate>
                    <asp:Label ID="lb_suppller" runat="server" Text='<%# Bind("bom_suppller") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_esuppller" runat="server" Text='<%# Bind("bom_suppller") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="部件品类">
                <ItemTemplate>
                    <asp:Label ID="lb_category" runat="server" Text='<%# Bind("bom_category") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_ecategory" runat="server" Text='<%# Bind("bom_category") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                <ItemTemplate>
                    <asp:Label ID="lb_comments" runat="server" Text='<%# Bind("bom_comments") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_ecomments" runat="server" Text='<%# Bind("bom_comments") %>'></asp:TextBox>
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
