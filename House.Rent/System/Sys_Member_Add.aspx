<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sys_Member_Add.aspx.cs" Inherits="System_Sys_Member_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <title>会员管理</title>
    <link type="text/css" href="css/grid.css" rel="stylesheet" />

    <script type="text/javascript" src="js/color.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" background="images/tab_05.gif">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12" height="30">
                                <img src="images/tab_03.gif" width="12" height="30" /></td>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="90%" valign="middle">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="3%">
                                                        <div align="center">
                                                            <img src="images/tb.gif" alt="" width="16" height="16" /></div>
                                                    </td>
                                                    <td width="97%">
                                                        <b>你当前的位置</b>：[<a href="sys_member_list.aspx">会员管理</a>] - [<a href="sys_member_add.aspx">添加会员</a>]</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="10%">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="16">
                                <img src="images/tab_07.gif" width="16" height="30" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="8" style="background: url(images/tab_12.gif) repeat-y;">
                                &nbsp;</td>
                            <td>
                                <table width="98%" border="0" cellpadding="0" cellspacing="1" bgcolor="#b5d6e6" class="grid"
                                    height="250" style="margin-top:10px;">
                                    <tr>
                                        <td style="height: 30px; width: 100px;">
                                            帐号：</td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="txt_user" runat="server" CssClass="text" Width="271px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_user"
                                                ErrorMessage="请填写用户名！" ValidationGroup="btn"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 30px">
                                            密码：</td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="txt_pwd" runat="server" CssClass="text" TextMode="Password"
                                                Width="270px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pwd"
                                                ErrorMessage="请填写密码！" ValidationGroup="btn"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 30px">
                                            确认密码：</td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="txt_pwd_re" runat="server" CssClass="text" TextMode="Password"
                                                Width="270px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_pwd_re"
                                                ErrorMessage="请再次填写密码！" ValidationGroup="btn"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_pwd"
                                                ControlToValidate="txt_pwd_re" ErrorMessage="两次输入的密码不一致！" ValidationGroup="btn"></asp:CompareValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px; width: 100px;">
                                            电话：</td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="tel" runat="server" CssClass="text" Width="271px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px; width: 100px;">
                                            地址：</td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="add" runat="server" CssClass="text" Width="271px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px; width: 100px;">
                                            QQ：</td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="qq" runat="server" CssClass="text" Width="271px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 35px">
                                            <asp:Button ID="Button1" runat="server" Text=" 添 加 " CssClass="btn_blue" ValidationGroup="btn"
                                                OnClick="Button1_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="8" style="background: url(images/tab_15.gif) right repeat-y;">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="35" background="images/tab_19.gif">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="12" height="35">
                                <img src="images/tab_18.gif" width="12" height="35" /></td>
                            <td style="color: #03515d; height: 18px;">
                                <!--分页处开始-->
                                <div style="width: 100%">
                                    &nbsp;</div>
                                <!--分页处结束-->
                            </td>
                            <td width="16">
                                <img src="images/tab_20.gif" width="16" height="35" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
