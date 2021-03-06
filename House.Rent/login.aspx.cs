﻿using System;
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

        #region 暂时不用
        //string sql = "select count(*) from member where m_name='" + user
        //    + "' and m_pwd='" + pwd + "'";
        //string con = CommonLib.SqlHelper.SqlConnectionString;
        //int count = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null)); 
        #endregion

        ErrorType errorType=TableMemberHelper.VerifyLogin(user, pwd);
        if (errorType == ErrorType.Success)
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
}
