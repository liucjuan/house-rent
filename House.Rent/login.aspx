<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员登录</title>
    <link href="css/mSlider.css" rel="stylesheet" type="text/css" />
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/content.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.12.2.js"></script>
    <script src="js/jquery.slides.js"></script>
    <script type="text/javascript">

        $(function () {
            //$('#slides2').slidesjs({
            //    width: 940,
            //    height: 400,
            //    navigation: false,
            //    start: 3,
            //    play: {
            //        auto: true
            //    }
            //});
        });

        function l() {
            var user = document.getElementById("login_user");
            var pwd = document.getElementById("login_pwd");
            if (user.value == "") {
                alert("请输入用户名");
                user.focus();
                return false;
            }
            if (pwd.value == "") {
                alert("请输入密码");
                pwd.focus();
                return false;
            }
        }
        function r() {
            var user = document.getElementById("r_user");
            var pwd = document.getElementById("r_pwd");
            var pwd2 = document.getElementById("r_pwd2");
            if (user.value == "") {
                alert("请输入用户名");
                user.focus();
                return false;
            }
            if (pwd.value == "") {
                alert("请输入密码");
                pwd.focus();
                return false;
            }
            if (pwd2.value == "") {
                alert("请重新输入密码");
                pwd2.focus();
                return false;
            }
            else if (pwd2.value != pwd.value) {
                alert("您输入的密码不一致");
                pwd2.focus();
                return false;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="container" class="container">
            <uc1:top ID="Top1" runat="server" />
            <div class="login-cont">
                <div id="content" class="content">
                    <div class="left_content">
                        <a class="newclub_box" target="_blank" href="javascript:void(0);">
                        <img src="images/img/JWdQrI.jpg" title="321" alt="321" />
                        </a>
<%--                        <div id="slides2">
                          <img src="images/img/1432605356624.jpg" alt="" />
                          <img src="images/img/1450337416483_000.jpg" alt="" />
                          <img src="images/img/1453874574041.jpg" alt="" />
                          <a href="#" class="slidesjs-previous slidesjs-navigation"><i class="icon-chevron-left"></i></a>
                          <a href="#" class="slidesjs-next slidesjs-navigation"><i class="icon-chevron-right"></i></a>
                        </div>--%>
                    </div>
                    <div class="right_content">
                        <div class="login_cont">
                            <div class="login_t">用户登录</div>
                            <dl>
                                <dt>用户名：
                                </dt>
                                <dd>
                                    <asp:TextBox ID="login_user" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                </dd>
                            </dl>
                            <dl>
                                <dt>密码：
                                </dt>
                                <dd>
                                    <asp:TextBox ID="login_pwd" runat="server" CssClass="login_txt" TextMode="Password" MaxLength="20"></asp:TextBox>
                                </dd>
                            </dl>
                            <p class="btn_box">
                                <asp:Button ID="Button1" runat="server" Text="登录" OnClientClick="javascript:return l();" OnClick="Button1_Click" />
                            </p>
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
