<%@ Page Language="C#" AutoEventWireup="true" CodeFile="member_pwd.aspx.cs" Inherits="member_pwd" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/menuleft.ascx" TagName="menuleft" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题页</title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function l()
        {
            var pwd=document.getElementById("pwd");
            var pwd2=document.getElementById("pwd2");
            var pwd3=document.getElementById("pwd3");
            if(pwd.value=="")
            {
                alert("请输入原密码");
                pwd.focus();
                return false;
            }
            if(pwd2.value=="")
            {
                alert("请输入新密码");
                pwd2.focus();
                return false;
            }
            if(pwd3.value=="")
            {
                alert("请重新输入新密码");
                pwd3.focus();
                return false;
            }
            else if(pwd3.value!=pwd2.value)
            {
                alert("输入的密码不一致");
                pwd3.focus();
                return false;
            }
        }
    </script>
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
                            <img src="images/icon4.gif" align="absmiddle" style="margin-right: 8px;" />修改密码</span>
                        <span class="ScntR_title2">你现在的位置：<a href="/">首页&nbsp;&gt;&nbsp;</a><a href="member_pwd.aspx">修改密码</a></span></div>
                    <div class="productsBox">
                        <div class="newLxt0">
                            <table>
                                <tr>
                                    <td width="80" align="right" height="30">
                                        原密码：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="pwd" runat="server" CssClass="login_txt" MaxLength="20" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80" align="right" height="30">
                                        新密码：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="pwd2" runat="server" CssClass="login_txt" MaxLength="20" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80" align="right" height="30">
                                        重复密码：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="pwd3" runat="server" CssClass="login_txt" MaxLength="20" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" OnClientClick="javascript:return l();" />
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
                        版权所有：房屋租赁系统网站 <a href="System/ManagerThisWay.aspx" target=_blank>管理员登录</a></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
