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

public partial class System_Sys_Product_List : System.Web.UI.Page
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
        string count = "";
        string sql = "";
        
            sql = "select * from czht order by id desc";
            count = "select count(*) from czht";
        AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
       
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
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        string sql = "select path from czht where id=" + id.ToString();
        string path = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();

        sql = "delete from czht where id=" + id.ToString();
        try
        {

            int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
            if (i > 0)
            {
                Bind();
                try { System.IO.File.Delete(Server.MapPath("~/upload/" + path)); }
                catch { }
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
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chkbx = (CheckBox)GridView1.Rows[row.RowIndex].Cells[8].FindControl("chk1");
            int id = Convert.ToInt32(GridView1.Rows[row.RowIndex].Cells[0].Text);
            if (chkbx.Checked)
            {
                string sql = "select path from czht where id=" + id.ToString();
                string path = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
                sql = "delete from czht where id=" + id.ToString();
                try
                {
                    CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                    try { System.IO.File.Delete(Server.MapPath("~/upload/" + path)); }
                    catch { }
                }
                catch
                { }
            }
        }
        this.quanxuan.Value = " 全 选 ";
        Bind();
        CommonLib.JavaScriptHelper.Alert("恭喜，批量删除成功！", this.Page);
    }
    #endregion

   
}
