using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Model;

public partial class System_Sys_Member_Add : System.Web.UI.Page
{
    protected string con = CommonLib.SqlHelper.SqlConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonLib.SqlHelper.islogin(Page);
            //#region 会员编号
            //string mname = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
            //string con = CommonLib.SqlHelper.SqlConnectionString;
            //string sql = "select m_id from member where m_name='" + mname + "'";
            //string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
            //
            if (Request.QueryString["id"] != null)
            {
                //SqlDataReader SelectReader(List<string> fieldList, Dictionary<string, string> whereDic, string tableName)

                List<string> fieldList = new List<string>();
                Dictionary<string, string> whereDic = new Dictionary<string, string>();
                whereDic.Add("pro_id",Request.QueryString["id"]);
                DataSet ds = DBHelper.SelectDataSet(fieldList, whereDic, DBConfig.product);
                ProductModel product=new ProductModel();
                DBHelper.GetClassInfoAndSetValue<ProductModel>(product,ds);
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        title.Text = product.Pro_title;//dr["pro_title"].ToString();
                        name.Text = product.Pro_name;// dr["pro_name"].ToString();
                        edit.Value = product.Pro_img;// dr["pro_img"].ToString();
                        pri.Text = product.Pro_pri;//dr["pro_pri"].ToString();
                        num.Text = product.Pro_num.ToString();//   dr["pro_num"].ToString();
                        tel.Text = product.Pro_tel;//  dr["pro_tel"].ToString();
                        qq.Text = product.Pro_qq;//dr["pro_qq"].ToString();
                        add.Text = product.Pro_add;// dr["pro_add"].ToString();
                        intro.Text = product.Pro_intro;// dr["pro_intro"].ToString();
                        TextBox1.Text = product.Xq;// dr["xq"].ToString();
                        TextBox2.Text = product.Zx;// dr["zx"].ToString();
                        TextBox3.Text = product.Zlc;//dr["zlc"].ToString();
                        TextBox4.Text = product.Szlc;// dr["szlc"].ToString();
                        TextBox5.Text = product.Cx;// dr["cx"].ToString();
                        TextBox6.Text = product.Ll;// dr["ll"].ToString();
                        TextBox7.Text = product.Yt;//dr["yt"].ToString();
                        #region 暂时不用
                        //pri.Text = dr["pro_pri"].ToString();
                        //num.Text = dr["pro_num"].ToString();
                        //tel.Text = dr["pro_tel"].ToString();
                        //qq.Text = dr["pro_qq"].ToString();
                        //add.Text = dr["pro_add"].ToString();
                        //intro.Text = dr["pro_intro"].ToString();
                        //TextBox1.Text = dr["xq"].ToString();
                        //TextBox2.Text = dr["zx"].ToString();
                        //TextBox3.Text = dr["zlc"].ToString();
                        //TextBox4.Text = dr["szlc"].ToString();
                        //TextBox5.Text = dr["cx"].ToString();
                        //TextBox6.Text = dr["ll"].ToString();
                        //TextBox7.Text = dr["yt"].ToString(); 
                        #endregion
                    }            
                }
                else
                {
                    CommonLib.JavaScriptHelper.AlertAndRedirect("数据不存在或已删除", "member_buy_list.apx", Page);
                }
                #region 暂时不用
                //string sql = "select * from product where pro_id=" + Request.QueryString["id"] + "";
                //SqlDataReader dr = CommonLib.SqlHelper.ExecuteReader(con, CommandType.Text, sql, null);
                //if (dr.Read())
                //{
                //    title.Text = dr["pro_title"].ToString();
                //    name.Text = dr["pro_name"].ToString();

                //    edit.Value = dr["pro_img"].ToString();
                //    pri.Text = dr["pro_pri"].ToString();
                //    num.Text = dr["pro_num"].ToString();
                //    tel.Text = dr["pro_tel"].ToString();
                //    qq.Text = dr["pro_qq"].ToString();
                //    add.Text = dr["pro_add"].ToString();
                //    intro.Text = dr["pro_intro"].ToString();
                //    TextBox1.Text = dr["xq"].ToString();
                //    TextBox2.Text = dr["zx"].ToString();
                //    TextBox3.Text = dr["zlc"].ToString();
                //    TextBox4.Text = dr["szlc"].ToString();
                //    TextBox5.Text = dr["cx"].ToString();
                //    TextBox6.Text = dr["ll"].ToString();
                //    TextBox7.Text = dr["yt"].ToString();
                //    dr.Close(); dr.Dispose();
                //}
                //else
                //{
                //    dr.Close(); dr.Dispose();
                //    CommonLib.JavaScriptHelper.AlertAndRedirect("数据不存在或已删除", "member_buy_list.apx", Page);
                //} 
                #endregion
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        string path = "";
        string url = "";
        int state = 1;
        string[] exts = {".jpg", ".gif", ".png", ".bmp", ".jpeg"};
        if (FileUpload1.HasFile)
        {
            path = CommonLib.FileHelper.UploadFile(FileUpload1, "../upload/", 1024*2, exts, Page);
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
            string sql = "";
            //#region 会员编号
            //string mname = HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]);
            //string con = CommonLib.SqlHelper.SqlConnectionString;
            //string sql = "select m_id from member where m_name='" + mname + "'";
            //string mid = CommonLib.SqlHelper.ExecuteScalar(con, CommandType.Text, sql, null).ToString();
            //
            //#region 添加
            int kc = 1;
            try
            {
                kc = Convert.ToInt32(num.Text.Trim());
            }
            catch
            {
            }
            num.Text = kc.ToString();
            if (Request["id"] == null)
            {
                //ErrorType AddData(Dictionary<string, string> fieldsAndValue, string tableName)
                Dictionary<string, string> fieldsAndValue = new Dictionary<string, string>();
                fieldsAndValue.Add("pro_title", title.Text.Trim());
                fieldsAndValue.Add("pro_name", name.Text.Trim());
                fieldsAndValue.Add("pro_img", url);
                fieldsAndValue.Add("pro_pri", pri.Text.Trim());
                fieldsAndValue.Add("pro_num", kc.ToString());
                fieldsAndValue.Add("pro_tel", tel.Text.Trim());
                fieldsAndValue.Add("pro_qq", qq.Text.Trim());
                fieldsAndValue.Add("pro_add", add.Text.Trim());
                fieldsAndValue.Add("pro_intro", intro.Text.Trim());
                fieldsAndValue.Add("pro_type", ddl_yi.SelectedValue.ToString());
                fieldsAndValue.Add("pro_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                fieldsAndValue.Add("xq", TextBox1.Text);
                fieldsAndValue.Add("zx", TextBox2.Text);
                fieldsAndValue.Add("zlc", TextBox3.Text);
                fieldsAndValue.Add("szlc", TextBox4.Text);
                fieldsAndValue.Add("cx", TextBox5.Text);
                fieldsAndValue.Add("ll", TextBox6.Text);
                fieldsAndValue.Add("yt", TextBox7.Text);
                ErrorType errorType = DBHelper.AddData(fieldsAndValue, DBConfig.product);
                if (errorType == ErrorType.Success)
                {
                    CommonLib.JavaScriptHelper.AlertAndRedirect("添加成功", "Sys_Product_List.aspx", Page);
                }
                else
                {
                    CommonLib.JavaScriptHelper.Alert("添加失败", Page);
                }

                #region 暂时不用

                //sql = "insert into product (pro_title,pro_name,pro_img,pro_pri,pro_num"
                //    + ",pro_tel,pro_qq,pro_add,pro_intro,pro_type,pro_date,xq,zx,zlc,szlc,cx,ll,yt) values "
                //    + "('" + urnhtml(title.Text.Trim()) + "','" + urnhtml(name.Text.Trim())
                //    + "','" + url + "','" + urnhtml(pri.Text.Trim())
                //    + "'," + kc + ",'" + urnhtml(tel.Text.Trim()) + "','" + urnhtml(qq.Text.Trim())
                //    + "','" + urnhtml(add.Text.Trim()) + "','" + urnhtml(intro.Text.Trim())
                //    + "','" + ddl_yi.SelectedValue.ToString() + "','" + DateTime.Now + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')";
                //try
                //{
                //    CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                //    CommonLib.JavaScriptHelper.AlertAndRedirect("添加成功", "Sys_Product_List.aspx", Page);
                //}
                //catch
                //{
                //    try { System.IO.File.Delete(Server.MapPath(path)); }
                //    catch { }
                //    CommonLib.JavaScriptHelper.Alert("添加失败", Page);
                //} 

                #endregion
            }
            else
            {
                Dictionary<string, string> updateDic = new Dictionary<string, string>();
                Dictionary<string, string> whereDic = new Dictionary<string, string>();
                updateDic.Add("pro_title", title.Text.Trim());
                updateDic.Add("pro_name", name.Text.Trim());
                updateDic.Add("pro_type", ddl_yi.SelectedValue.ToString());
                updateDic.Add("pro_img", url);
                updateDic.Add("pro_pri", pri.Text.Trim());
                updateDic.Add("pro_num", kc.ToString());
                updateDic.Add("pro_tel", tel.Text.Trim());
                updateDic.Add("pro_qq", qq.Text.Trim());
                updateDic.Add("pro_add", add.Text.Trim());
                updateDic.Add("pro_intro", intro.Text.Trim());
                updateDic.Add("xq", TextBox1.Text);
                updateDic.Add("zx", TextBox2.Text);
                updateDic.Add("zlc", TextBox3.Text);
                updateDic.Add("szlc", TextBox4.Text);
                updateDic.Add("cx", TextBox5.Text);
                updateDic.Add("ll", TextBox6.Text);
                updateDic.Add("yt", TextBox7.Text);

                whereDic.Add("pro_id", Request.QueryString["id"]);

                ErrorType errorType = DBHelper.UpdateData(updateDic, whereDic, DBConfig.product);
                if (errorType == ErrorType.Success)
                {
                    if (FileUpload1.HasFile)
                    {
                        System.IO.File.Delete(Server.MapPath("~/upload/" + edit.Value));
                        edit.Value = url;
                    }
                    CommonLib.JavaScriptHelper.AlertAndRedirect("修改成功", "member_buy_list.aspx", Page);
                }
                else
                {
                    CommonLib.JavaScriptHelper.Alert("修改失败", Page);
                }

                #region 暂时不用
                //sql = "update product set pro_title='" + urnhtml(title.Text.Trim())
                //           + "',pro_name='" + urnhtml(name.Text.Trim())
                //           + "',pro_type=" + ddl_yi.SelectedValue.ToString()
                //           + ",pro_img='" + url
                //           + "',pro_pri='" + urnhtml(pri.Text.Trim())
                //           + "',pro_num=" + kc
                //           + ",pro_tel='" + urnhtml(tel.Text.Trim())
                //           + "',pro_qq='" + urnhtml(qq.Text.Trim())
                //           + "',pro_add='" + urnhtml(add.Text.Trim())
                //           + "',pro_intro='" + urnhtml(intro.Text.Trim())
                //            + "',xq='" + urnhtml(TextBox1.Text.Trim())
                //             + "',zx='" + urnhtml(TextBox2.Text.Trim())
                //              + "',zlc='" + urnhtml(TextBox3.Text.Trim())
                //               + "',szlc='" + urnhtml(TextBox4.Text.Trim())
                //                + "',cx='" + urnhtml(TextBox5.Text.Trim())
                //                 + "',ll='" + urnhtml(TextBox6.Text.Trim())
                //                  + "',yt='" + urnhtml(TextBox7.Text.Trim())
                //           + "' where pro_id=" + Request.QueryString["id"];
                //try
                //{
                //    CommonLib.SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
                //    try
                //    {
                //        if (FileUpload1.HasFile)
                //        {
                //            System.IO.File.Delete(Server.MapPath("~/upload/" + edit.Value));
                //            edit.Value = url;
                //        }
                //    }
                //    catch { }
                //    CommonLib.JavaScriptHelper.AlertAndRedirect("修改成功", "member_buy_list.aspx", Page);
                //}
                //catch
                //{
                //    try { System.IO.File.Delete(Server.MapPath(path)); }
                //    catch { }
                //    CommonLib.JavaScriptHelper.Alert("修改失败", Page);
                //} 

                #endregion
            }

        }
    }


    private string urnhtml(string str)
    {
        return CommonLib.CutString.UrnHtml(str);
    }

   
}
