<%@ Control Language="C#" AutoEventWireup="true" CodeFile="top.ascx.cs" Inherits="controls_top" %>

<div id="top" class="top">
    <div class="top_cont">
        <a href="javascript:void(0);" onclick="SetHome(this,'http://'+window.location.host);">设为首页</a>
        <a href="javascript:void(0);" onclick="AddFavorite('http://'+window.location.host,document.title)">加入收藏</a>
        <%if (Request.Cookies["buy"] != null)
          {%>
          欢迎，<%=HttpUtility.UrlDecode(Request.Cookies["buy"]["user"]) %>
        <a href="member_index.aspx">会员中心</a>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">安全退出</asp:LinkButton>
        <%}
          else
          { %>
            <a href="login.aspx">登录</a>
            <a href="login.aspx">注册</a>
        <%} %>
    </div>    
</div>

<div id="nav" class="nav">
    <div class="nav_cont">
        <ul class="menu">
            <li><a href="index.aspx">网站首页</a></li>
            <li><a href="supply.aspx?cls=1">出租房源</a></li>
            <li><a href="ly.aspx?cls=2">在线留言</a></li>

            <li><a href="supply.aspx?cls=4">预租房源</a></li>

            <li><a href="supply.aspx?cls=3">站内新闻</a></li>
        </ul>
        <div class="date">
            <script src="js/date.js" type="text/javascript"></script>
        </div>
    </div>    
</div>

<%--<div class="Pro_search">
    <div class="ProSbox">
        <div class="www_zzjs_net">
            <input name="q" type="text" class="searchinput" id="key" title="Search" onfocus="this.value=this.value=='- 请输入您要查询的产品名称 -'?'':this.value"
                onblur="this.value=this.value==''?'- 请输入您要查询的产品名称 -':this.value;" onkeydown="if (event.keyCode==13) {}"
                value="- 请输入您要查询的产品名称 -" size="20" />
        </div>
        <div class="searchBtn">
            <a style="cursor: pointer;" onclick="s();">
                <img src="images/search.gif" alt="search" border="0" /></a></div>
    </div>
</div>--%>

<script type="text/javascript">
    function s() {
        var txt = document.getElementById("key");
        var str = "";
        str = txt.value == "" || txt.value == "- 请输入您要查询的产品名称 -" ? "" : "?key=" + escape(txt.value);
        location.href = "supply.aspx" + str;
    }
</script>