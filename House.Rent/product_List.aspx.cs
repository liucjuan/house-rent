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

public partial class product_List : System.Web.UI.Page
{
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonLib.SqlHelper.islogin(Page);
           
               
            
            Bind();
        }
    }

    #region 绑定
    private void Bind()
    {
        string count = "";
        string sql = "";
        count = "select count(*) from product where pro_type='" + DropDownList1.SelectedValue.ToString() + "'";
        sql = "select * from product where pro_type='" + DropDownList1.SelectedValue.ToString() + "' order by pro_id desc";
        
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string count = "";
        string sql = "";
        count = "select count(*) from product where pro_type='"+DropDownList1.SelectedValue.ToString()+"'";
        sql = "select * from product where pro_type='" + DropDownList1.SelectedValue.ToString() + "' order by pro_id desc";

        AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));

        CommonLib.SqlHelper.BindGridView(GridView1, sql, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1);
    }

    #region 删除
    protected void rep_list_ItemCommand(object source, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string sql = "select pro_img from product where pro_id=" + e.CommandArgument;
            string path = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
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
}
