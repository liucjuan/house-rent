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

public partial class supply_display : System.Web.UI.Page
{
    #region 初始化
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null)
            {
                //try
                //{
                #region 暂时不用
                //int id = Convert.ToInt32(Request.QueryString["id"]);
                //string sql = "select count(*) from product where pro_id=" + id;
                //int count = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(CommonLib.SqlHelper.SqlConnectionString, CommandType.Text, sql, null));
                // public static int SelectDataCount(List<string> fieldList, Dictionary<string, string> whereDic, string tableName) 
                #endregion

                     List<string> fieldList=new List<string>();
                     Dictionary<string, string> whereDic=new Dictionary<string, string>();
                     if (Request.QueryString["id"] != null)
                     {
                         whereDic.Add("pro_id", Request.QueryString["id"]);
                     }
                     int count = DBHelper.SelectDataCount(fieldList, whereDic, DBConfig.product);
                if (count > 0)
                {
                    Bind();
                }

                //}
                //catch
                //{
                //    Response.Redirect("404error.htm?error=" + Request.RawUrl.Split('?')[0]);
                //}
            }
        }
    }
    #endregion

    #region 绑定页面
    private void Bind()
    {
        string con = CommonLib.SqlHelper.SqlConnectionString;
        //#region 绑定左侧
        //string sql = "select pro_title from product where pro_id=" + Request.QueryString["id"];
        //string name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //Label1.Text = CommonLib.CutString.CutWithSubstring(name, 5);
        //Label1.ToolTip = name;
        //sql = "select pro_cls_id from product where pro_id=" + Request.QueryString["id"];
        //string clsid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //sql = "select pro_cls_name from pro_cls where pro_cls_id=" + clsid;
        //name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //HyperLink2.Text = name + "&nbsp;&gt;&nbsp;";
        //HyperLink2.NavigateUrl = "supply.aspx?t=" + clsid;
        //sql = "select pro_cls_pid from pro_cls where pro_cls_id=" + clsid;
        //clsid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //sql = "select pro_cls_name from pro_cls where pro_cls_id=" + clsid;
        //name = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //hy_cls.Text = name;
        //hy_cls.NavigateUrl = "supply.aspx?cls=" + clsid;
        //HyperLink1.Text = name + "&nbsp;&gt;&nbsp;";
        //HyperLink1.NavigateUrl = hy_cls.NavigateUrl;
        //sql = "select * from pro_cls where pro_cls_pid=" + clsid;
        //CommonLib.SqlHelper.BindRepeater(rep_cls, con, CommandType.Text, sql, null);
        //#endregion
        //#region 绑定内容

        #region 暂时不用
        //string sql = "select * from product where pro_id=" + Request.QueryString["id"];
        //CommonLib.SqlHelper.BindRepeater(rep_intro, con, CommandType.Text, sql, null); 
        #endregion

        List<string> fieldList = new List<string>();
        Dictionary<string, string> whereDic = new Dictionary<string, string>();
        if (Request.QueryString["id"] != null)
        {
            whereDic.Add("pro_id", Request.QueryString["id"]);
        }
        DataSet ds = DBHelper.SelectDataSet(fieldList, whereDic, DBConfig.product);
        DBHelper.BindRepeater(rep_intro, ds);
        #endregion
    }
  

    #region 获取分类下商品条数
    protected string getcount(string id)
    {
        string sql = "";
        if (id== "1")
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

    #region 当前行
    protected void rep_intro_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemIndex != -1)
        //{
        //    HiddenField hid = (HiddenField)e.Item.FindControl("HiddenField1");
        //    ImageButton img = (ImageButton)e.Item.FindControl("ImageButton1");
        //    if (hid.Value == "3")
        //    {
        //        img.Visible = false;
        //    }
            
        //}
    }
    #endregion

    #region 购买
    protected void rep_intro_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "mai")
        {
            if (Request.Cookies["buy"] == null)
            {
                CommonLib.JavaScriptHelper.AlertAndRedirect("您还没有登录！", "login.aspx", Page);
            }
            else
            {
                #region 会员编号
                string mname = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
                string con = CommonLib.SqlHelper.SqlConnectionString;
                string sql = "select m_id from member where m_name='" + mname + "'";
                string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
                #endregion
                sql = "select m_id from product where pro_id=" + e.CommandArgument;
                string mid2 = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
                if (mid == mid2)
                {
                    CommonLib.JavaScriptHelper.Alert("这是您自己的商品", Page);
                    return;
                }
                else
                {
                    sql = "select pro_num from product where pro_id=" + e.CommandArgument;
                    int count = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null));
                    if (count == 0)
                    {
                        CommonLib.JavaScriptHelper.Alert("该房屋已租完", Page);
                        return;
                    }
                    else
                    {
                        #region 产品信息
                        sql = "select * from product where pro_id=" + e.CommandArgument;
                        string pro_title = "";
                        string pro_name = "";
                        string pro_tel = "";
                        string pro_qq = "";
                        string pro_add = "";
                        SqlDataReader dr = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql, null);
                        try
                        {
                            if (dr.Read())
                            {
                                pro_title = dr["pro_title"].ToString();
                                pro_name = dr["pro_name"].ToString();
                                pro_tel = dr["pro_tel"].ToString();
                                pro_qq = dr["pro_qq"].ToString();
                                pro_add = dr["pro_add"].ToString();
                            }
                        }
                        catch { }
                        dr.Close(); dr.Dispose();
                        #endregion
                        #region 会员信息
                        sql = "select * from member where m_id=" + mid;
                        string m_tel = "";
                        string m_qq = "";
                        string m_add = "";
                        SqlDataReader dr2 = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql, null);
                        try
                        {
                            if (dr2.Read())
                            {
                                m_tel = dr2["m_tel"].ToString();
                                m_qq = dr2["m_qq"].ToString();
                                m_add = dr2["m_add"].ToString();
                            }
                        }
                        catch { }
                        dr2.Close(); dr2.Dispose();
                        #endregion
                        sql = "insert into log (m_id,pro_id,l_date,pro_title,pro_name,pro_tel,pro_qq,pro_add,m_tel,m_qq,m_add) values (" + mid
                            + "," + e.CommandArgument + ",'" + DateTime.Now.ToString() + "','" + pro_title + "','" + pro_name + "','" + pro_tel
                            + "','" + pro_qq + "','" + pro_add + "','" + m_tel + "','" + m_qq + "','" + m_add + "')";
                        try
                        {
                            CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                            sql = "update product set pro_num=pro_num-1 where pro_id=" + e.CommandArgument;
                            try
                            {
                                CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                            }
                            catch { }
                            Bind();
                            CommonLib.JavaScriptHelper.Alert("提交数据成功", Page);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                            CommonLib.JavaScriptHelper.Alert("提交数据失败", Page);
                        }
                    }
                }
            }
        }
    }
    #endregion
}
