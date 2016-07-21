<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Step.aspx.cs" Inherits="foundation_Step" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="/js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="top">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    &nbsp;步骤档案 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;步骤信息
                </td>
            </tr>
        </table>
    </div>
    <div id="contenttop">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 100px;">
                    步骤名称：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_name" runat="server" Width="200px"></asp:TextBox>
                </td>

                                <td style="width: 100px;">
                    所属工位：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:DropDownList ID="drp_stname" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                                <td style="width: 100px;">
                    部件名称：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:DropDownList ID="drp_bomanme" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                                <td style="width: 100px;">
                    部件数量：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_bomcount" runat="server" Width="200px"></asp:TextBox>
                </td>

            </tr>


            <tr>
                <td style="width: 100px;">
                    步骤节拍：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_clock" runat="server" Width="200px"></asp:TextBox>
                </td>
                                <td style="width: 100px;">
                    步骤描述：&nbsp;
                </td>
                <td style="width: 200px;">
                   <asp:TextBox ID="txt_desc" runat="server" Width="200px"></asp:TextBox>
                </td>
                                <td style="width: 100px;">
                    上传图片：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                                <td style="width: 100px; text-align: right">
                    <asp:Button ID="BtSave" runat="server" Text="新增步骤"  CssClass="addBtn" 
                        onclick="BtSave_Click" />
                </td>
            </tr>

        </table>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="step_id" CssClass="gridview" 
        onpageindexchanging="GridView1_PageIndexChanging" >
        <Columns>
            <asp:TemplateField HeaderText="步骤ID"> 
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("step_id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("step_id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="步骤名称">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("step_name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_ename" runat="server" Text='<%# Bind("step_name") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属工位">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("st_name") %>'></asp:Label>
                    <asp:Label ID="lb_stid" runat="server" Text='<%# Bind("st_id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="drp_stname" runat="server" Width="200px">
                    </asp:DropDownList>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部件名称">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("bom_name") %>'></asp:Label>
                    <asp:Label ID="lb_bomid" runat="server" Text='<%# Bind("bom_id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="drp_bomname" runat="server" Width="200px">
                    </asp:DropDownList>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部件数量">
            <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("bom_count") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_ecount" runat="server" Text='<%# Bind("bom_count") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="步骤节拍">
            <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("step_clock") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_eclock" runat="server" Text='<%# Bind("step_clock") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="步骤描述">
            <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("step_desc") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_edesc" runat="server" Text='<%# Bind("step_desc") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="图片" ItemStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_pic1" runat="server" Text='<%# Bind("step_pic") %>' Visible="false"></asp:Label>
                                                <img id ="img_pic" height="100px" width="60px" alt="<%#Eval("step_pic")%>" src="./image/step/<%#Eval("step_pic")%>" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                <EditItemTemplate>
                    <asp:FileUpload ID="upd_pic" runat="server" /><asp:Label ID="lbl_pic" runat="server" Text='<%# Bind("step_pic") %>' Visible="false"></asp:Label><img id ="img_pic" height="100px" width="60px" alt="<%#Eval("step_pic")%>" src="./image/step/<%#Eval("step_pic")%>" />
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
