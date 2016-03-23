using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    //登陆
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CheckCode"] == null)
        {
            CommonLib.JavaScriptHelper.Alert("您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统", Page);
            return;
        }

        if (String.Compare(Request.Cookies["CheckCode"].Value, txtPng.Text.ToString().Trim(), true) != 0)
        {
            CommonLib.JavaScriptHelper.Alert("验证码不正确！", Page);
            txtPng.Text = "";
            return;
        }
        else
        {
            string con = CommonLib.SqlHelper.SqlConnectionString;
            string user = CommonLib.CutString.CutHTML(txtUserName.Text.Trim());
            string pwd =txtPwd.Text.Trim();
            string sql = "select count(*) from manager where manager_name='" + user
                + "' and manager_pwd='" + pwd + "'";
            int count = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null));
            if (count > 0)
            {
                HttpCookie cookies = Request.Cookies["T-TXB"];
                cookies = new HttpCookie("T-TXB");
                cookies.Values.Add("Manager", HttpUtility.UrlEncode(txtUserName.Text.Trim()));
                cookies.Expires = DateTime.Now.AddHours(24);//1天有效24小时 
                Response.Cookies.Set(cookies);//存储！～ 
                CommonLib.JavaScriptHelper.Redirect("mainframe.aspx");
            }
            else
            {
                CommonLib.JavaScriptHelper.Alert("用户名或密码错误！", Page);
            }
        }
    }
}
