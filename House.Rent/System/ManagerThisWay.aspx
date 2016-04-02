<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerThisWay.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <title></title>
    <link href="css/login.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script language="javascript" type="text/javascript">

        function kong() {
            var username = document.getElementById("txtUserName");
            var pwd = document.getElementById("txtPwd");
            var txtPng = document.getElementById("txtPng");

            if (username.value == "") {
                alert("请输入用户名!");
                username.focus();
                return false;
            }
            else if (pwd.value == "") {
                alert("请输入密码!");
                pwd.focus();
                return false;
            }
            else if (txtPng.value == "") {
                alert("请输入验证码!");
                txtPng.focus();
                return false;
            }
            else if (txtPng.value.toLowerCase() != GetAsaiCookie("CheckCode").toLowerCase()) {
                alert("您输入的验证码不正确！");
                document.getElementById('imgcode').click();
                txtPng.value = "";
                txtPng.focus();
                return false;
            }
        }
        //读取cookies
        function GetAsaiCookie(name) {
            var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
            if (arr = document.cookie.match(reg)) return unescape(arr[2]);
            else return null;
        }
    </script>
    
    <script type="text/javascript">
        $(function () {
            var tab2 = $("#tab2");

            tab2.css({
                "height": document.documentElement.clientHeight - 104 + "px"
            });
            //tab2.style.height = document.documentElement.clientHeight - 104 + "px";
            var top = $("#top");
            top.css({
                "height": document.documentElement.clientHeight - 404 + "px"
            });
            //top.style.height = document.documentElement.clientHeight - 404 + "px";
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="div1">
            <table id="login" cellspacing="0" cellpadding="0" width="800" align="center">
                <tbody>
                    <tr id="main">
                        <td>
                            <table id="tab2" cellspacing="0" cellpadding="0" width="100%">
                                <tbody>
                                    <tr id="top">
                                        <td colspan="4">
                                            &nbsp;</td>
                                    </tr>
                                    <tr height="30">
                                        <td width="380">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr height="40">
                                        <td rowspan="4">
                                            &nbsp;</td>
                                        <td>
                                            用户名：</td>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" Width="120px" BorderWidth="0px" Height="18px"
                                                ForeColor="#6085A2" MaxLength="20"></asp:TextBox>
                                        </td>
                                        <td width="120">
                                            &nbsp;</td>
                                    </tr>
                                    <tr height="40">
                                        <td>
                                            密 码：</td>
                                        <td>
                                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="120px" BorderWidth="0px"
                                                ForeColor="#6085A2" MaxLength="20"></asp:TextBox>
                                        </td>
                                        <td width="120">
                                            &nbsp;</td>
                                    </tr>
                                    <tr height="40">
                                        <td>
                                            验证码：</td>
                                        <td valign="center" colspan="2">
                                            <div style="position: relative;">
                                                <asp:TextBox ID="txtPng" runat="server" Width="120px" BorderWidth="0px" Height="18px"
                                                    ForeColor="#6085A2" MaxLength="5"></asp:TextBox>
                                                &nbsp;
                                                <div id="divpng" style="position: absolute; width: 100px; height: 30px; top: 1px;
                                                    left: 123px;">
                                                    <div style="float: left; width: 5px;">
                                                    </div>
                                                    <img src="../verifycode.aspx" id="imgcode" onclick="this.src='../verifycode.aspx?rad='+Math.random();"
                                                        border="0" style="cursor: pointer;" alt="看不清？点击更换" />
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr height="40">
                                        <td>
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnLogin" runat="server" Text="" CssClass="btn_2k3" OnClick="btnLogin_Click"
                                                OnClientClick="javascript:return kong();" />
                                        </td>
                                        <td width="120">
                                            &nbsp;</td>
                                    </tr>
                                    <tr height="110">
                                        <td colspan="4">
                                            &nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr id="root" height="104">
                        <td>
                            &nbsp;</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id="div2" style="display: none">
        </div>      

    </form>


    

</body>
</html>
