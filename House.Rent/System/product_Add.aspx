<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_Add.aspx.cs" Inherits="System_Sys_Member_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <title>房源管理</title>
    <link type="text/css" href="css/grid.css" rel="stylesheet" />

    <script type="text/javascript" src="js/color.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
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
                                                            <img src="images/tb.gif" width="16" height="16" />
                                                        </div>
                                                    </td>
                                                    <td width="97%">
                                                        <b>你当前的位置</b></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="10%"></td>
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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#b5d6e6" class="grid" height="250">
                        <tr>
                            <td width="8" style="background: url(images/tab_12.gif) repeat-y;">&nbsp;</td>
                            <td>
                                <table width="90%">
                                    <tr>
                                        <td width="80" align="right" height="30">标题：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="title" runat="server" CssClass="login_txt" MaxLength="200"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="a1" runat="server">
                                        <td width="80" align="right" height="30">户型：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="name" runat="server" CssClass="login_txt" MaxLength="200"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="80" align="right" height="30">类型：
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_yi" runat="server">                                                
                                                <asp:ListItem Value="1">出租房源</asp:ListItem>
                                                <asp:ListItem Value="2">出售房源</asp:ListItem>
                                                <asp:ListItem Value="4">预租房源</asp:ListItem>
                                                <asp:ListItem Value="5">求购房源</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hidclsid" runat="server" />
                                        </td>
                                    </tr>
                                    <tr id="a2" runat="server">
                                        <td width="80" align="right" height="30">图片：
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <asp:HiddenField ID="edit" runat="server" />
                                        </td>
                                    </tr>
                                    <tr id="a3" runat="server">
                                        <td width="80" align="right" height="30">售价：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pri" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="a4" runat="server">
                                        <td width="80" align="right" height="30">面积：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="num" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="a5" runat="server">
                                        <td width="80" align="right" height="30">电话：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tel" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="a6" runat="server">
                                        <td width="80" align="right" height="30">QQ：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="qq" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="a7" runat="server">
                                        <td width="80" align="right" height="30">房屋地址：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="add" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="a8" runat="server">
                                        <td align="right" height="30" width="80">小区：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                                    </tr>
                                    <tr id="a9" runat="server">
                                        <td align="right" height="30" width="80">装修：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                                    </tr>
                                    <tr id="a10" runat="server">
                                        <td align="right" height="30" width="80">总楼层：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                                    </tr>
                                    <tr id="a11" runat="server">
                                        <td align="right" height="30" width="80">所在楼层：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                                    </tr>
                                    <tr id="a12" runat="server">
                                        <td align="right" width="80" style="height: 20px">朝向：</td>
                                        <td style="height: 20px">
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                                    </tr>
                                    <tr id="a13" runat="server">
                                        <td align="right" height="30" width="80">楼龄：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                                    </tr>
                                    <tr id="a14" runat="server">
                                        <td align="right" height="30" width="80">用途：</td>
                                        <td>
                                            <asp:TextBox ID="TextBox7" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td width="80" align="right" height="30">介绍：
                                        </td>
                                        <td>
                                            <asp:TextBox ID="intro" runat="server" CssClass="login_txt" MaxLength="20" TextMode="MultiLine" Height="100px" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" OnClientClick="javascript:return kong();" /></td>
                            <td width="8" style="background: url(images/tab_15.gif) right repeat-y;">&nbsp;</td>
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
                                    &nbsp;
                                </div>
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
