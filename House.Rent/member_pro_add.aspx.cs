using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class member_pro_add : System.Web.UI.Page
{
    #region 初始化
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["buy"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            if (Request["id"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Bind();
                }
                catch
                {
                    CommonLib.JavaScriptHelper.AlertAndRedirect("数据不存在或已删除", "member_pro_list.aspx");
                }
            }
        }
    }
    #endregion

    #region 绑定
    private void Bind()
    {
        #region 会员编号
        string mname = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
        string con = CommonLib.SqlHelper.SqlConnectionString;
        string sql = "select m_id from member where m_name='" + mname + "'";
        string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
        #endregion
        sql = "select * from product where pro_id=" + Request.QueryString["id"]
            + " and m_id=" + mid;
        SqlDataReader dr = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql, null);
        if (dr.Read())
        {
            title.Text = dr["pro_title"].ToString();
            name.Text = dr["pro_name"].ToString();
            hidclsid.Value = dr["pro_cls_id"].ToString();
            edit.Value = dr["pro_img"].ToString();
            pri.Text = dr["pro_pri"].ToString();
            num.Text = dr["pro_num"].ToString();
            tel.Text = dr["pro_tel"].ToString();
            qq.Text = dr["pro_qq"].ToString();
            add.Text = dr["pro_add"].ToString();
            intro.Text = dr["pro_intro"].ToString();
            dr.Close(); dr.Dispose();
        }
        else
        {
            dr.Close(); dr.Dispose();
            CommonLib.JavaScriptHelper.AlertAndRedirect("数据不存在或已删除", "member_pro_list.apx", Page);
        }
    }
    #endregion

    #region 提交
    protected void Button1_Click(object sender, EventArgs e)
    {
        #region 上传文件
        string path = "";
        string url = "";
        int state = 1;
        string[] exts ={ ".jpg", ".gif", ".png", ".bmp", ".jpeg" };
        if (FileUpload1.HasFile)
        {
            path = CommonLib.FileHelper.UploadFile(FileUpload1, "upload/", 1024 * 2, exts, Page);
            if (path == "")
            {
                state = -1;
            }
            else
            {
                url = path.Replace("upload/", "");
            }
        }
        else
        {
            url = edit.Value;
        }
        #endregion
        if (state > 0)
        {
            #region 会员编号
            string mname = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
            string con = CommonLib.SqlHelper.SqlConnectionString;
            string sql = "select m_id from member where m_name='" + mname + "'";
            string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
            #endregion
            #region 添加
            int kc = 1;
            try { kc = Convert.ToInt32(num.Text.Trim()); }
            catch { }
            num.Text = kc.ToString();
            if (Request["id"] == null)
            {
                sql = "insert into product (pro_title,pro_name,pro_cls_id,pro_img,pro_pri,pro_num"
                    + ",pro_tel,pro_qq,pro_add,pro_intro,m_id,pro_type,pro_date) values "
                    + "('" + urnhtml(title.Text.Trim()) + "','" + urnhtml(name.Text.Trim())
                    + "'," + hidclsid.Value + ",'" + url + "','" + urnhtml(pri.Text.Trim())
                    + "'," + kc + ",'" + urnhtml(tel.Text.Trim()) + "','" + urnhtml(qq.Text.Trim())
                    + "','" + urnhtml(add.Text.Trim()) + "','" + urnhtml(intro.Text.Trim())
                    + "'," + mid + ",1,'" + DateTime.Now + "')";
                try
                {
                    CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                    CommonLib.JavaScriptHelper.AlertAndRedirect("添加成功", "member_pro_list.aspx", Page);
                }
                catch
                {
                    try { System.IO.File.Delete(Server.MapPath(path)); }
                    catch { }
                    CommonLib.JavaScriptHelper.Alert("添加失败", Page);
                }
            }
            #endregion
            #region 修改
            else
            {
                sql = "update product set pro_title='" + urnhtml(title.Text.Trim())
                    + "',pro_name='" + urnhtml(name.Text.Trim())
                    + "',pro_cls_id=" + hidclsid.Value
                    + ",pro_img='" + url
                    + "',pro_pri='" + urnhtml(pri.Text.Trim())
                    + "',pro_num=" + kc
                    + ",pro_tel='" + urnhtml(tel.Text.Trim())
                    + "',pro_qq='" + urnhtml(qq.Text.Trim())
                    + "',pro_add='" + urnhtml(add.Text.Trim())
                    + "',pro_intro='" + urnhtml(intro.Text.Trim())
                    + "' where pro_id=" + Request.QueryString["id"];
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
                    CommonLib.JavaScriptHelper.AlertAndRedirect("修改成功", "member_pro_list.aspx", Page);
                }
                catch
                {
                    try { System.IO.File.Delete(Server.MapPath(path)); }
                    catch { }
                    CommonLib.JavaScriptHelper.Alert("修改失败", Page);
                }
            }
            #endregion
        }
    }
    #endregion

    #region 过滤
    private string urnhtml(string str)
    {
        return CommonLib.CutString.UrnHtml(str);
    }
    #endregion
}
