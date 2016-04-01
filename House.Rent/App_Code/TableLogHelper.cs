using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

/// <summary>
/// TableLogHelper 的摘要说明
/// </summary>
public class TableLogHelper
{
    #region 获取用户日志
    public DataSet GetUserLog(string UserId)
    {
        //string sql = "select m_id from member where m_name='" + name + "'";
        //string con = CommonLib.SqlHelper.SqlConnectionString;
        //string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //string where = " where m_id2=" + mid;
        //string count = "select count(*) from log" + where;
        //AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
        //sql = "select * from log" + where + " order by l_id desc";


        return null;
    }
    #endregion
}