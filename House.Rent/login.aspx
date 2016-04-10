<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员登录</title>
    <link href="css/mSlider.css" type="text/css" />
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/fish.1.4.7.js"></script>
    <script type="text/javascript" src="js/mSlider0.4.2.js"></script>

    <script type="text/javascript">

        fish.ready(function () {

            fish.one("#mainslider").mSlider({
                autoScroll: !0,
                moveTime: 1500,
                arrows: !1,
                aniType: "fade",
                showNav: "custom",
                canvas: "#mainslider .bd ul",
                content: "#mainslider .bd li",
                userNav: "#mainslider .menu li"
            });

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
                    <div class="left_content main-slide">
                        <div class="slide" id="mainslider">
                            <div class="bd">
                                <ul id="SliderItems">
                                    <li style="opacity: 0.01; display: none; left: 0px; top: 0px; z-index: 6; position: absolute;">
                                        <a rel="nofollow" target="_blank" href="http://www.ly.com//zhuanti/gnyms" title="舌尖上的旅游节">
                                            <img src="http://pic4.40017.cn/gny/line/2016/03/28/19/l9AkdO.jpg" alt="舌尖上的旅游节" />
                                        </a>
                                    </li>
                                    <li style="opacity: 0.01; display: none; left: 0px; top: 0px; z-index: 5; position: absolute;">
                                        <a rel="nofollow" target="_blank" href="http://www.ly.com/zhuanti/gnyyujianxm" title="遇见厦门">
                                            <img src="http://pic4.40017.cn/gny/line/2016/03/31/14/2RFvjf.jpg" alt="遇见厦门" />
                                        </a>
                                    </li>
                                    <li style="opacity: 1; display: block; left: 0px; top: 0px; z-index: 4; position: absolute;">
                                        <a rel="nofollow" target="_blank" href="http://gny.ly.com/TcSpecialLine/index?refid=154358435" title="同程专线">
                                            <img src="http://pic4.40017.cn/gny/line/2016/03/29/18/mUXQmE.jpg" alt="同程专线" />
                                        </a>
                                    </li>
                                    <li style="opacity: 0.01; display: none; left: 0px; top: 0px; z-index: 3; position: absolute;">
                                        <a rel="nofollow" target="_blank" href="http://www.ly.com/zhuanti/gnyziyouxing" title="偏爱自由行">
                                            <img src="http://pic4.40017.cn/gny/line/2016/03/28/19/Ri3nuY.jpg" alt="偏爱自由行" />
                                        </a>
                                    </li>
                                    <li style="opacity: 0.01; display: none; left: 0px; top: 0px; z-index: 2; position: absolute;">
                                        <a rel="nofollow" target="_blank" href="http://www.ly.com/zhuanti/gnysrnanjing" title="SR南京">
                                            <img src="http://pic4.40017.cn/gny/line/2016/04/08/09/P756Yi.jpg" alt="SR南京" />
                                        </a>
                                    </li>
                                    <li style="opacity: 0.01; display: none; left: 0px; top: 0px; z-index: 1; position: absolute;">
                                        <a rel="nofollow" target="_blank" href="http://gny.ly.com/temai/" title="特卖频道">
                                            <img src="http://pic4.40017.cn/gny/line/2016/04/08/11/eVXZCd.jpg" alt="特卖频道" />
                                        </a>
                                    </li>

                                </ul>
                            </div>
                            <div class="menu">
                                <ul>
                                    <li class="">
                                        <a rel="nofollow" href="javascript:;"></a>
                                    </li>
                                    <li class="">
                                        <a rel="nofollow" href="javascript:;"></a>
                                    </li>
                                    <li class="current">
                                        <a rel="nofollow" href="javascript:;"></a>
                                    </li>
                                    <li class="">
                                        <a rel="nofollow" href="javascript:;"></a>
                                    </li>
                                    <li class="">
                                        <a rel="nofollow" href="javascript:;"></a>
                                    </li>
                                    <li class="">
                                        <a rel="nofollow" href="javascript:;"></a>
                                    </li>
                                </ul>
                            </div>
                        </div>
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
