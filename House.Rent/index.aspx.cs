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

public partial class index : System.Web.UI.Page
{
    #region 初始化
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region 初始化分类编号
            string clsid = "select pro_cls_id from pro_cls where pro_cls_pid=";
            #endregion
            #region 出租房源
            string sql = "select top 15 * from product where  pro_type=1 order by pro_id desc";
            Bind(rep_pro1, sql);
            #endregion
            #region 生活用品
            sql = "select top 6 * from product where pro_type=3 order by pro_id desc";
            Bind(rep_pro2, sql);
            #endregion
            #region 求购
            sql = "select top 6 * from product where pro_type=1 order by pro_id desc";
            Bind(rep_pro3, sql);
            #endregion
            #region 其他
            sql = "select top 12 * from product  order by pro_id desc";
            Bind(rep_pro4, sql);
            #endregion
        }
    }
    #endregion

    #region 绑定列表
    private void Bind(Repeater myrep, string sql)
    {
        string con = CommonLib.SqlHelper.SqlConnectionString;
        CommonLib.SqlHelper.BindRepeater(myrep, con, CommandType.Text, sql, null);
    }
    #endregion
}
