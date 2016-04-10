<%@ Page Language="C#" AutoEventWireup="true" CodeFile="supply-display.aspx.cs" Inherits="supply_display" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题页</title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/content.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <uc1:top ID="Top1" runat="server" />
            <div id="content" class="content">
                <div class="cont_info">
                    <asp:Repeater ID="rep_intro" runat="server" OnItemDataBound="rep_intro_ItemDataBound" OnItemCommand="rep_intro_ItemCommand">
                        <ItemTemplate>
                            <div class="col-cont title-box" style="z-index: 34;">
                                <h1 class="title-name"><%#Eval("pro_title")%></h1>
                                <div class="title-info clearfix">
                                    <ul class="title-info-l clearfix">
                                        <li><i class="f10 pr-5"><%#Eval("pro_date","{0:d}") %></i>发布</li>
                                        <li>浏览<i id="pageviews" class="f10 pl-5" >20</i>次</li>
                                    </ul>
                                </div>
                            </div>

                            <div class="cpPic" style="height: auto;">
<%--                                <h6>
                                    <%#getcount(Eval("pro_type").ToString())%>
                                </h6>--%>
                                <img src="<%#System.IO.File.Exists(Server.MapPath("upload/"+Eval("pro_img")))?"upload/"+Eval("pro_img"):"images/no-img.gif" %>"
                                    alt="<%#Eval("pro_title") %>" style="max-width: 630px; display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>" />
                            </div>
                            <div class="cpSmg">

                                <%--<p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/buy.png" CommandName="mai" CommandArgument='<%#Eval("pro_id") %>' />
                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("pro_type") %>' />
                                </p>--%>
                                <p>

                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("pro_type") %>' />
                                </p>
                                <%--<p style="display: <%#Eval("pro_type").ToString()=="3"?"block":"none" %>">
                                    标题：<%#Eval("pro_title")%>
                                </p>--%>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    户型：<%#Eval("pro_name") %>
                                </p>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    面积：<%#Eval("pro_num") %> ㎡ 
                                </p>
                                <%--<p>
                                    发布时间：<%#Eval("pro_date","{0:d}") %>
                                </p>--%>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    租金：<%#Eval("pro_pri") %>元/月（押一付三）
                                </p>

                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    小区：<%#Eval("xq")%>
                                </p>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    装修：<%#Eval("zx") %>
                                </p>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    总楼层：<%#Eval("zlc") %>楼
                                </p>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    所在楼层：<%#Eval("szlc") %>楼
                                </p>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    朝向：<%#Eval("cx") %>
                                </p>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    楼龄：<%#Eval("ll") %>年
                                </p>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    用途：<%#Eval("yt") %>
                                </p>


                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    电话：<%#Eval("pro_tel") %>
                                </p>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    QQ：<%#Eval("pro_qq") %>
                                </p>
                                <p style="display: <%#Eval("pro_type").ToString()=="3"?"none":"block" %>">
                                    房屋地址：<%#Eval("pro_add") %>
                                </p>
                                <p>
                                    【详情】
                                </p>
                                <p><%#Eval("pro_intro") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
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
