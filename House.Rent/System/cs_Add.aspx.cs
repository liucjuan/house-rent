using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
public partial class System_Sys_Member_Add : System.Web.UI.Page
{
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CommonLib.SqlHelper.islogin(Page);
            //#region 会员编号
            //string mname = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
            //string con = CommonLib.SqlHelper.SqlConnectionString;
            //string sql = "select m_id from member where m_name='" + mname + "'";
            //string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
            //

            if (Request.QueryString["id"] != null)
            {
                string sql = "select * from csht where id=" + Request.QueryString["id"] + "";
                SqlDataReader dr = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql, null);
                if (dr.Read())
                {
                    title.Text = dr["title"].ToString();
                    intro.Text = dr["js"].ToString();
                   
                    edit.Value = dr["path"].ToString();
                
                    dr.Close(); dr.Dispose();
                }
                else
                {
                    dr.Close(); dr.Dispose();
                    CommonLib.JavaScriptHelper.AlertAndRedirect("数据不存在或已删除", "member_buy_list.apx", Page);
                }
            }
        }
    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string path = "";
        string url = "";
        int state = 1;
        string[] exts ={ ".doc"};
        if (FileUpload1.HasFile)
        {
            path = CommonLib.FileHelper.UploadFile(FileUpload1, "../upload/", 1024 * 2, exts, Page);
            if (path == "")
            {
                state = -1;
            }
            else
            {
                url = path.Replace("../upload/", "");
            }
        }
        else
        {
            url = edit.Value;
        }
        
        if (state > 0)
        {
            string sql="";
           
            
            if (Request["id"] == null)
            {
                sql = "insert into csht (title,js,path) values "
                    + "('" + urnhtml(title.Text.Trim()) + "','" + urnhtml(intro.Text.Trim())
                    + "','" + url + "')";
                   
                try
                {
                    CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                    //CommonLib.JavaScriptHelper.AlertAndRedirect("添加成功", "Sys_Product_List.aspx", Page);
                }
                catch
                {
                    try { System.IO.File.Delete(Server.MapPath(path)); }
                    catch { }
                    CommonLib.JavaScriptHelper.Alert("添加失败", Page);
                }
            }
            
           
            else
            {
                sql = "update csht set js='" + intro.Text+ "', title='" + urnhtml(title.Text.Trim())
                   
                    + "',path='" + url
                    
                    + "' where id=" + Request.QueryString["id"];
                try
                {
                    CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                    try
                    {
                        if (FileUpload1.HasFile)
                        {
                            System.IO.File.Delete(Server.MapPath("~/upload/" + edit.Value));
                            edit.Value = url;
                        }
                    }
                    catch { }
                    CommonLib.JavaScriptHelper.AlertAndRedirect("修改成功", "csht_List.aspx", Page);
                }
                catch
                {
                    try { System.IO.File.Delete(Server.MapPath(path)); }
                    catch { }
                    CommonLib.JavaScriptHelper.Alert("修改失败", Page);
                }
            }
            
        }
    }

  
    private string urnhtml(string str)
    {
        return CommonLib.CutString.UrnHtml(str);
    }

   
}
