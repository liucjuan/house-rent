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

    #region 获取产品信息中的某个字段
    public string GetProductFields(string fields, string pro_id)
    {
        string value = string.Empty;
        DataSet dataSet = GetProductInfo(pro_id);
        if (dataSet != null)
        {
            value = dataSet.Tables[0].Rows[0][fields].ToString();
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
        }
        return string.Empty;
    }
    #endregion
}