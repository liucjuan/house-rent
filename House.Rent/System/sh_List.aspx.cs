using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class System_Sys_Product_List : System.Web.UI.Page
{
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonLib.SqlHelper.islogin(Page);
           
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["cls"]);
                    if (id == 2)
                    {
                        GridView1.Columns[3].Visible = false;
                        GridView1.Columns[2].Visible = false;
                    }
                }
                catch { CommonLib.JavaScriptHelper.AlertAndRedirect("参数错误！", "sh_list.aspx?cls=1", Page); }
            
            Bind();
        }
    }

    #region 绑定
    private void Bind()
    {
        string count = "";
        string sql = "";
        if (Request.QueryString["cls"] != null)
        {
            count = "select count(*) from product where pro_type=3";
        }
        else
        {
            count = "select count(*) from product";
        }
        if (Request.QueryString["cls"] != null)
        {
            sql = "select * from product where pro_type=3  order by pro_id desc";
        }
        else
        {
            sql = "select * from product order by pro_id desc";
        }
        AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
       
        CommonLib.SqlHelper.BindGridView(GridView1, sql, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1);
        
    }
    #endregion

    #region 分页
    //分页
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    #endregion

    #region 删除
    //删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        string sql = "";
      

        sql = "update product set states='已审核' where pro_id=" + id.ToString();
        try
        {

            int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
            if (i > 0)
            {
                Bind();
                
                CommonLib.JavaScriptHelper.Alert("审核成功！", this.Page);
            }
            else
            {
                CommonLib.JavaScriptHelper.Alert("服务器繁忙！", this.Page);
            }
        }
        catch
        {
            CommonLib.JavaScriptHelper.Alert("服务器繁忙，删除失败！", this.Page);
        }
    }
    #endregion



    #region 获取会员名称
    protected string getmname(string id)
    {
        string sql = "select m_name from member where m_id=" + id;
        string name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        return name;
    }
    #endregion

    #region 获取分类名称
    protected string getclsname(string id)
    {
        string sql = "";
        if (id == "1")
        {
            sql = "出租房源";
        }
        if (id == "2")
        {
            sql = "出售房源";
        }
        if (id == "3")
        {
            sql = "站内新闻";
        }
        if (id == "4")
        {
            sql = "求租房源";
        }
        if (id == "5")
        {
            sql = "求售房源";
        }
        return sql;
        //string sql = "select pro_cls_name from pro_cls where pro_cls_id=" + id;
        //string name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //sql = "select pro_cls_name from pro_cls where pro_cls_id in (select pro_cls_pid from pro_cls where pro_cls_id=" + id + ")";
        //string name2 = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //return name2 + " >> " + name;
    }
    #endregion
}
