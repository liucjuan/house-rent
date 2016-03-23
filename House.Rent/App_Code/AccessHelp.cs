using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.Xml;


namespace CommonLib
{
    /// <summary>
    /// AccessHelper 的摘要说明
    /// Access数据库数据访问公共类
    /// </summary>
    public class AccessHelper
    {
        //数据库连接串
        public static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBLink"].ConnectionString;

        #region 数据库连接对象操作
        /// <summary> 
        /// 打开数据库连接 
        /// </summary> 
        private static OleDbConnection OpenConnection()
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(connectionString);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 关闭数据库连接释放资源
        /// </summary>
        /// <param name="Conn">数据库连接对象</param>
        public static void DisposeConnection(OleDbConnection Conn)
        {
            if (Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        #endregion

        #region SQL操作语句

        /// <summary>
        /// 执行Sql查询语句 
        /// </summary>
        /// <param name="strSQL">传入的Sql语句</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteSql(string strSQL)
        {
            OleDbConnection conn = OpenConnection();
            try
            {
                OleDbCommand comm = new OleDbCommand(strSQL, conn);
                int val = comm.ExecuteNonQuery();

                DisposeConnection(conn);
                return val;

            }
            catch (Exception e)
            {
                DisposeConnection(conn);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 执行Sql查询语句,同时进行事务处理
        /// </summary>
        /// <param name="strSQL">传入的Sql语句</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteSqlWithTransaction(string strSQL)
        {
            OleDbTransaction trans;
            OleDbConnection conn = OpenConnection();
            OleDbCommand comm = new OleDbCommand(strSQL, conn);

            trans = conn.BeginTransaction();
            comm.Transaction = trans;

            try
            {
                int val = comm.ExecuteNonQuery();
                trans.Commit();

                DisposeConnection(conn);
                trans.Dispose();
                return val;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                DisposeConnection(conn);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 执行带参数sql语句
        /// </summary>
        /// <param name="strSql">存储过程名</param>
        /// <param name="parameters">参数集合</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteSqlWithParms(string strSql, OleDbParameter[] parameters)
        {
            OleDbConnection conn = OpenConnection();
            try
            {
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;

                for (int i = 0; i < parameters.Length; i++)
                {
                    comm.Parameters.Add(parameters[i]);
                }
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSql;
                int val = comm.ExecuteNonQuery();

                DisposeConnection(conn);
                return val;

            }
            catch (Exception e)
            {
                DisposeConnection(conn);
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region 数据查询

        /// <summary>
        /// 执行Sql查询语句并返回第一行的第一条记录,返回值为object 使用时需要拆箱操作 -> Unbox 
        /// 例如string userName = (string)ExecuteScalar("select userName from users");
        /// </summary>
        /// <param name="strSQL">传入的Sql语句</param>
        /// <returns>object 返回值</returns>
        public static object ExecuteScalar(string strSQL)
        {
            object obj = new object();
            OleDbConnection conn = OpenConnection();
            try
            {
                OleDbCommand comm = new OleDbCommand(strSQL, conn);
                obj = comm.ExecuteScalar();

                DisposeConnection(conn);
                if (obj != null)
                    return obj;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                DisposeConnection(conn);
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 执行SQL语句返回第一行第一列的值
        /// </summary>
        /// <param name="strSQL">传入的SQL语句</param>
        /// <returns></returns>
        public static string getValue(string strSQL)
        {
            string strReturn = "";
            OleDbDataReader dr = null;
            OleDbConnection conn = OpenConnection();
            OleDbCommand comm = new OleDbCommand(strSQL, conn);
            try
            {
                dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    if (dr[0].ToString().Length > 0)
                        strReturn = dr[0].ToString();
                }
                return strReturn;

            }
            catch (Exception ex)
            {
                if (dr != null && !dr.IsClosed)
                    dr.Close();
                DisposeConnection(conn);
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 返回指定Sql语句的OleDbDataReader，请注意，在使用后请关闭本对象，同时将自动调用closeConnection()来关闭数据库连接 
        /// </summary>
        /// <param name="strSQL">传入的Sql语句</param>
        /// <returns>OleDbDataReader对象</returns>
        public static OleDbDataReader getDataReader(string strSQL)
        {
            OleDbDataReader dr = null;
            OleDbConnection conn = OpenConnection();
            try
            {

                OleDbCommand comm = new OleDbCommand(strSQL, conn);
                dr = comm.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch (Exception ex)
            {
                if (dr != null && !dr.IsClosed)
                    dr.Close();
                DisposeConnection(conn);
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// 返回指定Sql语句的DataTable
        /// </summary>
        /// <param name="strSQL">传入的Sql语句</param>
        /// <returns>DataTable</returns>
        public static DataTable getDataTable(string strSQL)
        {
            OleDbConnection conn = OpenConnection();
            try
            {
                OleDbCommand comm = new OleDbCommand(strSQL, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(comm);
                DataTable table = new DataTable();
                da.Fill(table);

                DisposeConnection(conn);
                return table;
            }
            catch (Exception ex)
            {
                DisposeConnection(conn);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 执行带参数sql语句并返回数据表
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="parameters">SqlParameterCollection 输入参数</param>
        /// <returns>dataTable</returns>
        public static DataTable getDataTable(string strSql, OleDbParameter[] parameters)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable datatable = new DataTable();
            OleDbConnection conn = OpenConnection();
            try
            {
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.Parameters.Clear();
                comm.CommandType = CommandType.Text;
                comm.CommandText = strSql;

                for (int i = 0; i < parameters.Length; i++)
                {
                    comm.Parameters.Add(parameters[i]);
                }

                da.SelectCommand = comm;
                da.Fill(datatable);

                DisposeConnection(conn);
                return datatable;
            }
            catch (Exception e)
            {
                DisposeConnection(conn);
                throw new Exception(e.Message);
            }
        }


        /// <summary> 
        /// 返回指定Sql语句的DataSet 
        /// </summary> 
        /// <param name="strSQL">传入的Sql语句</param> 
        /// <returns>DataSet</returns> 
        public static DataSet getDataSet(string strSQL)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbConnection conn = OpenConnection();
            try
            {
                OleDbCommand comm = new OleDbCommand(strSQL, conn);
                comm.CommandType = CommandType.Text;
                da.SelectCommand = comm;
                da.Fill(ds);

                DisposeConnection(conn);
                return ds;
            }
            catch (Exception e)
            {
                DisposeConnection(conn);
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// 是否存在值
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static bool isExists(string strSQL)
        {
            OleDbConnection conn = OpenConnection();
            try
            {
                OleDbCommand comm = new OleDbCommand(strSQL, conn);
                OleDbDataReader dr = comm.ExecuteReader();

                if (dr.HasRows) return true;

                DisposeConnection(conn);
                return false;
            }
            catch (Exception ex)
            {
                DisposeConnection(conn);
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// 获得该键值在指定表是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">值</param>
        /// <returns>>是/否</returns>
        public static bool getExistValue(string tableName, string fieldName, object value)
        {
            string Execstr = "select count(*) from {0} where {1}={2}";

            //目标值
            string destobject = null;
            if (value is string)
            {
                destobject = "'" + value.ToString() + "'";
            }
            else if (value is int)
            {
                destobject = value.ToString();
            }
            else if (value is DateTime)
            {
                destobject = "cast(" + value.ToString() + " as smalldatetime)";
            }
            else
                throw new ArgumentException("该类型值未被支持！");
            //格式化字符串
            Execstr = string.Format(Execstr, tableName, fieldName, destobject);

            object obj = ExecuteScalar(Execstr);

            //返回结果
            return ((int)obj) > 0 ? true : false;
        }
        #endregion

        #region 获取记录总数
        /// <summary>
        /// 获取查询记录总数
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static int getRowCount(string strSql)
        {
            int intRowCount = 0;

            string str = "select count(*) from (" + strSql + ") a";
            intRowCount = (int)ExecuteScalar(str);

            return intRowCount;
        }
        #endregion

        #region 绑定数据控件
        /// <summary>
        /// 绑定DripDownList
        /// </summary>
        /// <param name="myddl"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        /// <param name="str"></param>
        public static void bindDripDownList(System.Web.UI.WebControls.DropDownList myddl, string strText, string strValue, string str)
        {
            OleDbConnection con = OpenConnection();
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = str;
                da.SelectCommand = cmd;
                da.Fill(ds);

                myddl.DataSource = ds.Tables[0].DefaultView;
                myddl.DataTextField = strText;
                myddl.DataValueField = strValue;
                myddl.DataBind();

                DisposeConnection(con);
            }
            catch (Exception ex)
            {
                DisposeConnection(con);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 绑定GridView
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="str"></param>
        public static void bindGV(System.Web.UI.WebControls.GridView gv, string str)
        {
            OleDbConnection con = OpenConnection();
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = str;
                da.SelectCommand = cmd;
                da.Fill(ds);

                gv.DataSource = ds.Tables[0].DefaultView;
                gv.DataBind();

                DisposeConnection(con);
            }
            catch (Exception ex)
            {
                DisposeConnection(con);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 绑定GridView，带分页(ASPNetPage分页)
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="str"></param>
        /// <param name="pagesize">总页数</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="table">表明</param>
        public static void bindGV_page(System.Web.UI.WebControls.GridView gv, string str, int pagesize, int pageindex)
        {
            OleDbConnection con = OpenConnection();
            try
            {
                DataSet ds = new DataSet();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = str;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds, pagesize * pageindex, pagesize, "#table");
                DataView dv = ds.Tables[0].DefaultView;

                gv.DataSource = dv;
                gv.DataBind();

                DisposeConnection(con);
            }
            catch (Exception ex)
            {
                DisposeConnection(con);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 绑定Repeater
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="str"></param>
        public static void bindRep(System.Web.UI.WebControls.Repeater rep, string str)
        {
            OleDbConnection con = OpenConnection();
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = str;
                da.SelectCommand = cmd;
                da.Fill(ds);

                rep.DataSource = ds.Tables[0].DefaultView;
                rep.DataBind();

                DisposeConnection(con);
            }
            catch (Exception ex)
            {
                DisposeConnection(con);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 绑定Repeater，带分页(ASPNetPage分页)
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="str"></param>
        /// <param name="pagesize">总页数</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="table">表名</param>
        public static void bindRep_page(System.Web.UI.WebControls.Repeater rep, string str, int pagesize, int pageindex)
        {
            OleDbConnection con = OpenConnection();
            try
            {
                DataSet ds = new DataSet();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = str;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds, pagesize * pageindex, pagesize, "#table");
                DataView dv = ds.Tables[0].DefaultView;

                rep.DataSource = dv;
                rep.DataBind();
                DisposeConnection(con);
            }
            catch (Exception ex)
            {
                DisposeConnection(con);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 绑定DataList
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="str"></param>
        public static void bindDDL(System.Web.UI.WebControls.DataList ddl, string str)
        {
            OleDbConnection con = OpenConnection();
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = str;
                da.SelectCommand = cmd;
                da.Fill(ds);

                ddl.DataSource = ds.Tables[0].DefaultView;
                ddl.DataBind();

                DisposeConnection(con);
            }
            catch (Exception ex)
            {
                DisposeConnection(con);
                throw new Exception(ex.Message);
            }
        }
        #endregion 绑定数据控件

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

        #region 获取网站标题
        public static string GetSiteTitle()
        {
            string sql = "select top 1 sys_title from sys_setting";
            string title = CommonLib.AccessHelper.ExecuteScalar(sql).ToString();
            return title;
        }
        #endregion

        #region 获取网站关键词
        public static string GetSiteKey()
        {
            string sql = "select top 1 sys_key from sys_setting";
            string key = CommonLib.AccessHelper.ExecuteScalar(sql).ToString();
            return key;
        }
        #endregion

        #region 修改html文件
        public static void updatexml()
        {
            #region 读取并清除轮播广告xml文件中的广告节点
            string path = System.Web.HttpContext.Current.Server.MapPath("~/flash/xml/bcastr.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            #region 清空bcaster下的所有item节点
            XmlNodeList xln = doc.SelectNodes("/bcaster/item");
            XmlElement root = doc.DocumentElement;
            foreach (XmlNode node in xln)
            {
                root.RemoveChild(node);
            }
            #endregion
            #endregion
            #region 更新xml文件的广告节点
            XmlNodeList xln2 = doc.SelectNodes("/bcaster");
            string sql = "select top 6 * from [ad] where ad_place='其他页面' order by ad_id desc";
            OleDbDataReader dr = getDataReader(sql);
            while (dr.Read())
            {
                #region 创建item节点
                XmlElement xe = doc.CreateElement("item");
                xe.SetAttribute("item_url", "userfiles/ad/" + dr["ad_img"].ToString());
                xe.SetAttribute("link", dr["ad_link"].ToString());
                xe.SetAttribute("title", dr["ad_name"].ToString());
                xln2.Item(0).AppendChild(xe);
                #endregion
            }
            dr.Close(); dr.Dispose();
            doc.Save(path);
            #endregion
        }
        #endregion
    }
}