<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sys_Product_Cls.aspx.cs" Inherits="System_Sys_News_Cls" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <title>文章类型</title>
    <link type="text/css" href="css/grid.css" rel="stylesheet" />

    <script type="text/javascript" src="js/quanxuan.js"></script>

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
                                                            <img src="images/tb.gif" width="16" height="16" /></div>
                                                    </td>
                                                    <td width="97%">
                                                        <b>你当前的位置</b>：[<a href="sys_product_cls.aspx">房源户型类别管理</a>]</td>
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
                                <table align="center" bgcolor="#b0d0f3" border="0" cellpadding="4" cellspacing="1"
                                    width="98%" style="margin-top: 10px; font-size: 12px; text-indent: 3px;">
                                    <tr bgcolor="#ffffff">
                                        <td height="32" colspan="2">
                                            <table>
                                                <tr>
                                                    <td style="width: 95px">
                                                        <span style="font-size: 14px; font-weight: bold; color: #56A5EE;">添加类别：</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_type" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 232px; padding-left: 20px;">
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button3" runat="server" Text=" 添 加 " CssClass="btn_blue" ValidationGroup="btn"
                                                            OnClick="Button3_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                                            ErrorMessage="请填写类别名称！" ValidationGroup="btn"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td height="32" colspan="2" style="padding: 10px;">
                                            &nbsp;
                                            <asp:GridView ID="GridView1" runat="server" CssClass="grid" AutoGenerateColumns="False"
                                                Width="98%" BorderWidth="0px" CellPadding="0" CellSpacing="1" BackColor="#B5D6E6"
                                                OnRowDataBound="GridView1_RowDataBound" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                                OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                                                onmouseover="changeto()" onmouseout="changeback()">
                                                <Columns>
                                                    <asp:BoundField DataField="pro_cls_id" HeaderText="编号" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="分类名称">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("pro_cls_name") %>' CssClass="text"
                                                                Height="16"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("pro_cls_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="250px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="所属类别">
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddl_cls" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("pro_cls_pid") %>'
                                                                Visible="false" />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("pro_cls_pid") %>'
                                                                Visible="false" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="操作">
                                                        <EditItemTemplate>
                                                            <img src="images/edt.gif" width="16" height="16" /><asp:LinkButton ID="LinkButton3"
                                                                runat="server" CausesValidation="True" CommandName="Update">更新</asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <img src="images/del.gif" width="16" height="16" /><asp:LinkButton ID="LinkButton4"
                                                                runat="server" CausesValidation="False" CommandName="Cancel">取消</asp:LinkButton>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <img src="images/edt.gif" width="16" height="16" /><asp:LinkButton ID="LinkButton2"
                                                                runat="server" CausesValidation="False" CommandName="Edit">编辑</asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <img src="images/del.gif" width="16" height="16" /><asp:LinkButton ID="LinkButton1"
                                                                runat="server" CommandName="Delete" OnClientClick='JavaScript:return confirm("删除该类型将删除所有相关联的商品及需求！删除后将无法恢复，确定删除吗？")'>删除</asp:LinkButton>
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
                                    <input id="quanxuan" class="btn_blue" onclick="javascript:btn_xuan(this);" type="button"
                                        value=" 全 选 " runat="server" />
                                    <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" CssClass="btn_blue"
                                        Text=" 删 除 " OnClientClick='javascript:return confirm("删除该类型将删除所有相关联的商品及需求！删除后将无法恢复，确定删除吗？");'>
                                    </asp:Button>
                                </div>
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
                                        PageSize="15">
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
