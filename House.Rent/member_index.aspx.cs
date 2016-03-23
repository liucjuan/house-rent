using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class member_index : System.Web.UI.Page
{
    #region 初始化
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["buy"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            Bind();
        }
    }
    #endregion

    #region 绑定
    private void Bind()
    {
        string name = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
        string sql = "select * from member where m_name='" + name + "'";
        string con = CommonLib.SqlHelper.SqlConnectionString;
        SqlDataReader dr = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql, null);
        if (dr.Read())
        {
            tel.Text = dr["m_tel"].ToString();
            qq.Text = dr["m_qq"].ToString();
            add.Text = dr["m_add"].ToString();
        }
        dr.Close(); dr.Dispose();
    }
    #endregion

    #region 提交
    protected void Button1_Click(object sender, EventArgs e)
    {
        string name = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
        string con = CommonLib.SqlHelper.SqlConnectionString;
        string sql = "update member set m_qq='" + CommonLib.CutString.UrnHtml(qq.Text.Trim())
            + "',m_tel='" + CommonLib.CutString.UrnHtml(tel.Text.Trim())
            + "',m_add='" + CommonLib.CutString.UrnHtml(add.Text.Trim())
            + "' where m_name='" + name + "'";
        try
        {
            CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
            CommonLib.JavaScriptHelper.Alert("修改成功！", Page);
        }
        catch
        {
            CommonLib.JavaScriptHelper.Alert("修改失败！", Page);
        }
    }
    #endregion
}
