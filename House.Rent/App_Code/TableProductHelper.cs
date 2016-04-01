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
}