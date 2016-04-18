<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xw_List.aspx.cs" Inherits="xw_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7">
    <title>站内新闻</title>
    <link type="text/css" href="css/grid.css" rel="stylesheet" />

    <script type="text/javascript" src="js/quanxuan.js"></script>

    <script type="text/javascript" src="js/color.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hid" runat="server" />
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
                                        <td width="46%" valign="middle">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="5%">
                                                        <div align="center">
                                                            <img src="images/tb.gif" width="16" height="16" />
                                                        </div>
                                                    </td>
                                                    <td width="95%">
                                                        <b>你当前的位置</b>：
                                                        [<a href="xw_list.aspx">站内新闻</a>]
                                                        [<a href="xw_Add.aspx">添加站内新闻</a>]
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="54%"></td>
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
                            <td width="8" style="background: url(images/tab_12.gif) repeat-y;">&nbsp;</td>
                            <td>
                                <table align="center" bgcolor="#b0d0f3" border="0" cellpadding="4" cellspacing="1"
                                    width="98%" style="margin-top: 10px; font-size: 12px; text-indent: 3px;">
                                    <tr bgcolor="#ffffff">
                                        <td height="32" colspan="2" style="padding: 10px;">&nbsp;
                                            <asp:GridView ID="GridView1" runat="server" CssClass="grid" AutoGenerateColumns="False"
                                                Width="98%" BorderWidth="0px" CellPadding="0" CellSpacing="1" BackColor="#B5D6E6"
                                                OnRowDeleting="GridView1_RowDeleting" OnRowCommand="Operate_RowCommand" onmouseover="changeto()" onmouseout="changeback()">
                                                <Columns>
                                                    <asp:BoundField DataField="pro_id" HeaderText="编号">
                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="标题">
                                                        <ItemTemplate>
                                                            <a href="xw_Add.aspx?id=<%#Eval("pro_id") %>" target="frmright"><%#Eval("pro_title") %></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="pro_name" HeaderText="房源户型" />

                                                    <asp:TemplateField HeaderText="图片">
                                                        <ItemTemplate>
                                                            <img alt='<%#Eval("pro_name") %>' src="<%#Eval("pro_img").ToString()!=""?"../upload/"+Eval("pro_img"):"../images/no-img.gif" %>"
                                                                width="80" height="60" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="分类">
                                                        <ItemTemplate>
                                                            <%#getclsname(Eval("pro_type").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="状态">
                                                        <ItemTemplate>
                                                            <%#Eval("states").ToString()%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="发布时间">
                                                        <ItemTemplate>
                                                            <%#Eval("pro_date","{0:d}")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="操作">
                                                        <ItemTemplate>

                                                            <a href="xw_Add.aspx?id=<%#Eval("pro_id") %>" target="frmright">编辑</a>
                                                            <img src="images/edt.gif" alt="" width="16" height="16" />

                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="check" CommandArgument='<%# Eval("pro_id") %>'>审核</asp:LinkButton>
                                                            <img src="images/33.gif" alt="" width="16" height="16" />

                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" OnClientClick='JavaScript:return confirm("删除后将无法恢复，确定删除吗？")'>删除</asp:LinkButton>
                                                            <img src="images/del.gif" alt="" width="16" height="16" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="选择">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk1" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="top_tr" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <div class="pl">
                                    <input id="quanxuan" class="btn_blue" onclick="javascript: btn_xuan(this);" type="button"
                                        value=" 全 选 " runat="server" />
                                    <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" CssClass="btn_blue"
                                        Text=" 删 除 " OnClientClick='javascript:return confirm("删除后将无法恢复，确定删除吗？");'></asp:Button>
                                </div>
                            </td>
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
                            <td style="color: #03515d;">
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
                            </td>
                            <td width="16">
                                <img src="images/tab_20.gif" width="16" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
