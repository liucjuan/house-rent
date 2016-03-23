<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tj_Product_List.aspx.cs"
    Inherits="System_Sys_Product_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7">
    <title>案例管理</title>
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
                            <td width="12" style="height: 40px">
                                <img src="images/tab_03.gif" width="12" height="30" /></td>
                            <td style="height: 40px">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="46%" valign="middle">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="5%">
                                                        <div align="center">
                                                            <img src="images/tb.gif" width="16" height="16" /></div>
                                                    </td>
                                                    <td width="95%">
                                                        </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="54%">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="16" style="height: 40px">
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
                                <table align="center" bgcolor="#b0d0f3" border="0" cellpadding="4" cellspacing="1"
                                    width="98%" style="margin-top: 10px; font-size: 12px; text-indent: 3px;">
                                    <tr bgcolor="#ffffff">
                                        <td height="32" colspan="2" style="padding: 10px;">
                                           房源类别:<asp:DropDownList ID="DropDownList1" runat="server" Width="157px">
                                               <asp:ListItem Value="1">出租房源</asp:ListItem>
                                               <asp:ListItem Value="2">出售房源</asp:ListItem>
                                               <asp:ListItem Value="4">求租房源</asp:ListItem>
                                               <asp:ListItem Value="5">求售房源</asp:ListItem>
                                            </asp:DropDownList><asp:Button ID="Button1" runat="server" Text="统计" OnClick="Button1_Click" />
                                            <asp:GridView ID="GridView1" runat="server" CssClass="grid" AutoGenerateColumns="False"
                                                Width="98%" BorderWidth="0px" CellPadding="0" CellSpacing="1" BackColor="#B5D6E6"
                                               onmouseover="changeto()" onmouseout="changeback()">
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
                                                    <asp:TemplateField HeaderText="发布时间">
                                                        <ItemTemplate>
                                                            <%#Eval("pro_date","{0:d}")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                   
                                                </Columns>
                                                <HeaderStyle CssClass="top_tr" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                               
                            </td>
                            <td width="8" style="background: url(images/tab_15.gif) repeat-y;">
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
                                    &nbsp;</div>
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
