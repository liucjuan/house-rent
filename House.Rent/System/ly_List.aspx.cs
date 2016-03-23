using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class System_Sys_Log_List : System.Web.UI.Page
{
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonLib.SqlHelper.islogin(Page);
            Bind();
        }
    }

    #region 绑定
    private void Bind()
    {
        string count = "select count(*) from liuyan";
        AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
        string sql = "select * from liuyan order by id desc";
        CommonLib.SqlHelper.BindGridView(GridView1, sql, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1);
        if (AspNetPager1.RecordCount > 0)
        {
            quanxuan.Visible = true;
            Button2.Visible = true;
        }
        else
        {
            quanxuan.Visible = false;
            Button2.Visible = false;
        }
    }
    #endregion

    #region 分页
    //分页
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    #endregion

    #region 删除
    //删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sql = "";
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
   
         sql = "delete from liuyan where id=" + id.ToString();
        try
        {

            int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
            if (i > 0)
            {
                Bind();
                CommonLib.JavaScriptHelper.Alert("恭喜，删除成功！", this.Page);
            }
            else
            {
                CommonLib.JavaScriptHelper.Alert("服务器繁忙，删除失败！", this.Page);
            }
        }
        catch
        {
            CommonLib.JavaScriptHelper.Alert("服务器繁忙，删除失败！", this.Page);
        }
    }
    #endregion

    #region 批量删除
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        string idlist = "0";
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chkbx = (CheckBox)GridView1.Rows[row.RowIndex].Cells[4].FindControl("chk1");
            int id = Convert.ToInt32(GridView1.Rows[row.RowIndex].Cells[0].Text);
            if (chkbx.Checked)
            {
                idlist += "," + id.ToString();
            }
        }
        if (idlist == "0")
        {
            CommonLib.JavaScriptHelper.Alert("请选择要删除的数据！", this.Page);
        }
        else
        {
            string sql = "delete from liuyan where id in (" + idlist + ")";
            try
            {

                int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                if (i > 0)
                {
                    Bind();
                    CommonLib.JavaScriptHelper.Alert("恭喜，批量删除成功！", this.Page);
                }
                else
                {
                    CommonLib.JavaScriptHelper.Alert("服务器繁忙，批量删除失败！", this.Page);
                }
            }
            catch
            {
                CommonLib.JavaScriptHelper.Alert("服务器繁忙，批量删除失败！", this.Page);
            }
            this.quanxuan.Value = " 全 选 ";
        }
    }
    #endregion


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString()== "hf")
        {
            Response.Redirect("hf.aspx?id='"+e.CommandArgument.ToString()+"'");
        }
    }
}
