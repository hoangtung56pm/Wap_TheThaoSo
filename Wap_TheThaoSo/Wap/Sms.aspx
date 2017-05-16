<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sms.aspx.cs" Inherits="Wap_TheThaoSo.Wap.Sms" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="UserControl/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="UserControl/Footer.ascx" tagname="Footer" tagprefix="uc2" %>
<%@ Register src="UserControl/Home.ascx" tagname="Home" tagprefix="uc3" %>



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
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="main">
            <uc1:header ID="Header1" runat="server" />     <div class="clear0px"></div>
            <div id="content" align="center">
                <%--<uc3:Home ID="Home1" runat="server" />--%>

                <%-- <br />--%>
                <%--<br />--%>
                <b>Dịch vụ viSport yêu cầu sử dụng kết nối 3G hoặc GPRS trên mạng Vietnamobile</b>
                <br />
                <br />
                Để đăng ký dịch vụ soạn tin : <b>SC</b> gửi <b>979</b>
                <br />
                <br />
                <a href="<%= AppEnv.GetSetting("WapDefault") %>"> <b> << Quay về Trang chủ >> </b> </a>
            </div>     
            <div class="clear5px"></div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </div>

    <%--<img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />--%>

    </form>
</body>
</html>

