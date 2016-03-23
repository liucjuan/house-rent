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

public partial class System_Sys_News_Cls : System.Web.UI.Page
{
    #region 初始化页面
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonLib.AccessHelper.islogin(this.Page);
            ViewState.Add("where", "");
            Bind_Drop(ddl_type);
            Bind();
        }
    }
    #endregion

    #region 绑定类别
    private void Bind_Drop(DropDownList ddl)
    {
        string sql = "select * from pro_cls where pro_cls_pid=0";
        CommonLib.SqlHelper.BindDropDownList(ddl, "pro_cls_name", "pro_cls_id", con, CommandType.Text, sql, null);
    }
    #endregion

    #region 绑定类别列表
    private void Bind()
    {
        string count = "select count(*) from pro_cls where pro_cls_pid>0 and pro_cls_pid<>3";
        AspNetPager1.RecordCount = Convert.ToInt32(CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, count, null));
        string sql = "select * from pro_cls where pro_cls_pid>0 and pro_cls_pid<>3 order by pro_cls_pid asc,pro_cls_id desc";
        CommonLib.SqlHelper.BindGridView(GridView1, sql, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex - 1);

        if (AspNetPager1.RecordCount > 0)
        {
            quanxuan.Visible = true;
            Button2.Visible = true;
        }
        else
        {
            quanxuan.Visible = false;
            Button2.Visible = false;
        }
    }
    #endregion

    #region 添加
    protected void Button3_Click(object sender, EventArgs e)
    {
        string pid = ddl_type.SelectedValue;
        string sql = "insert into pro_cls (pro_cls_name,pro_cls_pid) values ('" + CommonLib.CutString.UrnHtml(TextBox1.Text.Trim()) + "'," + pid + ")";
        try
        {
            int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
            if (i > 0)
            {
                TextBox1.Text = "";
                Bind();
                updatejs();
                CommonLib.JavaScriptHelper.Alert("恭喜，添加成功！", this.Page);
            }
            else
            {
                CommonLib.JavaScriptHelper.Alert("服务器繁忙，添加失败！", this.Page);
            }
        }
        catch
        {
            CommonLib.JavaScriptHelper.Alert("服务器繁忙，添加失败！", this.Page);
        }
    }
    #endregion

    #region 绑定当前行
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int state = Convert.ToInt32(e.Row.RowState);

            if (state == 0 || state == 1)
            {
                Label lb = (Label)e.Row.FindControl("Label2");
                HiddenField hid = (HiddenField)e.Row.FindControl("HiddenField1");
                if (hid.Value != "0")
                {
                    string sql = "select pro_cls_name from pro_cls where pro_cls_id=" + hid.Value;
                    lb.Text = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
                }
                else
                {
                    lb.Text = "父类";
                }
            }

            if (state == 4 || state == 5)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddl_cls");
                HiddenField hid = (HiddenField)e.Row.FindControl("HiddenField2");
                string id = e.Row.Cells[0].Text;
                Bind_Drop(ddl);
                if (ddl.Items.FindByValue(hid.Value) != null)
                    ddl.Items.FindByValue(hid.Value).Selected = true;
            }
        }
    }
    #endregion

    #region 分页
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }
    #endregion

    #region 删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView1.EditIndex = -1;
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        string sql = "delete from pro_cls where pro_cls_id=" + id;
        string sql2 = "select * from product where pro_cls_id=" + id;
        try
        {
            SqlDataReader dr = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql2, null);
            while (dr.Read())
            {
                try
                {
                    System.IO.File.Delete(Server.MapPath("~/upload/" + dr["pro_img"].ToString()));
                }
                catch { }
                try
                {
                    string sql3 = "delete from product where pro_id=" + dr["pro_id"].ToString();
                    CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql3, null);
                }
                catch { }
            }
            dr.Close(); dr.Dispose();

            int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null); ;
            if (i > 0)
            {
                Bind();
                updatejs();
                CommonLib.JavaScriptHelper.Alert("恭喜，删除成功！", this.Page);
            }
            else
            {
                CommonLib.JavaScriptHelper.Alert("服务器繁忙，删除失败！", this.Page);
            }
        }
        catch
        {
            CommonLib.JavaScriptHelper.Alert("服务器繁忙，删除失败！", this.Page);
        }
    }
    #endregion

    #region 更新
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        TextBox txt = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBox2");
        DropDownList ddl = (DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("ddl_cls");
        string sql = "update pro_cls set pro_cls_name='" + CommonLib.CutString.UrnHtml(txt.Text.Trim());
        sql += "',pro_cls_pid=" + ddl.SelectedValue + " where pro_cls_id=" + id.ToString();
        try
        {
            int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null); ;
            if (i > 0)
            {
                GridView1.EditIndex = -1;
                Bind();
                updatejs();
                CommonLib.JavaScriptHelper.Alert("恭喜，修改成功！", this.Page);
            }
            else
            {
                CommonLib.JavaScriptHelper.Alert("服务器繁忙，修改失败！", this.Page);
            }
        }
        catch
        {
            CommonLib.JavaScriptHelper.Alert("服务器繁忙，修改失败！", this.Page);
        }
    }
    #endregion

    #region 编辑
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Bind();
    }
    #endregion

    #region 取消编辑
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Bind();
    }
    #endregion

    #region 批量删除
    protected void Button2_Click(object sender, EventArgs e)
    {
        string idlist = "";
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chkbx = (CheckBox)GridView1.Rows[row.RowIndex].Cells[4].FindControl("chk1");
            int id = Convert.ToInt32(GridView1.Rows[row.RowIndex].Cells[0].Text);
            if (chkbx.Checked)
            {
                idlist += id.ToString() + ",";
            }
        }
        if (idlist.Length > 0)
        {
            idlist = idlist.Substring(0, idlist.Length - 1);
            string sql = "delete from pro_cls where pro_cls_id in (" + idlist + ")";
            string sql2 = "select * from product where pro_cls_id in (" + idlist + ")";
            try
            {
                SqlDataReader dr = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql2, null);
                while (dr.Read())
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath("~/upload/" + dr["pro_img"].ToString()));
                    }
                    catch { }
                    try
                    {
                        string sql3 = "delete from product where pro_id=" + dr["pro_id"].ToString();
                        CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql3, null);
                    }
                    catch { }
                }
                dr.Close(); dr.Dispose();

                int i = CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null); ;
                if (i > 0)
                {
                    Bind();
                    updatejs();
                    CommonLib.JavaScriptHelper.Alert("恭喜，批量删除成功！", this.Page);
                }
                else
                    CommonLib.JavaScriptHelper.Alert("服务器繁忙，删除失败！", this.Page);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                CommonLib.JavaScriptHelper.Alert("服务器繁忙，删除失败！", this.Page);
            }
            this.quanxuan.Value = " 全 选 ";
        }
        else
        {
            CommonLib.JavaScriptHelper.Alert("请选择需要删除的数据！", this.Page);
        }
    }
    #endregion

    #region 生成js
    private void updatejs()
    {
        string sql = "select * from pro_cls";
        string url = System.Web.HttpContext.Current.Server.MapPath("~/js/cls.js");
        System.IO.StreamWriter file = new System.IO.StreamWriter(url, false, System.Text.Encoding.UTF8);
        file.WriteLine("provincearray = new Array();");
        int i = 0;
        try
        {
            SqlDataReader dr = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql, null);
            while (dr.Read())
            {
                file.WriteLine("provincearray[" + i + "] = new Array(\"" + dr["pro_cls_name"].ToString() + "\", \"" + dr["pro_cls_pid"].ToString() + "\", \"" + dr["pro_cls_id"].ToString() + "\");");
                i++;
            }
            dr.Close(); dr.Dispose();
        }
        catch { }
        file.Close(); file.Dispose();
    }
    #endregion
}
