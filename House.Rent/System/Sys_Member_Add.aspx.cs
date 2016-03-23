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

public partial class System_Sys_Member_Add : System.Web.UI.Page
{
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonLib.SqlHelper.islogin(Page);
        }
    }

    #region 添加
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "select count(*) from member where m_name='" + CommonLib.CutString.UrnHtml(txt_user.Text.Trim()) + "'";
        int count = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null));
        if (count == 0)
        {
            string n_pwd =txt_pwd.Text.Trim();
            sql = "insert into member (m_name,m_pwd,m_tel,m_add,m_qq) values ";
            sql += "('" + CommonLib.CutString.UrnHtml(txt_user.Text.Trim()) + "','" + n_pwd
                + "','" + CommonLib.CutString.UrnHtml(tel.Text.Trim()) +"','"
                + CommonLib.CutString.UrnHtml(add.Text.Trim()) + "','" + CommonLib.CutString.UrnHtml(qq.Text.Trim()) + "')";

            try
            {
                int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);

                if (i > 0)
                {
                    CommonLib.JavaScriptHelper.AlertAndRedirect("恭喜，该用户已添加成功！", "sys_member_list.aspx", this.Page);
                }
                else
                {
                    CommonLib.JavaScriptHelper.Alert("服务器繁忙，添加失败！", this.Page);
                }
            }
            catch
            {
                CommonLib.JavaScriptHelper.Alert("服务器繁忙，添加失败！", this.Page);
            }
        }
        else
        {
            CommonLib.JavaScriptHelper.Alert("用户名已存在！请重新输入！", this.Page);
        }
    }
    #endregion
}
