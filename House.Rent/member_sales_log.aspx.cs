using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Model;

public partial class member_sales_log : System.Web.UI.Page
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
        #region 暂时不用
        //string sql = "select m_id from member where m_name='" + name + "'";
        //string con = CommonLib.SqlHelper.SqlConnectionString;
        //string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //string where = " where m_id2=" + mid;
        //string count = "select count(*) from log" + where;
        //AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
        //sql = "select * from log" + where + " order by l_id desc";
        //CommonLib.SqlHelper.BindRepeater(rep_list, sql, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1); 
        #endregion

        string name = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
        if (!string.IsNullOrEmpty(name))
        {
            AspNetPager1.RecordCount = TableLogHelper.GetLogCount(name);
            DataSet ds = TableLogHelper.GetUserLog(name, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1);
            DBHelper.BindRepeater(rep_list, ds);
        }
    }
    #endregion

    #region 分页
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    #endregion

    #region 获取分类

    protected string getclsname(string id)
    {
        #region 暂时不用

        //string con = CommonLib.SqlHelper.SqlConnectionString;
        //string sql = "select pro_cls_id from product where pro_id=" + id;
        //id = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //if (id != "0")
        //{
        //    sql = "select pro_cls_name from pro_cls where pro_cls_id=" + id;
        //    string name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //    sql = "select pro_cls_name from pro_cls where pro_cls_id in "
        //        + "(select pro_cls_pid from pro_cls where pro_cls_id=" + id + ")";
        //    string name2 = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //    return name2 + " >> " + name;
        //}
        //else
        //{
        //    return "<span style=\"color:#ff0000\">物品已删除</span>";
        //} 

        #endregion

        List<string> fieldList = new List<string>();
        Dictionary<string, string> whereDic = new Dictionary<string, string>();
        fieldList.Add("pro_cls_id");
        whereDic.Add("pro_id", id);
        Object value = DBHelper.SelectDataObject(fieldList, whereDic, DBConfig.product);
        if (value != null)
        {
            {
                id = value.ToString();
                if (id != "0")
                {
                    fieldList.Clear();
                    whereDic.Clear();
                    fieldList.Add("pro_cls_name");
                    whereDic.Add("pro_cls_id", id);
                    Object val = DBHelper.SelectDataObject(fieldList, whereDic, DBConfig.pro_cls);
                    string name = string.Empty;
                    if (val != null)
                    {
                        name = val.ToString();
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        return name + " >> " + name;
                    }
                }
            }
        }
        return "<span style=\"color:#ff0000\">物品已删除</span>";
    }

    #endregion

    #region 获取产品信息
    protected string getpro(string id, string zi)
    {
        #region 暂时不用
        //string sql = "select " + zi + " from product where pro_id=" + id;
        //string con = CommonLib.SqlHelper.SqlConnectionString;
       // string name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //if (zi != "pro_img")
        //    name = name == "0" ? "<span style=\"color:#ff0000\">物品不存在或已删除</span>" : name;
        //return name;
        #endregion

        List<string> fieldList = new List<string>();
        Dictionary<string, string> whereDic = new Dictionary<string, string>();
        fieldList.Add(zi);
        whereDic.Add("pro_id", id);
        Object value = DBHelper.SelectDataObject(fieldList, whereDic, DBConfig.product);
        string name = string.Empty;
        if (value != null)
        {
            name = value.ToString();
            if (zi != "pro_img")
            {
                name = name == "0" ? "<span style=\"color:#ff0000\">物品不存在或已删除</span>" : name;
            }
        }

        return name;
    }
    #endregion
}
