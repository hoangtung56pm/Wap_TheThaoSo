<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Page language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Wap_TheThaoSo.Wap.Default" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>
 


<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="UserControl/Footer.ascx" tagname="Footer" tagprefix="uc2" %>
<%@ Register src="UserControl/Home.ascx" tagname="Home" tagprefix="uc3" %>
<%@ Register src="UserControl/DangKy.ascx" tagname="DangKy" tagprefix="uc4" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no" />	
    <meta http-equiv="REFRESH" content="1800" />

    <title>.: viSport - Cong Thong Tin The Thao Danh Cho Mang Vietnamobile :.</title>

    <link href="/CssHandler.ashx?t=WapCss&f=style.css&v=<%= AppEnv.GetSetting("CssVersion") %>" rel="stylesheet" type="text/css" media="screen" />

</head>
<body>
    <script type="text/javascript">
        /* <![CDATA[ */
        var google_conversion_id = 971227569;
        var google_custom_params = window.google_tag_params;
        var google_remarketing_only = true;
        /* ]]> */
    </script>
    <script type="text/javascript" src="//www.googleadservices.com/pagead/conversion.js">
    </script>
    <noscript>
    <div style="display:inline;">
    <img height="1" width="1" style="border-style:none;" alt="" src="//googleads.g.doubleclick.net/pagead/viewthroughconversion/971227569/?value=0&amp;guid=ON&amp;script=0"/>
    </div>
    </noscript>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="main">
            <%--<uc4:DangKy ID="DangKy1" runat="server" /> 
            <div class="clear0px"></div>--%>

            <uc1:header ID="Header1" runat="server" />     
            <div class="clear0px"></div>
            <div id="content">
                <uc3:Home ID="Home1" runat="server" />
            </div>     <div class="clear0px"></div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </div>

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>
