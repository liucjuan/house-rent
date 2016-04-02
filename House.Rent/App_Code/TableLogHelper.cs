using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

/// <summary>
/// TableLogHelper 的摘要说明
/// </summary>
public class TableLogHelper
{
    #region 获取用户日志
    public static DataSet GetUserLog(string userName,int pageSize,int pageIndex)
    {
        StringBuilder sql = new StringBuilder();
        int sum = pageIndex > 0 ? (pageIndex) * pageSize : 0;
        sql.AppendFormat("select top {0} * from {1} where m_id in ( select m_id from {2} where m_name='{3}') and l_id not in (select top {4} l_id from {1} order by l_id desc) order by l_id desc", pageSize, DBConfig.log, DBConfig.member, userName, sum);
        DataSet ds = DBHelper.GetDataSet(sql.ToString());
        if (ds != null)
        {
            return ds;
        }
        else
        {
            return null;
        }
    }
    #endregion

    #region 获取记录总数
    public static  int GetLogCount(string userName)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select count(*) from {0} where m_id in (select m_id from {1} where m_name='{2}')",DBConfig.log,DBConfig.member,userName);
        int count = DBHelper.GetScalar(sql.ToString());
        return count;
    }
    #endregion

}