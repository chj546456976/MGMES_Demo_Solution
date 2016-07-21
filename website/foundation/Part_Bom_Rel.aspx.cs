using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLL;
using Tools;


public partial class foundation_Part_Bom_Rel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    public static void MergeRows(GridView gvw, int col, string controlName)
    {
        for (int rowIndex = gvw.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gvw.Rows[rowIndex];

            GridViewRow previousRow = gvw.Rows[rowIndex + 1];

            Label row_lbl = row.Cells[col].FindControl(controlName) as Label;
            Label previousRow_lbl = previousRow.Cells[col].FindControl(controlName) as Label;

            if (row_lbl != null && previousRow_lbl != null)
            {
                if (row_lbl.Text == previousRow_lbl.Text)
                {
                    row.Cells[col].RowSpan = previousRow.Cells[col].RowSpan < 1 ? 2 : previousRow.Cells[col].RowSpan + 1;

                    previousRow.Cells[col].Visible = false;
                }
            }
        }
    }
    private void BindData()
    {
        BindPartName();
        BindBomName();
        this.GridView1.DataSource = Part_Bom_RelBLL.GetAllData();
        this.GridView1.DataBind();
        MergeRows(GridView1, 0, "lb_partid");
        MergeRows(GridView1, 1, "lb_partname");
        this.GridView1.SelectedIndex = -1;
        this.txt_count.Text = "";
        
    }



    private void BindBomName()
    {
        this.drp_bom.DataSource = Part_Bom_RelBLL.GetBomName();
        this.drp_bom.DataValueField = "bom_id";
        this.drp_bom.DataTextField = "bom_name";
        this.drp_bom.DataBind();
    }

    private void BindPartName()
    {
        this.drp_part.DataSource = Part_Bom_RelBLL.GetPartName();
        this.drp_part.DataValueField = "part_id";
        this.drp_part.DataTextField = "part_name";
        this.drp_part.DataBind();
    }

    protected void BtSave_Click(object sender, EventArgs e)
    {
        if (this.txt_count.Text.Trim() == "")
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "数量", "<script language='javascript'> alert('数量不能为空！');</script>");
            this.txt_count.Focus();
            return;
        }
        if (FormatHelper.IsInteger(this.txt_count.Text.Trim()) == false)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "数量", "<script language='javascript'> alert('数量必须是整数！');</script>");
            this.txt_count.Focus();
            return;
        }

        int count = Convert.ToInt32(this.txt_count.Text);
        int partid = Convert.ToInt32(this.drp_part.SelectedValue);
        int bomid = Convert.ToInt32(this.drp_bom.SelectedValue);


        bool IsExit = Part_Bom_RelBLL.CheckRelByPartidAndBomid(1,partid,bomid);
        if (IsExit)
        {
            bool flag = Part_Bom_RelBLL.AddRelByPartidAndBomid(partid, bomid, count);
            if (flag)
            {
                BindData();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "关系", "<script language='javascript'> alert('大部件与部件组合关系重复，保存失败！');</script>");
                return;
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "关系", "<script language='javascript'> alert('大部件与部件组合关系重复，保存失败！');</script>");
            return;
        }
    }
    protected void BtEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgBtn = sender as ImageButton;
        GridViewRow row = imgBtn.Parent.Parent as GridViewRow;
        this.GridView1.EditIndex = row.RowIndex;

        Label bomid = (Label)GridView1.Rows[GridView1.EditIndex].FindControl("lb_bomid");
        string old_bomid = bomid.Text;
        Label partid=(Label)GridView1.Rows[GridView1.EditIndex].FindControl("lb_partid");
        string old_partid = partid.Text;
        BindData();
        DropDownList ebomname = (DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("drp_bomname");
        ebomname.DataSource = Part_Bom_RelBLL.GetBomName(old_partid, old_bomid);
        ebomname.DataValueField = "bom_id";
        ebomname.DataTextField = "bom_name";
        ebomname.DataBind();
        ebomname.SelectedValue = old_bomid;
    }
    protected void BtDel_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgBtn = sender as ImageButton;
        GridViewRow row = imgBtn.Parent.Parent as GridViewRow;
        this.GridView1.EditIndex = row.RowIndex;
        Label lb_partid = (Label)GridView1.Rows[row.RowIndex].FindControl("lb_partid");
        int partid = NumericParse.StringToInt(lb_partid.Text);
        Label lb_bomid = (Label)GridView1.Rows[row.RowIndex].FindControl("lb_bomid");
        int bomid = NumericParse.StringToInt(lb_bomid.Text);

        bool flag = Part_Bom_RelBLL.DelRelByPartidAndBomid(partid, bomid);
        if (flag)
        {
            GridView1.EditIndex = -1;
            BindData();
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "名称", "<script language='javascript'> alert('删除失败！');</script>");
            return;
        }
    }
    protected void BtSave_Click1(object sender, ImageClickEventArgs e)
    {
        Label epartid = (Label)GridView1.Rows[GridView1.EditIndex].FindControl("lb_epartid");
        TextBox ecount = (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("txt_ecount");
        DropDownList ebomname = (DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("drp_bomname");
        Label lb_obomid = (Label)GridView1.Rows[GridView1.EditIndex].FindControl("lb_obomid");

        if (ecount.Text.Trim() == "")
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "数量", "<script language='javascript'> alert('数量不能为空！');</script>");
            ecount.Focus();
            return;
        }
        if (FormatHelper.IsInteger(ecount.Text.Trim()) == false)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "数量", "<script language='javascript'> alert('数量必须是整数！');</script>");
            ecount.Focus();
            return;
        }

        int partid = NumericParse.StringToInt(epartid.Text);
        int bomid = Convert.ToInt32(ebomname.SelectedValue);
        int count = NumericParse.StringToInt(ecount.Text);
        int obomid = NumericParse.StringToInt(lb_obomid.Text);

        bool IsExit = Part_Bom_RelBLL.CheckRelByPartidAndBomid(2, partid, bomid);
        if (IsExit)
        {
            bool flag = Part_Bom_RelBLL.UpdateRelByPartidAndBomid(partid, bomid,obomid, count);
            if (flag)
            {
                GridView1.EditIndex = -1;
                BindData();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "姓名", "<script language='javascript'> alert('保存失败！');</script>");
                return;
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "姓名", "<script language='javascript'> alert('姓名重复，保存失败！');</script>");
            return;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }
}