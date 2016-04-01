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
    public DataSet GetUserLog(string userName,int pageSize,int pageIndex)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select top {0} * from {1} where m_id2 in ( select m_id from {2} where m_name='{3}') and l_id not in (select top {0}*({4}-1) id from {1} order by l_id desc) order by l_id desc", pageSize,DBConfig.log, DBConfig.member, userName,pageIndex);
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
    public int GetLogCount(string userName)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select count(*) from {0} where m_id2 in (select m_id from {1} where m_name='{2}')",DBConfig.log,DBConfig.member,userName);
        int count = DBHelper.GetScalar(sql.ToString());
        return count;
    }
    #endregion

}