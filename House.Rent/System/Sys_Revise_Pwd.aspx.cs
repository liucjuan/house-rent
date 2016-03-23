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

public partial class System_Sys_Revise_Pwd : System.Web.UI.Page
{
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonLib.SqlHelper.islogin(Page);
            if (Request.Cookies["T-TXB"] != null)
            {
                user.Text = Server.UrlDecode(Request.Cookies["T-TXB"]["Manager"].ToString());
            }
        }
    }

    #region 修改密码
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (pwd.Text.Trim() != "" && txt_pwd.Text.Trim() != "" && txt_pwd.Text.Trim() == txt_pwd_re.Text.Trim())
        {
            string name = Server.UrlDecode(Request.Cookies["T-TXB"]["Manager"].ToString());
            string npwd = pwd.Text.Trim();
            string sql = "select count(*) from manager where manager_name='" + name + "' and manager_pwd='" + npwd + "'";
            int count = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null));
            if (count > 0)
            {
                npwd =txt_pwd.Text.Trim();
                sql = "update manager set manager_pwd='" + npwd + "' where manager_name='" + name + "'";
                try
                {
                    int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                    if (i > 0)
                    {
                        CommonLib.JavaScriptHelper.Alert("恭喜，修改成功！", this.Page);
                    }
                    else
                    {
                        CommonLib.JavaScriptHelper.Alert("服务器繁忙！修改失败！", this.Page);
                    }
                }
                catch
                {
                    CommonLib.JavaScriptHelper.Alert("服务器繁忙！修改失败！", this.Page);
                }
            }
            else
            {
                CommonLib.JavaScriptHelper.Alert("原始密码不正确！", this.Page);
            }
        }
    }
    #endregion
}
