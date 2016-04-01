<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首页</title>
    <%--<link href="css/style.css" rel="stylesheet" type="text/css" />--%>

    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/index.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <uc1:top ID="Top1" runat="server" />
            <div id="content" class="content">
                <div class="CntL">
                    <div class="newBox">
                        <div class="newTitle">
                            <div class="newTitle1">
                                <a href="supply.aspx?cls=1" target="_blank">出租房源</a>
                            </div>
                            <div class="newTitle2">
                                <a href="supply.aspx?cls=1" target="_blank">
                                    <img src="images/icon3.gif" alt="more" /></a>
                            </div>
                        </div>
                        <div class="newCnt">
                            <ul>
                                <asp:Repeater ID="rep_pro1" runat="server">
                                    <ItemTemplate>
                                        <li><a href="supply-display.aspx?id=<%#Eval("pro_id") %>" target="_blank" title="<%#Eval("pro_title") %>">
                                            <%#CommonLib.CutString.CutWithSubstring(Eval("pro_title").ToString(),14) %>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="CntR">
                    <div class="CntR_Top">
                        <div class="gsjjBox">
                            <div class="gsjjTitle">
                                <div class="gsjjTitle1">
                                    <a href="supply.aspx?cls=3" target="_blank">站内新闻</a>
                                </div>
                                <div class="more">
                                    <a href="supply.aspx?cls=2" target="_blank">
                                        <img src="images/icon3.gif" alt="more" /></a>
                                </div>
                            </div>
                            <div class="gsjjCnt">
                                <ul>
                                    <asp:Repeater ID="rep_pro2" runat="server">
                                        <ItemTemplate>
                                            <li><span class="li02"><a href="supply-display.aspx?id=<%#Eval("pro_id") %>" title="<%#Eval("pro_title") %>"
                                                target="_blank">
                                                <%#CommonLib.CutString.CutWithSubstring(Eval("pro_title").ToString(),20) %>
                                            </a></span><span class="liDate2">
                                                <%#Eval("pro_date","{0:yyyy-MM-dd}") %>
                                            </span></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                        <div class="recruitBox">
                            <div class="reTitle">
                                <div class="gsjjTitle1">
                                    <a href="supply-display.aspx?cls=1" target="_blank">出租房源</a>
                                </div>
                                <div class="more">
                                    <a href="buy.aspx" target="_blank">
                                        <img src="images/icon3.gif" alt="more" /></a>
                                </div>
                            </div>
                            <div class="recruitCnt">
                                <ul>
                                    <asp:Repeater ID="rep_pro3" runat="server">
                                        <ItemTemplate>
                                            <li><span class="li01"><a href="supply-display.aspx?id=<%#Eval("pro_id") %>" title="<%#Eval("pro_title") %>"
                                                target="_blank">
                                                <%#CommonLib.CutString.CutWithSubstring(Eval("pro_title").ToString(),8) %>
                                            </a></span><span class="liDate">
                                                <%#Eval("pro_date","{0:yyyy-MM-dd}") %>
                                            </span></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="Products">
                        <div class="gsjjTitle">
                            <div class="gsjjTitle1"><a href="javascript:void(0);">房产图片</a></div>
                            <div class="more">
                                <img src="images/icon3.gif" alt="more" />
                            </div>                            
                        </div>
                        <div class="ProLxt">
                            <div id="HotLeft4" class="show_pro2" style="overflow: hidden">
                                <ul>
                                    <asp:Repeater ID="rep_pro4" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <img src="<%#System.IO.File.Exists(Server.MapPath("upload/"+Eval("pro_img")))?"upload/"+Eval("pro_img"):"images/no-img.gif" %>"
                                                    alt="<%#Eval("pro_title") %>" width="148" height="115" />
                                                <span>
                                                    <%#CommonLib.CutString.CutWithSubstring(Eval("pro_title").ToString(),8) %>
                                                </span></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
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

    <script src="js/YLMarquee-1.1.js" type="text/javascript"> </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#HotLeft4").YlMarquee({
                visible: 3,
                step: 1,
                width: 740
            });
        });

    </script>
</body>
</html>
