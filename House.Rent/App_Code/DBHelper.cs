using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// DBHelper 的摘要说明
/// </summary>
public class DBHelper
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public static string connectStr = CommonLib.SqlHelper.SqlConnectionString;

    #region 获取数据库连接
    private static SqlConnection connection;
    public static SqlConnection Connection
    {
        get
        {
            string connectionString = connectStr;
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            else if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            else if (connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }
            return connection;
        }
    } 
    #endregion

    #region 执行无参SQL语句
    /// <summary> 
    /// 执行无参SQL语句 
    /// </summary> 
    public static int ExecuteCommand(string safeSql)
    {
        SqlCommand cmd = new SqlCommand(safeSql, Connection);
        int result = cmd.ExecuteNonQuery();
        return result;
    }
    
    #endregion
    #region 执行带参SQL语句 
    /// <summary> 
    /// 执行带参SQL语句 
    /// </summary> 
    public static int ExecuteCommand(string sql, params SqlParameter[] values)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.AddRange(values);
        return cmd.ExecuteNonQuery();
    } 
    #endregion

    #region 执行无参SQL语句，并返回执行记录数 
    /// <summary> 
    /// 执行无参SQL语句，并返回执行记录数 
    /// </summary> 
    public static int GetScalar(string safeSql)
    {
        SqlCommand cmd = new SqlCommand(safeSql, Connection);
        int result = Convert.ToInt32(cmd.ExecuteScalar());
        return result;
    } 
    #endregion

    #region 执行有参SQL语句，并返回执行记录数 
    /// <summary> 
    /// 执行有参SQL语句，并返回执行记录数 
    /// </summary> 
    public static int GetScalar(string sql, params SqlParameter[] values)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.AddRange(values);
        int result = Convert.ToInt32(cmd.ExecuteScalar());
        return result;
    } 
    #endregion

    #region  执行无参SQL语句，并返回SqlDataReader 
    /// <summary> 
    /// 执行无参SQL语句，并返回SqlDataReader 
    /// </summary> 
    public static SqlDataReader GetReader(string safeSql)
    {
        SqlCommand cmd = new SqlCommand(safeSql, Connection);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }
    
    #endregion
    #region 执行有参SQL语句，并返回SqlDataReader 
    /// <summary> 
    /// 执行有参SQL语句，并返回SqlDataReader 
    /// </summary> 
    public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.AddRange(values);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }   
    #endregion 

    #region 获取数据集
    public static DataSet GetDataSet(string sql)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sqld = new SqlDataAdapter(sql, Connection);
        sqld.Fill(ds, "user");
        DataTable dTable = ds.Tables["user"];
        DataRowCollection rows = dTable.Rows;
        if (rows.Count > 0)
        {
            return ds;
        }
        return null;
    }
    #endregion
}