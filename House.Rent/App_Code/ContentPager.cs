using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// ContentPager 的摘要说明
/// </summary>  
public class ContentPager : System.Web.UI.Page
{
    /************调用方法*************/
    #region 调用方法
    /*
    在aspx中增加lable等元素。
        <asp:Label ID="content" runat="server"></asp:Label><br />
        <asp:Label ID="totalpage" runat="server" CssClass="gray"></asp:Label>，<asp:Label ID="currentpage" runat="server" CssClass="gray">当前页</asp:Label>&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="lnkfist" runat="server" CssClass="gray">首页</asp:HyperLink>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="lnkprev" runat="server" CssClass="gray">上一页</asp:HyperLink>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="lnknext" runat="server" CssClass="gray">下一页</asp:HyperLink>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="lnklast" runat="server" CssClass="gray">尾页</asp:HyperLink>
    在aspx.cs中增加调用代码。
     if (Request["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);//接收参数，例如访问这个页是xxx.aspx?id=1

            string cont = "";
            string sql = "select news_content from news where news_id=" + id.ToString();
            cont = CommonLib.AccessHelper.ExecuteScalar(sql).ToString();
            string strSplit = "";
            sql = "select news_split from news where news_id=" + id.ToString();
            strSplit = CommonLib.AccessHelper.ExecuteScalar(sql).ToString();

            //文章分页,关键部分 
            ContentPager pager = new ContentPager();

            pager.Lnknext = this.lnknext;
            pager.Lnkprev = this.lnkprev;
            pager.Lnklast = this.lnklast;
            pager.Lnkfist = this.lnkfist;
            pager.Pagenum = this.currentpage;
            pager.Pagecount = this.totalpage;
            pager.DisplayContent = this.content;

            string query = "&id=" + Request.QueryString["id"].ToString();
            pager.datapager(cont, query, strSplit);
        }
     */
    #endregion
    /************调用方法*************/

    #region 初始化变量

    #region 下一页
    private HyperLink lnknext;
    public HyperLink Lnknext
    {
        get
        {
            return this.lnknext;
        }
        set
        {
            this.lnknext = value;
        }
    }
    #endregion

    #region 上一页
    private HyperLink lnkprev;//上一页
    public HyperLink Lnkprev
    {
        get
        {
            return this.lnkprev;
        }
        set
        {
            this.lnkprev = value;
        }
    }
    #endregion

    #region  首页
    private HyperLink lnkfist;//首页
    public HyperLink Lnkfist
    {
        get
        {
            return this.lnkfist;
        }
        set
        {
            this.lnkfist = value;
        }
    }
    #endregion

    #region  尾页
    private HyperLink lnklast;//尾页
    public HyperLink Lnklast
    {
        get
        {
            return this.lnklast;
        }
        set
        {
            this.lnklast = value;
        }
    }
    #endregion

    #region  当前页
    private Label pagenum;//当前页
    public Label Pagenum
    {
        get
        {
            return this.pagenum;
        }
        set
        {
            this.pagenum = value;
        }
    }
    #endregion

    #region 总页数
    private Label pagecount;//总页数
    public Label Pagecount
    {
        get
        {
            return this.pagecount;
        }
        set
        {
            this.pagecount = value;
        }
    }
    #endregion

    #region 内容
    private Label displaycontent;
    public Label DisplayContent
    {
        get
        {
            return this.DisplayContent;
        }
        set
        {
            this.displaycontent = value;
        }
    }
    #endregion

    #endregion

    #region 初始化
    public ContentPager()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    #endregion

    #region 分页处理
    /// <summary>
    /// 处理内容，并分页
    /// </summary>
    /// <param name="content">内容</param>
    /// <param name="query">内容页面使用的参数，如&id=1</param>
    /// <param name="strSplit">是否指定分子符，若为空，表示使用web.config中的分页符。字符可以读取数据库后传递过来，防止内容中出现该字符</param>
    public void datapager(string content, string query, string strSplit)
    {
        #region 分页符
        string PagerSplit = "";
        if (strSplit == "")
        {
            PagerSplit = System.Configuration.ConfigurationManager.AppSettings["PagerSplit"];//从web.config中获取分页符
        }
        else
        {
            PagerSplit = strSplit;
        }
        #endregion
        
        #region 处理内容，并分割
        string[] contentArray = StringSplit(content, PagerSplit);
        #endregion

        #region 绑定分页链接信息
        int PageCount = contentArray.Length;
        this.pagecount.Text = "共<b><font color='#FF0000'>" + PageCount.ToString() + "</font></b>页";
        int CurPage;

        #region 确定当前页数
        if (System.Web.HttpContext.Current.Request.Params["page"] != null)
        {
            CurPage = Convert.ToInt32(System.Web.HttpContext.Current.Request.Params["page"]);
        }
        else
        {
            CurPage = 1;
        }

        if (CurPage < 1) CurPage = 1;
        if (Convert.ToInt32(System.Web.HttpContext.Current.Request.Params["page"]) > PageCount)
        {
            CurPage = PageCount;
        }
        #endregion

        #region 显示当前页数
        this.pagenum.Text = "当前为第<b><font color='#FF0000'>" + CurPage.ToString() + "</font></b>页";
        #endregion

        #region 下一页
        if (CurPage != PageCount)
        {
            lnknext.Enabled = true;
            lnknext.NavigateUrl = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(CurPage + 1) + query;
        }
        else
        {
            lnknext.Enabled = false;
        }
        #endregion

        #region 上一页
        if (CurPage > 1)
        {
            lnkprev.Enabled = true;
            lnkprev.NavigateUrl = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(CurPage - 1) + query;
        }
        else
        {
            lnkprev.Enabled = false;
        }
        #endregion

        #region 首页
        if (CurPage != 1)
        {
            lnkfist.Enabled = true;
            lnkfist.NavigateUrl = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(1) + query;
        }
        else
        {
            lnkfist.Enabled = false;
        }
        #endregion

        #region 尾页
        if (CurPage != PageCount)
        {
            lnklast.Enabled = true;
            lnklast.NavigateUrl = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(PageCount) + query;
        }
        else
        {
            lnklast.Enabled = false;
        }
        #endregion

        #endregion
        displaycontent.Text = contentArray[CurPage - 1].ToString();
        SubStringResidual(displaycontent);
    }
    #endregion

