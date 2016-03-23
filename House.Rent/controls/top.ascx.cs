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

public partial class controls_top : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "房屋租赁系统";
        CommonLib.FileHelper.AddJS("js/web.js", Page);
    }

    #region 退出
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["buy"];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddDays(-1);
            cookie.Values.Clear();
            System.Web.HttpContext.Current.Response.Cookies.Set(cookie);
        }
        Response.Redirect("login.aspx");
    }
    #endregion
}
