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

public partial class supply : System.Web.UI.Page
{
    #region 初始化
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //#region 判断参数
            //if (Request["cls"] != null)
            //{
            //    try
            //    {
            //        int cls = Convert.ToInt32(Request.QueryString["cls"]);
            //        //if (cls < 1 || cls > 3)
            //        //{
            //        //    Response.Redirect("supply.aspx?cls=1");
            //        //    return;
            //        //}
            //        #region 绑定左侧导航
            //        //Bind(cls);
            //        #endregion
            //    }
            //    catch
            //    {
            //        Response.Redirect("supply.aspx?cls=1");
            //    }
            //}
            //else if (Request["t"] != null)
            //{
            //    try
            //    {
            //        int t = Convert.ToInt32(Request.QueryString["t"]);
            //        string sql = "select pro_cls_pid from pro_cls where pro_cls_id=" + t;
            //        int cls = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null));
            //        //Bind(cls);
            //        sql = "select pro_cls_name from pro_cls where pro_cls_id=" + t;
            //        string name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
            //        //HyperLink1.Text += "&nbsp;&gt;&nbsp;";
            //        //HyperLink2.Text = name;
            //        //HyperLink2.NavigateUrl = "supply.aspx?t=" + t;
            //    }
            //    catch
            //    {
            //        Response.Redirect("supply.aspx");
            //    }
            //}
            //else
            //{
            //    //Bind(0);
            //}
            //#endregion
            Bind();
        }
    }
    #endregion

    #region 绑定列表
    private void Bind()
    {
        string where = "";
        if (Request["cls"] != null)
        {
            where += " where pro_type=" + Request.QueryString["cls"] + "";
        }
        //else if (Request["t"] != null)
        //{
        //    where += " and pro_cls_id=" + Request.QueryString["t"];
        //}
        //else if (Request["key"] != null)
        //{
        //    string key = Server.UrlDecode(Request.QueryString["key"]);
        //    where += " and (pro_title like '%" + key + "%' or pro_name like '%" + key + "%')";
        //    //HyperLink1.Text = "检索结果";
        //    //Response.Write(where);
        //}
        string count = "select count(*) from product" + where;
        AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
        string sql = "select * from product" + where + " order by pro_id desc";
        CommonLib.SqlHelper.BindRepeater(rep_list, sql, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1);
    }
    #endregion

    #region 分页
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    #endregion

    #region 获取分类下商品条数
    protected string getcount(string id)
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
    }
    #endregion

    //#region 绑定左侧导航
    //private void Bind(int cls)
    //{
    //    //if (cls > 0 && cls < 4)
    //    //{
    //      //string sql = "select pro_cls_name from pro_cls where pro_cls_id=" + cls;
    //      //  string name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
    //      //  hy_cls.Text = name;
    //      //  HyperLink1.NavigateUrl = "supply.aspx?cls=" + cls;
    //      //  HyperLink1.Text = name;
    //      //  hy_cls.NavigateUrl = "supply.aspx?cls=" + cls;
    //      //  sql = "select * from pro_cls where pro_cls_pid=" + cls + " order by pro_cls_id desc";
    //      //  CommonLib.SqlHelper.BindRepeater(rep_cls, con, CommandType.Text, sql, null);
    //    //}
    //    //else if (cls == 0)
    //    //{
    //    //    hy_cls.Text = "全部";
    //    //    hy_cls.NavigateUrl = "supply.aspx";
    //    //    HyperLink1.NavigateUrl = "supply.aspx";
    //    //    HyperLink1.Text = "全部";
    //    //    string sql = "select * from pro_cls where pro_cls_pid=0";
    //    //    CommonLib.SqlHelper.BindRepeater(rep_cls, con, CommandType.Text, sql, null);
    //    //}
    //}
    //#endregion
}
