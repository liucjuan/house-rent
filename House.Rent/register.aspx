<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="login" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题页</title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/content.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function l()
        {
            var user=document.getElementById("login_user");
            var pwd=document.getElementById("login_pwd");
            if(user.value=="")
            {
                alert("请输入用户名");
                user.focus();
                return false;
            }
            if(pwd.value=="")
            {
                alert("请输入密码");
                pwd.focus();
                return false;
            }
        }
        function r()
        {
            var user=document.getElementById("r_user");
            var pwd=document.getElementById("r_pwd");
            var pwd2=document.getElementById("r_pwd2");
            if(user.value=="")
            {
                alert("请输入用户名");
                user.focus();
                return false;
            }
            if(pwd.value=="")
            {
                alert("请输入密码");
                pwd.focus();
                return false;
            }
            if(pwd2.value=="")
            {
                alert("请重新输入密码");
                pwd2.focus();
                return false;
            }
            else if(pwd2.value!=pwd.value)
            {
                alert("您输入的密码不一致");
                pwd2.focus();
                return false;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <uc1:top ID="Top1" runat="server" />
            <div id="content">
                <div class="login_l">
                    <div class="login_t">
                        登录</div>
                    <div class="login_cont">
                        <table width="100%">
                            <tr>
                                <td width="100" align="right" height="30">
                                    用户名：
                                </td>
                                <td>
                                    <asp:TextBox ID="login_user" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                            <tr>
                                <td width="100" align="right" height="30">
                                    密码：
                                </td>
                                <td>
                                    <asp:TextBox ID="login_pwd" runat="server" CssClass="login_txt" TextMode="Password" MaxLength="20"></asp:TextBox>
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                            <tr>
                                <td width="100" align="right" height="30">
                                    
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="登录" OnClientClick="javascript:return l();" OnClick="Button1_Click" />
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="login_r">
                    <div class="login_t">
                        注册</div>
                    <div class="login_cont">
                        <table width="100%">
                            <tr>
                                <td width="100" align="right" height="30">
                                    用户名：
                                </td>
                                <td>
                                    <asp:TextBox ID="r_user" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                            <tr>
                                <td width="100" align="right" height="30">
                                    密码：
                                </td>
                                <td>
                                    <asp:TextBox ID="r_pwd" runat="server" CssClass="login_txt" TextMode="Password" MaxLength="20"></asp:TextBox>
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                            <tr>
                                <td width="100" align="right" height="30">
                                    重复密码：
                                </td>
                                <td>
                                    <asp:TextBox ID="r_pwd2" runat="server" CssClass="login_txt" TextMode="Password" MaxLength="20"></asp:TextBox>
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                            <tr>
                                <td width="100" align="right" height="30">
                                    电话：
                                </td>
                                <td>
                                    <asp:TextBox ID="tel" runat="server" CssClass="login_txt"></asp:TextBox>
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                            <tr>
                                <td width="100" align="right" height="30">
                                    QQ：
                                </td>
                                <td>
                                    <asp:TextBox ID="qq" runat="server" CssClass="login_txt"></asp:TextBox>
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                            <tr>
                                <td width="100" align="right" height="30">
                                    地址：
                                </td>
                                <td>
                                    <asp:TextBox ID="add" runat="server" CssClass="login_txt"></asp:TextBox>
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                            <tr>
                                <td width="100" align="right" height="30">
                                    
                                </td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" Text="注册" OnClientClick="javascript:return r();" OnClick="Button2_Click" />
                                </td>
                                <td width="170">
                                </td>
                            </tr>
                        </table>
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
