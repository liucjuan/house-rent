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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region 登录
    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = CommonLib.CutString.UrnHtml(login_user.Text.Trim());
        string pwd = login_pwd.Text;
        string sql = "select count(*) from member where m_name='" + user
            + "' and m_pwd='" + pwd + "'";
        string con = CommonLib.SqlHelper.SqlConnectionString;
        int count = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null));
        if (count > 0)
        {
            HttpCookie cookies = Request.Cookies["buy"];
            cookies = new HttpCookie("buy");
            Session["uid"] = user;
            cookies.Values.Add("user", HttpUtility.UrlEncode(user));
            cookies.Expires = DateTime.Now.AddHours(24);//1天有效24小时 
            Response.Cookies.Set(cookies);//存储！～ 
            Response.Redirect("member_index.aspx");
        }
        else
        {
            CommonLib.JavaScriptHelper.Alert("您输入的用户名或密码错误", Page);
        }
    }
    #endregion
    #region 注册
    protected void Button2_Click(object sender, EventArgs e)
    {
        #region 验证
        if (r_user.Text.Trim() == "")
        {
            CommonLib.JavaScriptHelper.Alert("请输入用户名", Page);
            r_user.Focus();
            return;
        }
        if (r_pwd.Text.Trim() == "")
        {
            CommonLib.JavaScriptHelper.Alert("请输入密码", Page);
            r_pwd.Focus();
            return;
        }
        if (r_pwd2.Text.Trim() == "")
        {
            CommonLib.JavaScriptHelper.Alert("请重写输入密码", Page);
            r_pwd2.Focus();
            return;
        }
        if (r_pwd.Text.Trim() != r_pwd2.Text.Trim())
        {
            CommonLib.JavaScriptHelper.Alert("您输入的密码不一致", Page);
            r_pwd2.Focus();
            return;
        }
        #endregion
        string user = CommonLib.CutString.UrnHtml(r_user.Text.Trim());
        string pwd =r_pwd.Text;
        string sql = "select count(*) from member where m_name='" + user + "'";
        string con = CommonLib.SqlHelper.SqlConnectionString;
        int count = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null));
        if (count > 0)
        {
            CommonLib.JavaScriptHelper.Alert("该用户名已被注册", Page);
            return;
        }
        else
        {
            sql = "insert into member (m_name,m_pwd,m_tel,m_add,m_qq) values ('" + user
                + "','" + pwd + "','" + CommonLib.CutString.UrnHtml(tel.Text.Trim())
                + "','" + CommonLib.CutString.UrnHtml(add.Text.Trim())
                + "','" + CommonLib.CutString.UrnHtml(qq.Text.Trim()) + "')";
            try
            {
                CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                CommonLib.JavaScriptHelper.AlertAndRedirect("恭喜注册成功！", "login.aspx", Page);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                CommonLib.JavaScriptHelper.Alert("注册失败", Page);
            }
        }
    }
    #endregion
}
