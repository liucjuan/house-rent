﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="member_buy_list.aspx.cs"  Inherits="member_buy_list" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/menuleft.ascx" TagName="menuleft" TagPrefix="uc1" %>


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
            <div id="content" class="content">
                <div class="ScntL">
                    <uc1:menuleft ID="menuleft1" runat="server" />
                </div>
                <div class="ScntR">
                    <div class="ScntR_title">
                        <span class="ScntR_title1">
                            <img src="images/icon4.gif" align="absmiddle" style="margin-right: 8px;" />求购信息</span>
                        <span class="ScntR_title2">你现在的位置：<a href="/">首页&nbsp;&gt;&nbsp;</a><a href="member_buy_list.aspx">求购信息</a></span></div>
                    <div class="productsBox">
                        <div class="newLxt0">
                            <table border="0" cellpadding="0" cellspacing="1" bgcolor="#DEE4FA" style="text-align: center;" width="100%">
                                <tr bgcolor="#F7F7FF">
                                    <td height="30">
                                        标题
                                    </td>
                                    <td>
                                        名称
                                    </td>
                                    <td>
                                        电话
                                    </td>
                                    <td>
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
                                                <%--<%#getclsname(Eval("pro_cls_id").ToString()) %>--%>
                                                <%#Eval("pro_tel") %>
                                            </td>
                                            <td>
                                                <a href="member_buy_add.aspx?id=<%#Eval("pro_id") %>">修改</a> &nbsp;&nbsp;
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
            <div id="footer" class="footer">
                <div class="footerCnt">
                    <p>
                        版权所有：房屋租赁系统网站 <a href="System/ManagerThisWay.aspx" target=_blank>管理员登录</a></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
