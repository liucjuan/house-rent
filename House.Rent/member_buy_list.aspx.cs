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

public partial class member_buy_list : System.Web.UI.Page
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
        string sql = "select m_id from member where m_name='" + name + "'";
        string con = CommonLib.SqlHelper.SqlConnectionString;
        string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        string where = " where pro_type=2 and m_id=" + mid;
        string count = "select count(*) from product" + where;
        AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
        sql = "select * from product" + where + " order by pro_id desc";
        CommonLib.SqlHelper.BindRepeater(rep_list, sql, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1);
    }
    #endregion

    #region 分页
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    #endregion

    #region 删除
    protected void rep_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string sql = "select pro_img from product where pro_id="+e.CommandArgument;
            string path = CommonLib.SqlHelper.ExecuteScalar(con,CommandType.Text,sql,null).ToString();
            sql = "delete from product where pro_id=" + e.CommandArgument;
            try
            {
                CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                Bind();
                try { System.IO.File.Delete(Server.MapPath("~/upload/" + path)); }
                catch { }
                CommonLib.JavaScriptHelper.Alert("删除成功", Page);
            }
            catch
            {
                CommonLib.JavaScriptHelper.Alert("删除失败", Page);
            }
        }
    }
    #endregion

    #region 获取分类
    protected string getclsname(string id)
    {
        string con = CommonLib.SqlHelper.SqlConnectionString;
        string sql = "select pro_cls_name from pro_cls where pro_cls_id=" + id;
        string name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        sql = "select pro_cls_name from pro_cls where pro_cls_id in "
            + "(select pro_cls_pid from pro_cls where pro_cls_id=" + id + ")";
        string name2 = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        return name2 + " >> " + name;
    }
    #endregion
}
