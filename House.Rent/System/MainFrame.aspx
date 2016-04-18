<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainFrame.aspx.cs" Inherits="System_MainFrame" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" type="text/css" rel="stylesheet" />
    <link href="css/style_left.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script language="javaScript" src="js/menu.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <!--导航部分-->
        <div class="top_table">
            <div class="top_table_leftbg">
                <div class="system_logo">
                    <%--<img src="images/logo.gif">--%>
                </div>
                <div class="menu">
                    <ul>
                        <li id="menu_0" onclick="getleftbar(this,'sys_manager_list.aspx');"><a>后台管理员</a>
                            <div class="menu_childs">
                                <ul>
                                    <li><a href="sys_manager_add.aspx" target="frmright">添加管理员</a></li>
                                    <li><a href="sys_manager_list.aspx" target="frmright">管理员管理</a></li>
                                    <li><a href="sys_revise_pwd.aspx" target="frmright">修改密码</a></li>
                                </ul>
                            </div>
                            <div class="menu_div">
                            </div>
                        </li>
                        <li id="menu_1" onclick="getleftbar(this,'sys_member_list.aspx');"><a>会员管理</a>
                            <div class="menu_childs">
                                <ul>
                                    <%--   <li><a href="sys_member_add.aspx" target="frmright">添加会员</a></li>--%>
                                    <li><a href="sys_member_list.aspx" target="frmright">会员列表</a></li>
                                </ul>
                            </div>
                            <div class="menu_div">
                            </div>
                        </li>
                        <li id="menu_2" onclick="getleftbar(this,'sys_product_list.aspx');"><a>房源管理</a>
                            <div class="menu_childs">
                                <ul>
                                    <li><a href="sys_product_list.aspx" target="frmright">房源管理</a></li>
                                </ul>
                            </div>
                            <div class="menu_div">
                            </div>
                        </li>
                        <li id="menu_3" onclick="getleftbar(this,'xw_list.aspx?cls=3');"><a>站内新闻</a>
                            <div class="menu_childs">
                                <ul>
                                    <li><a href="xw_list.aspx?cls=3" target="frmright">站内新闻</a></li>
                                    <li><a href="xw_Add.aspx?cls=9" target="frmright">发布站内新闻</a></li>
                                </ul>
                            </div>
                            <div class="menu_div">
                            </div>
                        </li>


                        <li id="Li2" onclick="getleftbar(this,'ly_List.aspx');"><a>留言管理</a>
                            <div class="menu_childs">
                                <ul>
                                    <li><a href="ly_List.aspx" target="frmright">留言管理</a></li>
                                </ul>
                            </div>
                            <div class="menu_div">
                            </div>
                        </li>
                        <%--<li id="menu_4" onclick="getleftbar(this,'sys_log_list.aspx');"><a href="sys_log_list.aspx" target="frmright">租房记录</a>
                            <div class="menu_childs">
                                <ul>
                                    <li><a href="sys_log_list.aspx" target="frmright">租房记录</a></li>
                                </ul>
                            </div>
                            <div class="menu_div">
                            </div>
                        </li>--%>
                        <li id="menu_6" onclick="getleftbar(this,'sys_revise_pwd.aspx');"><a>修改密码</a>
                            <div class="menu_childs">
                                <ul>
                                    <li><a href="sys_revise_pwd.aspx" target="frmright">修改密码</a></li>
                                </ul>
                            </div>
                            <div class="menu_div">
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div style="background: #337abb; height: 24px">
        </div>
        <!--导航部分结束-->
        <table style="background: #337abb" cellspacing="0" cellpadding="0" width="100%" border="0"
            id="tab">
            <tbody>
                <tr>
                    <td class="main_left" id="frmTitle" valign="top" align="middle" name="fmTitle">
                        <table class="main_left_top" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr height="32">
                                    <td valign="top"></td>
                                    <td class="main_left_title" id="leftmenu_title">常用快捷功能</td>
                                    <td valign="top" align="right"></td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellspacing="0" cellpadding="0" class="left_iframe" border="0">
                            <tbody>
                                <tr>
                                    <td style="padding-top: 10px" valign="top">
                                        <table class="alpha">
                                            <tbody>
                                                <tr>
                                                    <td class="menu_l" id="menubar" valign="top">
                                                        <ul>
                                                            <li><a href="sys_manager_list.aspx" target="frmright">管理员管理</a></li>
                                                            <li><a href="sys_revise_pwd.aspx" target="frmright">修改密码</a></li>
                                                            <li><a href="sys_product_list.aspx?cls=1" target="frmright">物品列表</a></li>
                                                        </ul>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="copyright"></td>
                                </tr>
                                <tr>
                                    <td class="copyright"></td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr height="32">
                                    <td valign="top"></td>
                                    <td valign="bottom" align="middle"></td>
                                    <td valign="top" align="right"></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td style="width: 10px" bgcolor="#337abb">
                        <table height="100%" cellspacing="0" cellpadding="0" border="0">
                            <tbody>
                                <tr>
                                    <td style="height: 100%" onclick="switchSysBar()">
                                        <span class="navPoint" id="switchPoint" title="关闭/打开左栏">
                                            <img src="images/right.gif"></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top" width="100%" bgcolor="#337abb">
                        <table cellspacing="0" cellpadding="0" width="100%" bgcolor="#c4d8ed" border="0">
                            <tbody>
                                <tr style="height: 32px;">
                                    <td valign="top" width="10" background="images/bg2.gif">
                                        <img alt="" src="images/teble_top_left.gif"></td>
                                    <td width="28" background="images/bg2.gif"></td>
                                    <td background="images/bg2.gif"></td>
                                    <td style="color: #135294; text-align: right" background="images/bg2.gif">欢迎您，
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        管理员&nbsp; |
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">安全退出</asp:LinkButton>
                                        <%--| <a href="javascript:void(0);" onclick="parent.opener=null;window.close();">关闭窗口</a>--%>
                                    </td>
                                    <td valign="top" align="right" width="28" background="images/bg2.gif">
                                        <img alt="" src="images/teble_top_right.gif"></td>
                                    <td align="right" width="16" bgcolor="#337abb"></td>
                                </tr>
                            </tbody>
                        </table>
                        <iframe class="main_iframe" id="frmright" name="frmright" src="sys_manager_List.aspx"
                            frameborder="0"></iframe>
                        <table style="background: #c4d8ed" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <img height="6" alt="" src="images/teble_bottom_left.gif" width="5"></td>
                                    <td align="right">
                                        <img height="6" alt="" src="images/teble_bottom_right.gif" width="5"></td>
                                    <td align="right" width="16" bgcolor="#337abb"></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>

        <script type="text/javascript">
            var tab = document.getElementById("tab");
            tab.style.height = document.body.clientHeight - 67 + "px";

            var status = 1;
            var Menus = new DvMenuCls;
            document.onclick = Menus.Clear;
            function switchSysBar() {
                if (1 == window.status) {
                    window.status = 0;
                    switchPoint.innerHTML = '<img src="images/left.gif">';
                    document.all("frmTitle").style.display = "none"
                }
                else {
                    window.status = 1;
                    switchPoint.innerHTML = '<img src="images/right.gif">';
                    document.all("frmTitle").style.display = ""
                }
            }
        </script>

    </form>
</body>
</html>