    #region 将字符串分割成数组
    /// <summary>
    /// 将字符串分割成数组
    /// </summary>
    /// <param name="strSource"></param>
    /// <param name="strSplit"></param>
    /// <returns></returns>
    public string[] StringSplit(string strSource, string strSplit)
    {
        string[] strtmp = new string[1];
        int index = strSource.IndexOf(strSplit, 0);
        if (index < 0)
        {
            strtmp[0] = strSource;
            return strtmp;
        }
        else
        {
            strtmp[0] = strSource.Substring(0, index);
            return StringSplit(strSource.Substring(index + strSplit.Length), strSplit, strtmp);
        }
    }
    #endregion

    #region 采用递归将字符串分割成数组
    /// <summary>
    /// 采用递归将字符串分割成数组
    /// </summary>
    /// <param name="strSource"></param>
    /// <param name="strSplit"></param>
    /// <param name="attachArray"></param>
    /// <returns></returns>
    private string[] StringSplit(string strSource, string strSplit, string[] attachArray)
    {
        string[] strtmp = new string[attachArray.Length + 1];
        attachArray.CopyTo(strtmp, 0);

        int index = strSource.IndexOf(strSplit, 0);
        if (index < 0)
        {
            strtmp[attachArray.Length] = strSource;
            return strtmp;
        }
        else
        {
            strtmp[attachArray.Length] = strSource.Substring(0, index);
            return StringSplit(strSource.Substring(index + strSplit.Length), strSplit, strtmp);
        }
    }
    #endregion

    #region 清除内容中的多余标签，如使用FCK回车插入分页使用的字符后，会多出<p></p>及其他标签，分页后内容中存在残留有一半开始或结束标签
    private void SubStringResidual(Label mylb)
    {
        int n = -1;//需要清除字符串的位置，及">"的位置
        bool cut = false;//是否存在"</"

        #region 清除内容开始的残留标签，如果内容中头部开始，"<"后面的字符是"/"，需要去除该标签
        for (int i = 0; i < mylb.Text.Length; i++)
        {
            #region 如果cut为true，表示存在"</"，则需要找到第一个">"，并记录其位置，并将cut置为false
            if (cut)
            {
                if (mylb.Text.Substring(i, 1) == ">")
                {
                    n = i;//记录">"的位置
                    cut = false;
                    continue;
                }
            }
            else
            {
                #region 判断是否循环到最好一个字符
                if (i + 1 != mylb.Text.Length)
                {
                    #region 该条件表示，内容头部存在残留标签，记录"/"后的第一个">"的位置，并继续循环
                    if (mylb.Text.Substring(i, 2) == "</")
                    {
                        cut = true;
                        continue;
                    }
                    #endregion

                    #region 该条件表示，内容头部不存在残留标签，跳出循环
                    else
                    {
                        cut = false;
                        break;
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
        }

        mylb.Text = mylb.Text.Substring(n + 1, mylb.Text.Length - n - 1);
        #endregion

        #region 清除内容尾部的残留标签
        n = mylb.Text.Length;
        for (int j = mylb.Text.Length - 1; j >= 0; j--)
        {
            #region 判断是否循环到第一个字符
            if (j - 1 != 0)
            {
                #region 该条件表示，内容尾部部不存在残留标签，跳出循环
                if (mylb.Text.Substring(j - 1, 2) == "</")
                {
                    break;
                }
                #endregion

                #region 该条件表示，内容头部存在残留标签，记录"/"后的第一个">"的位置，并继续循环
                else if (mylb.Text.Substring(j - 1, 1) == "<")
                {
                    n = j - 1;
                    continue;
                }
                #endregion
            }

            mylb.Text = mylb.Text.Substring(0, n);
            #endregion
        }
        #endregion
    }
    #endregion
}
