<%@ Page Language="C#" AutoEventWireup="true" CodeFile="member_pro_list.aspx.cs"
    Inherits="member_pro_list" %>

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
                            会员中心</div>
                        <div class="SmenuCnt">
                            <ul>
                                <li><a href="member_index.aspx">个人资料</a></li>
                                <li><a href="member_pwd.aspx">修改密码</a></li>
                                <li><a href="member_pro_add.aspx">添加交易物品</a></li>
                                <li><a href="member_pro_list.aspx">交易物品管理</a></li>
                                <li><a href="member_buy_add.aspx">发布求购</a></li>
                                <li><a href="member_buy_list.aspx">求购信息</a></li>
                                <li><a href="member_buy_log.aspx">购买记录</a></li>
                                <li><a href="member_sales_log.aspx">销售记录</a></li>
                            </ul>
                        </div>
                        <div class="SmenuBg">
                            <img src="images/lmt_q_b.gif" alt="bg" /></div>
                    </div>
                </div>
                <div class="ScntR">
                    <div class="ScntR_title">
                        <span class="ScntR_title1">
                            <img src="images/icon4.gif" align="absmiddle" style="margin-right: 8px;" />交易物品管理</span>
                        <span class="ScntR_title2">你现在的位置：<a href="/">首页&nbsp;&gt;&nbsp;</a><a href="member_pro_list.aspx">交易物品管理</a></span></div>
                    <div class="productsBox">
                        <div class="newLxt0">
                            <table border="0" cellpadding="0" cellspacing="1" bgcolor="#DEE4FA" style="text-align: center;" width="90%">
                                <tr bgcolor="#F7F7FF">
                                    <td height="30">
                                        标题
                                    </td>
                                    <td>
                                        名称
                                    </td>
                                    <td>
                                        图片
                                    </td>
                                    <td>
                                        库存
                                    </td>
                                    <td>
                                        分类
                                    </td>
                                    <td width="80">
                                        操作
                                    </td>
                                </tr>
                                <asp:Repeater ID="rep_list" runat="server" OnItemCommand="rep_list_ItemCommand">
                                    <ItemTemplate>
                                        <tr bgcolor="#ffffff">
                                            <td height="30">
                                                <%#Eval("pro_title") %>
                                            </td>
                                           <td>
                                                <%#Eval("pro_name") %>
                                            </td>
                                            <td>
                                                <img src="<%#System.IO.File.Exists(Server.MapPath("upload/"+Eval("pro_img")))?"upload/"+Eval("pro_img"):"images/no-img.gif" %>"
                                                    alt="<%#Eval("pro_title") %>" width="80" height="60" />
                                            </td>
                                            <td>
                                                <%#Eval("pro_num") %>
                                            </td>
                                            <td>
                                                  <%#getclsname(Eval("pro_id").ToString()) %>
                                            </td>
                                            <td>
                                                <a href="member_pro_add.aspx?id=<%#Eval("pro_id") %>">修改</a> &nbsp;&nbsp;
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("pro_id") %>'
                                                    CommandName="del" OnClientClick='javascript:return confirm("确定删除？");'>删除</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
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
