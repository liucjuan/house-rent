using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class System_Sys_Member_List : System.Web.UI.Page
{
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonLib.SqlHelper.islogin(Page);
            Bind();
        }
    }

    #region 绑定
    private void Bind()
    {
        string count = "select count(*) from member";
        AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
        string sql = "select * from member order by m_id desc";
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
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    #endregion

    #region 删除、重置密码、更改状态
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sql = "";
        if (e.CommandName == "del")
        {
            sql = "delete from member where m_id=" + e.CommandArgument.ToString();

            try
            {
                int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                if (i > 0)
                {
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
        if (e.CommandName == "reset")
        {
            string n_pwd = CommonLib.EncryptHelper.Encrypt("123456", "MD5");
            sql = "update member set m_pwd='" + n_pwd + "' where m_id=" + e.CommandArgument.ToString();

            try
            {
                int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                if (i > 0)
                {
                    CommonLib.JavaScriptHelper.Alert("恭喜，密码成功！初始密码为：123456！", this.Page);
                }
                else
                {
                    CommonLib.JavaScriptHelper.Alert("服务器繁忙，操作失败！", this.Page);
                }
            }
            catch
            {
                CommonLib.JavaScriptHelper.Alert("服务器繁忙，操作失败！", this.Page);
            }
        }
        Bind();
    }
    #endregion

    #region 批量删除
    protected void Button2_Click(object sender, EventArgs e)
    {
        string idlist = "";
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chkbx = (CheckBox)GridView1.Rows[row.RowIndex].Cells[6].FindControl("chk1");
            int id = Convert.ToInt32(GridView1.Rows[row.RowIndex].Cells[0].Text);
            if (chkbx.Checked)
            {
                idlist += id.ToString() + ",";
            }
        }
        if (idlist.Length > 0)
        {
            idlist = idlist.Substring(0, idlist.Length - 1);
            string sql = "delete from member where m_id in (" + idlist + ")";
            try
            {
                int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                if (i > 0)
                {
                    Bind();
                    CommonLib.JavaScriptHelper.Alert("恭喜，批量删除成功！", this.Page);
                }
                else
                    CommonLib.JavaScriptHelper.Alert("服务器繁忙，删除失败！", this.Page);
            }
            catch
            {
                CommonLib.JavaScriptHelper.Alert("服务器繁忙，删除失败！", this.Page);
            }
            this.quanxuan.Value = " 全 选 ";
        }
        else
        {
            CommonLib.JavaScriptHelper.Alert("请选择需要删除的数据！", this.Page);
        }
    }
    #endregion
}
