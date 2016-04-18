<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ly.aspx.cs" Inherits="supply" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="controls/top.ascx" TagName="top" TagPrefix="uc1" %>
<!DOCTYPE html>
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
                <div class="newLxt0">
                    <dl>
                        <dt>留言标题:</dt>
                        <dd>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </dd>                        
                    </dl>
                    <dl>
                        <dt>留言内容:</dt>
                        <dd>
                            <asp:TextBox ID="TextBox2" runat="server" Height="82px" TextMode="MultiLine"></asp:TextBox>  
                        </dd>
                    </dl>
                    <p>
                        <asp:Button ID="Button1" runat="server" Text="提交留言" OnClick="Button1_Click" />
                    </p>
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
