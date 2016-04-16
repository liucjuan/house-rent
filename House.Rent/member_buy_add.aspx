<%@ Page Language="C#" AutoEventWireup="true" CodeFile="member_buy_add.aspx.cs" Inherits="member_pro_add" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/menuleft.ascx" TagName="menuleft" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题页</title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/content.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/cls.js"></script>

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
                            <img src="images/icon4.gif" align="absmiddle" style="margin-right: 8px;" />求购信息</span>
                        <span class="ScntR_title2">你现在的位置：<a href="/">首页&nbsp;&gt;&nbsp;</a><a href="member_buy_add.aspx<%=Request["id"]!=null?"?id="+Request["id"]:"" %>"><%=Request["id"]!=null?"修改":"添加" %>求购信息</a></span></div>
                    <div class="productsBox">
                        <div class="newLxt0">
                            <table width="90%">
                                <tr>
                                    <td width="80" align="right" height="30">
                                        标题：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="title" runat="server" CssClass="login_txt" MaxLength="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80" align="right" height="30">
                                        物品名称：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="name" runat="server" CssClass="login_txt" MaxLength="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
<%--                                    <td width="80" align="right" height="30">
                                        分类：
                                    </td>--%>
<%--                                    <td>
                                        <asp:DropDownList ID="ddl_yi" runat="server" onchange="loadcls('ddl_er',this.value,'二级分类');">
                                            <asp:ListItem Value="0">请选择一级分类</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_er" runat="server">
                                            <asp:ListItem Value="0">请选择二级分类</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hidclsid" runat="server" />

                                        <script type="text/javascript">loadcls("ddl_yi",0,"一级分类");show();</script>

                                    </td>--%>
                                </tr>
                                <tr >
                                    <td width="80" align="right" height="30">
                                        图片：
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:HiddenField ID="edit" runat="server" />
                                    </td>
                                </tr>
                                <tr style="display:none;">
                                    <td width="80" align="right" height="30">
                                        价格：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="pri" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display:none;">
                                    <td width="80" align="right" height="30">
                                        数量：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="num" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80" align="right" height="30">
                                        电话：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tel" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80" align="right" height="30">
                                        QQ：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="qq" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80" align="right" height="30">
                                        地址：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="add" runat="server" CssClass="login_txt" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80" align="right" height="30">
                                        简介：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="intro" runat="server" CssClass="login_txt" MaxLength="20" TextMode="MultiLine" Height="100px" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" OnClientClick="javascript:return kong();" />
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
