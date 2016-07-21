<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Part_Bom_Rel.aspx.cs" Inherits="foundation_Part_Bom_Rel" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="/js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="top">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    &nbsp;大部件与部件组合关系 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;大部件与部件组合关系
                </td>
            </tr>
        </table>
    </div>
    <div id="contenttop">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 100px;">
                    大部件名称：&nbsp;
                </td>
                          <td style="width: 200px;">
                    <asp:DropDownList ID="drp_part" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                                 <td style="width: 100px;">
                    部件名称：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:DropDownList ID="drp_bom" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="width: 100px;">
                    部件数量：&nbsp;
                </td>
                <td style="width: 200px;">
                    <asp:TextBox ID="txt_count" runat="server" Width="200px"></asp:TextBox>
                </td> 
                                <td style="width: 100px; text-align: right">

                    <asp:Button ID="BtSave" runat="server" Text="添加组合关系"  CssClass="addBtn" 
                        onclick="BtSave_Click" />
                </td>

                               
            </tr>

        </table>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="part_id" CssClass="gridview" 
        onpageindexchanging="GridView1_PageIndexChanging" >
        <Columns>
            <asp:TemplateField HeaderText="大部件ID"> 
                <ItemTemplate>
                    <asp:Label ID="lb_partid" runat="server" Text='<%# Bind("part_id") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lb_epartid" runat="server" Text='<%# Bind("part_id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="大部件名称">
                <ItemTemplate>
                    <asp:Label ID="lb_partname" runat="server" Text='<%# Bind("part_name") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lb_epartname" runat="server" Text='<%# Bind("part_name") %>'></asp:Label>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部件名称">
                <ItemTemplate>
                    <asp:Label ID="lb_bomname" runat="server" Text='<%# Bind("bom_name") %>'></asp:Label>
                    <asp:Label ID="lb_bomid" runat="server" Text='<%# Bind("bom_id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="drp_bomname" runat="server" Width="200px">
                    </asp:DropDownList>
                    <asp:Label ID="lb_obomid" runat="server" Text='<%# Bind("bom_id") %>' Visible="false"></asp:Label>
                </EditItemTemplate>
                <HeaderStyle Width="200px" />
            </asp:TemplateField>

                        <asp:TemplateField HeaderText="部件数量">
                <ItemTemplate>
                    <asp:Label ID="lb_count" runat="server" Text='<%# Bind("bom_count") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txt_ecount" runat="server" Text='<%# Bind("bom_count") %>'></asp:TextBox>
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
