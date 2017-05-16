﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Wap_TheThaoSo.TinTuc.Default" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../Wap/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Wap/UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no" />
    <meta http-equiv="REFRESH" content="1800" />

    <title>.: viSport - Tin Tuc The Thao Tong Hop :.</title>

    <link href="/CssHandler.ashx?t=WapCss&f=style.css&v=<%= AppEnv.GetSetting("CssVersion") %>" rel="stylesheet" type="text/css" media="screen" />

</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="main">
            <uc1:Header ID="Header1" runat="server" />
            <div class="clear0px">
            </div>
            <asp:PlaceHolder runat="server" ID="plContent"></asp:PlaceHolder>
            <div class="clear0px">
            </div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </div>

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>
