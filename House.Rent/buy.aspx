<%@ Page Language="C#" AutoEventWireup="true" CodeFile="buy.aspx.cs" Inherits="buy" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题页</title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/content.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <uc1:top ID="Top1" runat="server" />
            <div id="content">
                <div class="ScntL">
                    <div class="Smenu">
                        <div class="SmenuTitle">
                            <asp:HyperLink ID="hy_cls" runat="server"></asp:HyperLink></div>
                        <div class="SmenuCnt">
                            <ul>
                                <asp:Repeater ID="rep_cls" runat="server">
                                    <ItemTemplate>
                                        <li><a href="buy.aspx?<%#Eval("pro_cls_pid").ToString()=="0"?"cls":"t" %>=<%#Eval("pro_cls_id") %>">
                                            <%#Eval("pro_cls_name") + " (" + getcount(Eval("pro_cls_id").ToString()) + ")"%>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="SmenuBg">
                            <img src="images/lmt_q_b.gif" alt="bg" /></div>
                    </div>
                </div>
                <div class="ScntR">
                    <div class="ScntR_title">
                        <span class="ScntR_title1">
                            <img src="images/icon4.gif" align="absmiddle" style="margin-right: 8px;" /><%=HyperLink1.Text.Replace("&nbsp;&gt;&nbsp;", "")%></span>
                        <span class="ScntR_title2">你现在的位置：<a href="/">首页&nbsp;&gt;&nbsp;</a><asp:HyperLink
                            ID="HyperLink1" runat="server"></asp:HyperLink><asp:HyperLink ID="HyperLink2" runat="server"></asp:HyperLink></span></div>
                    <div class="productsBox">
                        <div class="newLxt0">
                            <ul class="newLxt">
                                <asp:Repeater ID="rep_list" runat="server">
                                    <ItemTemplate>
                                        <li><span class="no"><a href="supply-display.aspx?id=<%#Eval("pro_id") %>" target="_blank"
                                            title="<%#Eval("pro_title") %>">
                                            <%#CommonLib.CutString.CutWithSubstring(Eval("pro_title").ToString(),30) %>
                                        </a></span><span class="lxtDate">
                                            <%#Eval("pro_date","{0:yyyy-MM-dd}") %>
                                        </span></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="pages">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条"
                                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                    PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowCustomInfoSection="Left"
                                    ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到"
                                    PageSize="15">
                                </webdiyer:AspNetPager>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="footer">
                <div class="footerCnt">
                    <p>
                        版权所有：房屋租赁系统网站 <a href="System/ManagerThisWay.aspx" target=_blank>管理员登录</a></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
