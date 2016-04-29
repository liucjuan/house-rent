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
using System.Collections.Generic;

public partial class member_pwd : System.Web.UI.Page
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
        }
    }
    #endregion

    #region 提交
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (pwd.Text == "" || pwd2.Text == "" || pwd3.Text == "" || pwd2.Text != pwd3.Text)
        {
            CommonLib.JavaScriptHelper.Alert("输入的信息有误", Page);
            return;
        }
        string name = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
        string con = CommonLib.SqlHelper.SqlConnectionString;
        string npwd = pwd.Text;// CommonLib.EncryptHelper.Encrypt(pwd.Text, "MD5");
        //string sql = "select count(*) from member where m_name='" + name + "' and m_pwd='" + npwd + "'";

        //int SelectDataCount(List<string> fieldList, Dictionary<string, string> whereDic, string tableName)
        List<string> fieldList = new List<string>();
        Dictionary<string, string> whereDic = new Dictionary<string, string>();
        whereDic.Add("m_name",name);
        whereDic.Add("m_pwd", npwd);
        int count=DBHelper.SelectDataCount(fieldList,whereDic, DBConfig.member);
       // int count = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null));
        if (count == 0)
        {
            CommonLib.JavaScriptHelper.Alert("您输入的原密码不正确", Page);
        }
        else
        {
            npwd = pwd2.Text;// CommonLib.EncryptHelper.Encrypt(pwd2.Text, "MD5");
            //sql = "update member set m_pwd='" + npwd + "' where m_name='" + name + "'";

            //ErrorType UpdateData(Dictionary<string, string> updateDic, Dictionary<string, string> whereDic, string tableName)
            Dictionary<string, string> updateDic = new Dictionary<string, string>();
            whereDic.Clear();
            whereDic.Add("m_name",name);
            updateDic.Add("m_pwd", npwd);
            ErrorType errorType = DBHelper.UpdateData(updateDic,whereDic,DBConfig.member);
            if (errorType == ErrorType.Success)
            {
                CommonLib.JavaScriptHelper.AlertAndRedirect("修改成功,请重新登陆","login.aspx");
            }
            else
            {
                CommonLib.JavaScriptHelper.Alert("修改失败", Page);
            }
            if (errorType == ErrorType.Success)
            {
              //  Response.Redirect("login.aspx");
            }
            //try
            //{
            //    CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
            //    CommonLib.JavaScriptHelper.Alert("修改成功", Page);
            //}
            //catch
            //{
            //    CommonLib.JavaScriptHelper.Alert("修改失败", Page);
            //}
        }
    }
    #endregion
}
