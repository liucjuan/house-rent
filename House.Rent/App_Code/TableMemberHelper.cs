using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Web;

/// <summary>
/// TableMemberHelper 的摘要说明
/// </summary>
public class TableMemberHelper
{
	public TableMemberHelper()
	{
	}

    #region 验证用户登录
    /// <summary>
    /// 验证用户登录
    /// </summary>
    /// <param name="user"></param>
    /// <param name="passWord"></param>
    /// <returns></returns>
    public ErrorType VerifyLogin(string user, string passWord)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select top 1 m_pwd from {0} where m_name={1}", DBConfig.member, user);
        SqlDataReader reader =DBHelper.GetReader(sql.ToString());
        if (reader.Read())
        {
            if (!reader.IsDBNull(0))
            {
                string pass = reader.GetString(0);
                if (pass != null && passWord != null && passWord == pass)
                {
                    return ErrorType.Success;
                }
                else
                {
                    return ErrorType.BadPassWord;
                }
            }
            else
            {
                return ErrorType.BadPassWord;
            }
        }
        else
        {
            return ErrorType.BadUser;
        }

    } 
    #endregion

    #region 修改密码
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="passWord"></param>
    /// <returns></returns>
    public ErrorType UpdatePassWord(string userName, string passWord)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("update {0} set m_pwd='{1}' where m_name='{2}'", DBConfig.member, passWord, userName);
        int count = DBHelper.ExecuteCommand(sql.ToString());
        if (count == 1)
        {
            return ErrorType.Success;
        }
        return ErrorType.Failed;
    } 
    #endregion

    #region 获取用户
    /// <summary>
    /// 获取用户
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public SqlDataReader GetUserInfo(string userName)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select top 1 from {0} where m_name={1}", DBConfig.member, userName);
        SqlDataReader reader = DBHelper.GetReader(sql.ToString());
        return reader;
    }
    #endregion

    #region 判断当前用户是否存在
    /// <summary>
    /// 判断当前用户是否存在
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public ErrorType IsUserExist(string userName)
    {
        SqlDataReader reader = GetUserInfo(userName);
        if (reader.Read())
        {
            if (!reader.IsDBNull(0))
            {
                return ErrorType.Success;
            }
        }
        return ErrorType.Failed;
    }
    #endregion
}