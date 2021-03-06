﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_Add.aspx.cs" Inherits="product_Add" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/menuleft.ascx" TagName="menuleft" TagPrefix="uc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>房源管理</title>

    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/content.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/color.js"></script>
    <script type="text/javascript" src="js/cls.js"></script>
</head>
<body>

    <form id="form1" runat="server">

        <div id="container" class="container">
            <uc1:top ID="Top1" runat="server" />

            <div class="content">

                <div class="ScntL">
                    <uc1:menuleft ID="menuleft1" runat="server" />
                </div>
                <div class="ScntR">
                    <div class="ScntR_title">
                        <span class="ScntR_title1">
                            <img src="images/icon4.gif" align="absmiddle" alt="" style="margin-right: 8px;" />
                            发布租房信息
                        </span>
                        <span class="ScntR_title2">你现在的位置：
                            <a href="/">首页&nbsp;&gt;&nbsp;</a>
                            <a href="member_buy_add.aspx<%=Request["id"]!=null?"?id="+Request["id"]:"" %>"><%=Request["id"]!=null?"修改":"添加" %>租房信息</a>
                        </span>
                    </div>
                    <div class="productsBox">

                        <table width="90%">
                            <tr>
                                <td align="right" height="30">标题：
                                </td>
                                <td>
                                    <asp:TextBox ID="title" runat="server" CssClass="login_txt" MaxLength="200"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="a1" runat="server">
                                <td align="right" height="30">户型：
                                </td>
                                <td>
                                    <asp:TextBox ID="name" runat="server" CssClass="login_txt" MaxLength="200"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" height="30">类型：
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_yi" runat="server">
                                        <asp:ListItem Value="1">出租房源</asp:ListItem>
                                        <asp:ListItem Value="2">出售房源</asp:ListItem>
                                        <asp:ListItem Value="4">求租房源</asp:ListItem>
                                        <asp:ListItem Value="5">求购房源</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hidclsid" runat="server" />
                                </td>
                            </tr>
                            <tr id="a2" runat="server">
                                <td align="right" height="30">图片：
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:HiddenField ID="edit" runat="server" />
                                </td>
                            </tr>
                            <tr id="a3" runat="server">
                                <td align="right" height="30">
                                    租金/售价：
                                </td>
                                <td>
                                    <asp:TextBox ID="pri" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="a4" runat="server">
                                <td align="right" height="30">面积：
                                </td>
                                <td>
                                    <asp:TextBox ID="num" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="a5" runat="server">
                                <td align="right" height="30">电话：
                                </td>
                                <td>
                                    <asp:TextBox ID="tel" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="a6" runat="server">
                                <td align="right" height="30">QQ：
                                </td>
                                <td>
                                    <asp:TextBox ID="qq" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="a7" runat="server">
                                <td align="right" height="30">房屋地址：
                                </td>
                                <td>
                                    <asp:TextBox ID="add" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="a8" runat="server">
                                <td align="right" height="30">小区：</td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                            </tr>
                            <tr id="a9" runat="server">
                                <td align="right" height="30">装修：</td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                            </tr>
                            <tr id="a10" runat="server">
                                <td align="right" height="30">总楼层：</td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                            </tr>
                            <tr id="a11" runat="server">
                                <td align="right" height="30">所在楼层：</td>
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                            </tr>
                            <tr id="a12" runat="server">
                                <td align="right" style="height: 20px">朝向：</td>
                                <td style="height: 20px">
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                            </tr>
                            <tr id="a13" runat="server">
                                <td align="right" height="30">楼龄：</td>
                                <td>
                                    <asp:TextBox ID="TextBox6" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                            </tr>
                            <tr id="a14" runat="server">
                                <td align="right" height="30">用途：</td>
                                <td>
                                    <asp:TextBox ID="TextBox7" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" height="30">介绍：
                                </td>
                                <td>
                                    <asp:TextBox ID="intro" runat="server" CssClass="login_txt" MaxLength="20" TextMode="MultiLine" Height="100px" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" OnClientClick="javascript:return kong();" /></td>
                            </tr>
                        </table>
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
