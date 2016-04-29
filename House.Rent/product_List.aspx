<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_List.aspx.cs" Inherits="product_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="controls/menuleft.ascx" TagName="menuleft" TagPrefix="uc1" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>房源管理</title>
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <link href="css/content.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/quanxuan.js"></script>

    <script type="text/javascript" src="js/color.js"></script>

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
                        <asp:HiddenField ID="hid" runat="server" />

                        <table border="0" style="margin-top: 10px; font-size: 12px; text-indent: 3px; width:100%;">
                            <tr>
                                <td colspan="2" style="padding: 10px;">房源类别:
                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="157px">
                                        <asp:ListItem Value="1" Selected="True">出租房源</asp:ListItem>
                                        <asp:ListItem Value="2">出售房源</asp:ListItem>
                                        <asp:ListItem Value="4">求租房源</asp:ListItem>
                                        <asp:ListItem Value="5">求售房源</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
                                    <asp:GridView ID="GridView1" runat="server" CssClass="grid" AutoGenerateColumns="False"
                                        Width="100%" BorderWidth="0px" CellPadding="0" CellSpacing="0"
                                        onmouseover="changeto()" onmouseout="changeback()" OnRowCommand="rep_list_ItemCommand">
                                        <Columns>
                                            <asp:BoundField DataField="pro_id" HeaderText="编号">
                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="标题">
                                                <ItemTemplate>
                                                    <a href="product_Add.aspx?id=<%#Eval("pro_id") %>" target="frmright"><%#Eval("pro_title") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="pro_name" HeaderText="房源户型" />

                                            <asp:TemplateField HeaderText="图片">
                                                <ItemTemplate>
                                                    <img alt='<%#Eval("pro_name") %>' src="<%#Eval("pro_img").ToString()!=""?"upload/"+Eval("pro_img"):"images/no-img.gif" %>"  width="80" height="60" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="分类">
                                                <ItemTemplate>
                                                    <%#getclsname(Eval("pro_type").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="发布时间">
                                                <ItemTemplate>
                                                    <%#Eval("pro_date","{0:d}")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="操作">
                                                <ItemTemplate>
                                                    <a href="product_Add.aspx?id=<%#Eval("pro_id") %>" target="frmright">修改</a>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("pro_id") %>'
                                                    CommandName="del" OnClientClick='javascript:return confirm("确定删除？");'>删除</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="top_tr" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <!--分页处开始-->
                        <div style="width: 98%; float: left;">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页，每页%PageSize%条"
                                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                PageIndexBoxType="DropDownList" PrevPageText="上一页" ShowCustomInfoSection="Left"
                                ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到"
                                PageSize="5">
                            </webdiyer:AspNetPager>
                        </div>
                        <div style="width: 1%; float: left;">
                            &nbsp;
                        </div>
                        <!--分页处结束-->
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
