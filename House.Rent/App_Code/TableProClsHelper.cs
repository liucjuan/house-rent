using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;

/// <summary>
/// TableProClsHelper 的摘要说明
/// </summary>
public class TableProClsHelper
{
    public DataSet GetPro_ClsInfo(string pro_cls_id)
    {
        if (!string.IsNullOrEmpty(pro_cls_id))
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select * from pro_cls where pro_cls_id=", DBConfig.pro_cls, pro_cls_id);
            DataSet dataSet = DBHelper.GetDataSet(sql.ToString());
            if (dataSet != null)
            {
                return dataSet;
            }
        }
        return new DataSet();
    }

    public Dictionary<string,string> GetPro_ClsFields(List<String> fields, string pro_cls_id)
    {
        Dictionary<string, string> valueDic = new Dictionary<string,string>();
        DataSet dataSet = GetPro_ClsInfo(pro_cls_id);
        if (dataSet != null)
        {
            if (fields != null && fields.Count > 0)
            {
                foreach (string item in fields)
                {
                    string value = dataSet.Tables[0].Rows[0][item].ToString();
                    valueDic.Add(item,value);
                }
            }
        }
        return valueDic;
    }
}