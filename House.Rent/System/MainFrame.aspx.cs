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

public partial class System_MainFrame : System.Web.UI.Page
{
    #region 初始化页面
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonLib.SqlHelper.islogin(Page);
            if (Request.Cookies["T-TXB"] != null)
            {
                if (Request.Cookies["T-TXB"]["Manager"] != null)
                {
                    Label1.Text = HttpUtility.UrlEncode(Request.Cookies["T-TXB"]["Manager"].ToString());
                }
                else
                {
                    Response.Redirect("managerthisway.aspx");
                }
            }
            else
            {
                Response.Redirect("managerthisway.aspx");
            }
        }
    }
    #endregion

    #region 安全退出
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["T-TXB"];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddDays(-1);
            cookie.Values.Clear();
            System.Web.HttpContext.Current.Response.Cookies.Set(cookie);
        }
        Response.Redirect("../index.aspx");
    }
    #endregion
}
