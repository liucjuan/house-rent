using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;

/// <summary>
/// TableProductHelper 的摘要说明
/// </summary>
public class TableProductHelper
{
    #region 获取产品信息
    public DataSet GetProductInfo(string pro_id)
    {
        if (!string.IsNullOrEmpty(pro_id))
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select * from {0} where pro_id={1}", DBConfig.product, pro_id);
            DataSet dataSet = DBHelper.GetDataSet(sql.ToString());
            if (dataSet != null)
            {
                return dataSet;
            }
        }
        return new DataSet();
    }
    #endregion

    #region 获取产品信息中的某些字段
    public Dictionary<string,string> GetProductFields(List<string> fields, string pro_id,int type)
    {
        Dictionary<string,string> valueDic = new Dictionary<string,string>();
        DataSet dataSet = GetProductInfo(pro_id);
        if (dataSet != null)
        {
            if (fields != null && fields.Count > 0 && type==0)
            {
                foreach (string field in fields)
                {
                    string value = dataSet.Tables[0].Rows[0][field].ToString();
                    valueDic.Add(field, value);
                }
            }
            if (type == 1)
            {
                foreach (string field in dataSet.Tables[0].Columns)
                {
                    string value = dataSet.Tables[0].Rows[0][field].ToString();
                    valueDic.Add(field,value);
                }
            }
        }
        return valueDic;
    }
    #endregion

        //  string name = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
        //string sql = "select m_id from member where m_name='" + name + "'";
        //string con = CommonLib.SqlHelper.SqlConnectionString;
        //string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        //string where = " where pro_type=1 and m_id=" + mid;
        //string count = "select count(*) from product" + where;
        //AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
        //sql = "select * from product" + where + " order by pro_id desc";
        //CommonLib.SqlHelper.BindRepeater(rep_list, sql, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1);

    #region 获取记录总数
    public static int GetCount(string name)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select count(*) from product where pro_type=1 and m_id in (select m_id from member where m_name='{0}')",name);
        int count = DBHelper.GetScalar(sql.ToString());
        return count;
    }
    #endregion

    #region 获取商品信息
    public static DataSet GetProductInfo(string userName, int pageSize, int pageIndex)
    {
        int sum = pageIndex > 0 ? (pageIndex) * pageSize : 0;
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select top {0} * from {1} where pro_type=1 and m_id in(select m_id from {2} where m_name='{3}') and pro_id not in(select top {4} pro_id from {1})",pageSize,DBConfig.product,DBConfig.member,userName,sum);
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
}