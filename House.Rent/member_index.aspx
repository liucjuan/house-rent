<%@ Page Language="C#" AutoEventWireup="true" CodeFile="member_index.aspx.cs" Inherits="member_index" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
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
                    <div class="Smenu">
                        <div class="SmenuTitle">
                            会员中心
                        </div>
                        <div class="SmenuCnt">
                            <ul>
                                <li><a href="member_index.aspx">个人资料</a></li>
                                <li><a href="member_pwd.aspx">修改密码</a></li>
                                <li><a href="System/yz_Add.aspx?ss=aa" target="_blank">发布预租信息</a></li>
                                <li><a href="System/yz_List.aspx?ss=yy" target="_blank">预租信息管理</a></li>
                                <li><a href="ckhf.aspx">查看留言回复</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="ScntR">
                    <div class="ScntR_title">
                        <span class="ScntR_title1">
                            <img src="images/icon4.gif" alt="" style="margin-right: 8px;" />个人资料</span>
                        <span class="ScntR_title2">你现在的位置：<a href="/">首页&nbsp;&gt;&nbsp;</a><a href="member_index.aspx">个人资料</a></span>
                    </div>
                    <div class="productsBox">
                        <div class="newLxt0">
                            <table>
                                <tr>
                                    <td width="80" align="right" height="30">电话：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tel" runat="server" CssClass="login_txt" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80" align="right" height="30">QQ：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="qq" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80" align="right" height="30">地址：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="add" runat="server" CssClass="login_txt" MaxLength="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div id="footer" class="footer">
                <div class="footerCnt">
                    <p>
                        版权所有：房屋租赁系统网站 <a href="System/ManagerThisWay.aspx" target="_blank">管理员登录</a>
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
