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
using System.Data.SqlClient;
public partial class System_Sys_Member_Add : System.Web.UI.Page
{
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonLib.SqlHelper.islogin(Page);
            //#region 会员编号
            //string mname = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
            //string con = CommonLib.SqlHelper.SqlConnectionString;
            //string sql = "select m_id from member where m_name='" + mname + "'";
            //string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
            //

            if (Request.QueryString["id"] != null)
            {
                string sql = "select * from liuyan where id=" + Request.QueryString["id"] + "";
                SqlDataReader dr = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql, null);
                if (dr.Read())
                {
                    title.Text = dr["title"].ToString();

                    dr.Close(); dr.Dispose();
                }
                else
                {
                    dr.Close(); dr.Dispose();
                    CommonLib.JavaScriptHelper.AlertAndRedirect("数据不存在或已删除", "member_buy_list.apx", Page);
                }
            }
        }
    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {

        CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, "insert into hf(lid,hfnr)values("+Request.QueryString["id"].ToString()+",'"+intro.Text+"')", null);
        CommonLib.JavaScriptHelper.Alert("回复成功",Page);
    }

  
    private string urnhtml(string str)
    {
        return CommonLib.CutString.UrnHtml(str);
    }

   
}
