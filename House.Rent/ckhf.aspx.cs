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
using System.Collections.Generic;

public partial class supply : System.Web.UI.Page
{


    #region 初始化
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            Bind();
        }
    }
    #endregion

    #region 绑定
    private void Bind()
    {
        string name = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
        string count = "select count(*) from ly where uid='"+name+"'";
        AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
       string  sql = "select * from ly  where uid='" + name + "'";
        CommonLib.SqlHelper.BindRepeater(rep_list, sql, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1);

        //SelectDataCount(List<string> fieldList, Dictionary<string, string> whereDic, string tableName)

        //Dictionary<string, string> whereDic = new Dictionary<string, string>();
        //List<string> fieldList = new List<string>();
        //whereDic.Add("uid", name);
        //AspNetPager1.RecordCount = DBHelper.SelectDataCount(fieldList, whereDic, DBConfig.liuyan);

        //DataSet ds = new DataSet();
        //ds = DBHelper.Pagination(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1, whereDic, "pro_id", DBConfig.liuyan);
        //DBHelper.BindRepeater(rep_list, ds);
        //whereDic.Clear();
    }
    #endregion

    #region 分页
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
    #endregion


   
}
