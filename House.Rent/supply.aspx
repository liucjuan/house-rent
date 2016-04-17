<%@ Page Language="C#" AutoEventWireup="true" CodeFile="supply.aspx.cs" Inherits="supply" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
                <div>
                    <img src="images/img/1459491039032.png" alt="" />
                </div>

                <%--<div class="houseList">

                    <dl class="list hiddenMap rel">
                        <dt class="img rel floatl">
                            <a target="_blank" href="/chuzu/1_51435286_-1.htm" class="">
                                <img class="b-lazy b-loaded" alt="" src="http://imgs.soufun.com/viewimage/house/2010_07/31/suzhou/1280557384445_000/275x207.jpg" />
                            </a>
                            <p class="txtBg">
                            </p>
                        </dt>
                        <dd class="info rel">
                            <p class="title">
                                <a href="/chuzu/1_51435286_-1.htm" target="_blank" title="园区湖东湖畔天城 次卧带空调急出租">园区湖东湖畔天城 次卧带空调急出租</a>
                            </p>
                            <p class="font16 mt20 bold">
                                合租次卧<span class="splitline">|</span>5户合租<span class="splitline">|</span>15㎡<span class="splitline">|</span>12/23层<span class="splitline">|</span>朝南北
                            </p>
                            <p class="gray6 mt20"><a href="/house-a0277/" target="_blank"><span>园区</span></a>-<a href="/house-a0277-b04000/" target="_blank"><span>湖东</span></a>-<a href="/house-xm1822064721/" target="_blank"><span>湖畔天城</span></a> </p>
                            <p class="mt12"><span class="note subInfor">距1号线<a href="/house1-j0120-k01929/">南施街</a>约895米。</span></p>
                            <p class="gray6 mt15" style="line-height: 16px;">
                                <span class="gray9 pr10">48秒前更新</span>
                            </p>
                            <div class="moreInfo">
                                <p class="mt5 alingC"><span class="price">680</span>元/月</p>
                            </div>
                        </dd>
                    </dl>                

                    <div class="clear">
                    </div>
                </div>--%>

                <div class="houseList">

                    <asp:Repeater ID="rep_list" runat="server">
                        <ItemTemplate>
                            <%--<li><span class="no"><a href="supply-display.aspx?id=<%#Eval("pro_id") %>" target="_blank"
                                title="<%#Eval("pro_title") %>">
                                <%#CommonLib.CutString.CutWithSubstring(Eval("pro_title").ToString(),30) %>
                            </a></span><span class="lxtDate">
                                <%#Eval("pro_date","{0:yyyy-MM-dd}") %>
                            </span></li>--%>

                            <dl class="list hiddenMap rel">
                                <dt class="img rel floatl <%#Eval("pro_type").ToString() == "3"?"none":"" %>">
                                    <a target="_blank" href="supply-display.aspx?id=<%#Eval("pro_id") %>" class="">
                                        <img class="b-lazy b-loaded" alt="" src="<%#System.IO.File.Exists(Server.MapPath("upload/"+Eval("pro_img")))?"upload/"+Eval("pro_img"):"images/no-img.gif" %>" />
                                    </a>
                                </dt>
                                <dd class="info rel <%#Eval("pro_type").ToString() == "3"?"znxw":"" %>">
                                    <p class="title">
                                        <a href="supply-display.aspx?id=<%#Eval("pro_id") %>" target="_blank" title="<%#Eval("pro_title") %>"><%#Eval("pro_title") %></a>
                                    </p>
                                    <p class="font16 mt20 bold <%#Eval("pro_type").ToString() == "3"?"none":"" %>">
                                        <%#Eval("pro_name") %><span class="splitline">|</span><%#Eval("pro_num") %>㎡<span class="splitline">|</span><%#Eval("zx") %><span class="splitline">|</span><%#Eval("szlc") %>/<%#Eval("zlc") %>层<span class="splitline">|</span>朝<%#Eval("cx") %>
                                    </p>
                                    <p class="gray6 mt20"><span><%#Eval("xq") %></span> </p>
                                    <p class="mt12"><span class="note subInfor"><%#Eval("pro_add") %></span></p>
                                    <p class="gray6 mt15" style="line-height: 16px;">
                                        <span class="gray9 pr10"><%#Eval("pro_date","{0:yyyy-MM-dd hh:mm:ss}") %>更新</span>
                                    </p>
                                    <div class="moreInfo <%#Eval("pro_type").ToString() == "3"?"none":"" %>">
                                        <p class="mt5 alingC"><span class="price"><%#Eval("pro_pri") %></span>元/月</p>
                                    </div>
                                </dd>
                            </dl>


                        </ItemTemplate>
                    </asp:Repeater>                    

                    <div class="clear">
                    </div>
                </div>
                <div class="pages">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                        PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowCustomInfoSection="Left"
                        ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到"
                        PageSize="15">
                    </webdiyer:AspNetPager>
                </div>

                <%--<div class="newLxt0">
                    <ul class="newLxt">
                        <asp:Repeater ID="rep_list" runat="server">
                            <ItemTemplate>
                                <li><span class="no"><a href="supply-display.aspx?id=<%#Eval("pro_id") %>" target="_blank"
                                    title="<%#Eval("pro_title") %>">
                                    <%#CommonLib.CutString.CutWithSubstring(Eval("pro_title").ToString(),30) %>
                                </a></span><span class="lxtDate">
                                    <%#Eval("pro_date","{0:yyyy-MM-dd}") %>
                                </span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="pages">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                            PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowCustomInfoSection="Left"
                            ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到"
                            PageSize="15">
                        </webdiyer:AspNetPager>
                    </div>
                </div>--%>

                <%--<div class="newLxt0">
                    <ul class="newLxt">
                        <asp:Repeater ID="rep_list" runat="server">
                            <ItemTemplate>
                                <li><span class="no"><a href="supply-display.aspx?id=<%#Eval("pro_id") %>" target="_blank"
                                    title="<%#Eval("pro_title") %>">
                                    <%#CommonLib.CutString.CutWithSubstring(Eval("pro_title").ToString(),30) %>
                                </a></span><span class="lxtDate">
                                    <%#Eval("pro_date","{0:yyyy-MM-dd}") %>
                                </span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="pages">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条"
                            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                            PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowCustomInfoSection="Left"
                            ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到"
                            PageSize="15">
                        </webdiyer:AspNetPager>
                    </div>
                </div>--%>
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
