using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CommonLib
{
    /// <summary>
    /// The SqlHelper class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SqlClient.
    /// </summary>
    public abstract class SqlHelper
    {

        //Database connection strings方便配置时更改链接字符串
        public static readonly string SqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBLink"].ConnectionString;

        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        #region ExecuteNonQuery
        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();
            //using自动打开，自动关闭
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) using an existing SQL Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing sql transaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// return a dataset
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns>return a dataset</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                da.SelectCommand = cmd;
                da.Fill(ds);

                return ds;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                if (val != null)
                    return val;
                else
                    return 0;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if (val != null)
                return val;
            else
                return 0;
        }
        #endregion

        #region CacheParameters
        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }
        #endregion

        #region GetCachedParameters
        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        #endregion

        #region PrepareCommand
        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion

        #region BindDropDownList
        /// <summary>
        /// 绑定DropDownList
        /// </summary>
        /// <param name="myDropList"></param>
        /// <param name="strTextField"></param>
        /// <param name="strValueField"></param>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        public static void BindDropDownList(DropDownList myDropList, string strTextField, string strValueField, string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataReader dr = ExecuteReader(connectionString, cmdType, cmdText, commandParameters);
            myDropList.DataSource = dr;
            myDropList.DataTextField = strTextField;
            myDropList.DataValueField = strValueField;
            myDropList.DataBind();
            dr.Close(); dr.Dispose();
        }
        #endregion

        #region BindGridView
        public static void BindGridView(GridView myGridView, string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataReader dr = ExecuteReader(connectionString,cmdType,cmdText,commandParameters);

            myGridView.DataSource = dr;
            myGridView.DataBind();
            dr.Close(); dr.Dispose();
        }
        public static void BindGridView(GridView myGridView, string str, int pagesize, int pageindex)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            if (con.State != ConnectionState.Open)
                con.Open();
            try
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = str;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, pagesize * pageindex, pagesize, "#table");
                DataView dv = ds.Tables[0].DefaultView;

                myGridView.DataSource = dv;
                myGridView.DataBind();

                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {
                con.Close(); con.Dispose();
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetDropDownListValue
        /// <summary>
        /// 根据strValue内的值在DropDownList内查找相同的值
        /// </summary>
        /// <param name="DropDL">DropDownList对象</param>
        /// <param name="strValue">查找的值</param>
        public static void GetDropDownListValue(DropDownList myDropDownList, string strValue)
        {
            myDropDownList.SelectedIndex = 0;

            for (int i = 0; i < myDropDownList.Items.Count; i++)
            {
                if (myDropDownList.Items[i].Value == strValue)
                {
                    myDropDownList.SelectedIndex = i;
                    return;
                }
            }
        }
        #endregion

        #region 绑定HtmlSelect控件
        /// <summary>
        /// 绑定HtmlSelect控件
        /// </summary>
        /// <param name="myHtmlSelect"></param>
        /// <param name="strTextField"></param>
        /// <param name="strValueField"></param>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        public static void BindHtmlSelect(HtmlSelect myHtmlSelect, string strTextField, string strValueField, string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataReader dr = ExecuteReader(connectionString, cmdType, cmdText, commandParameters);
            myHtmlSelect.DataSource = dr;
            myHtmlSelect.DataTextField = strTextField;
            myHtmlSelect.DataValueField = strValueField;
            myHtmlSelect.DataBind();
            dr.Close(); dr.Dispose();
        }
        #endregion

        #region 绑定CheckBoxList
        /// <summary>
        /// 绑定CheckBoxList
        /// </summary>
        /// <param name="myCheckBoxList"></param>
        /// <param name="strTextField"></param>
        /// <param name="strValueField"></param>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        public static void BindCheckBoxList(CheckBoxList myCheckBoxList, string strTextField, string strValueField, string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataReader dr = ExecuteReader(connectionString, cmdType, cmdText, commandParameters);
            myCheckBoxList.DataSource = dr;
            myCheckBoxList.DataTextField = strTextField;
            myCheckBoxList.DataValueField = strValueField;
            myCheckBoxList.DataBind();
            dr.Close(); dr.Dispose();
        }
        #endregion

        #region BindDataList
        public static void BindDataList(DataList myDataList, string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataReader dr = ExecuteReader(connectionString, cmdType, cmdText, commandParameters);
            myDataList.DataSource = dr;
            myDataList.DataBind();
            dr.Close(); dr.Dispose();
        }
        #endregion

        #region BindRepeater
        public static void BindRepeater(Repeater myRepeater, string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataReader dr = ExecuteReader(connectionString, cmdType, cmdText, commandParameters);
            myRepeater.DataSource = dr;
            myRepeater.DataBind();
            dr.Close(); dr.Dispose();
        }
        public static void BindRepeater(Repeater myRepeater, string str, int pagesize, int pageindex)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            if (con.State != ConnectionState.Open)
                con.Open();
            try
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = str;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, pagesize * pageindex, pagesize, "#table");
                DataView dv = ds.Tables[0].DefaultView;

                myRepeater.DataSource = dv;
                myRepeater.DataBind();

                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {
                con.Close(); con.Dispose();
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 判断用户是否登录
        public static void islogin(System.Web.UI.Page mypage)
        {
            string name = "";
            try
            {
                name = System.Web.HttpContext.Current.Request.Cookies["T-TXB"]["Manager"].ToString();
            }
            catch { }
            if (name == "")
            {
                HtmlGenericControl scriptControl = new HtmlGenericControl("script");
                scriptControl.Attributes.Add("type", "text/javascript");
                scriptControl.InnerHtml = "window.onload=function(){parent.location.href='managerthisway.aspx';}";
                mypage.Header.Controls.Add(scriptControl);
            }
        }
        #endregion
    }
}
