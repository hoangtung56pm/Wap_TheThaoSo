<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuccessLow.aspx.cs" Inherits="Wap_TheThaoSo.Wap.SuccessLow" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="UserControlLow/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="UserControlLow/Footer.ascx" tagname="Footer" tagprefix="uc2" %>
<%@ Register src="UserControlLow/Home.ascx" tagname="Home" tagprefix="uc3" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no" />	
    <meta http-equiv="REFRESH" content="1800" />

    <title>.: viSport - Cong Thong Tin The Thao Danh Cho Mang Vietnamobile :.</title>

    <link href="/CssHandler.ashx?t=WapCssLow&f=lowstyle.css&v=<%= AppEnv.GetSetting("CssVersion") %>" rel="stylesheet" type="text/css" media="screen" />

</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="main">
            <uc1:header ID="Header1" runat="server" />     <div class="clear0px"></div>
            <div id="content" align="center">
               
                <br />

                <b>Đăng ký thành công</b> <br />

                <b>Chúc mừng bạn đã được sử dụng dịch vụ viSPORT miễn phí trong 07 ngày</b>

                <br />
                <br />

                <b>Để hủy dịch vụ soạn tin : SC OFF gửi 979</b>
                <br />
                <br />

                <a href="<%= AppEnv.GetSetting("WapDefault") %>"> <b> << Quay về Trang chủ >> </b> </a><br /><br />
                <b>Gói dịch vụ tuần: 3000đ</b>
                <br />

            </div>     
            <div class="clear5px"></div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </div>

    </form>
</body>
</html>

