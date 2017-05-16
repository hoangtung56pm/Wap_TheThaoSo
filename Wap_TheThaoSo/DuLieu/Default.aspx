<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Wap_TheThaoSo.DuLieu.Default" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<%@ Register src="../Wap/UserControl/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="../Wap/UserControl/Footer.ascx" tagname="Footer" tagprefix="uc2" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no" />
    <meta http-equiv="refresh" content="60" /> <%--Second--%>

    <title>.: viSport - Du Lieu Bong Da Tong Hop :.</title>

    <%--<link href="/layout/style.css" rel="stylesheet" type="text/css" media="screen" />--%>

    <link href="/CssHandler.ashx?t=WapCss&f=style.css&v=<%= AppEnv.GetSetting("CssVersion") %>" rel="stylesheet" type="text/css" media="screen" />

</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="main">
            <uc1:header ID="Header1" runat="server" />     <div class="clear0px"></div>
                <asp:PlaceHolder runat="server" ID="plContent"></asp:PlaceHolder>     <div class="clear0px"></div>
            <uc2:footer ID="Footer1" runat="server" />
        </div>
    </div>

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>
