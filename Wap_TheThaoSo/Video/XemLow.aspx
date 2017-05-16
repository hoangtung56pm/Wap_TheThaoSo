<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XemLow.aspx.cs" Inherits="Wap_TheThaoSo.Video.XemLow" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../Wap/UserControlLow/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Wap/UserControlLow/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server"></asp:Literal>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no" />
    <title>.: viSport - Video :.</title>

    <link href="/CssHandler.ashx?t=WapCssLow&f=lowstyle.css&v=<%= AppEnv.GetSetting("CssVersion") %>" rel="stylesheet" type="text/css" media="screen" />

</head>
<body>
    <form id="form2" runat="server">
    <div id="wrapper">
        <div id="main">
            <uc1:Header ID="Header2" runat="server" />
            <div class="clear0px">
            </div>
            <%--Content here--%>
            <div id="content">
                <div class="home_content">
                    <div class="home_conent_top">
                        <div class="item">
                            <div class="item-top item-bg">
                                <div class="red-separator margin-left2px">
                                </div>
                                <div class="floatleft padding-left5px padding-right5px  background-white">
                                    <a href="javascript:void(0)">Video</a></div>
                                <div class="red-separator margin-right2px">
                                </div>
                            </div>
                            <div class="clear5px">
                            </div>
                        </div>
                    </div>
                    <div class="clear5px">
                    </div>
                    <asp:Panel ID="pnlSMS" runat="server" Visible="false">
                        <div class="boxcontent">
                            <asp:Literal ID="ltrHuongdan" runat="server">HƯỚNG DẪN</asp:Literal>
                        </div>
                        <div style="text-align: center;" class="boxcontent">
                            <p>
                                <asp:Literal ID="ltrSMS" runat="server">Soạn tin nhắn theo cú pháp</asp:Literal></p>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
                        <div class="rbroundbox">
                            <div class="rbtop">
                                <div>
                                    <asp:Literal ID="ltrTitle" runat="server">THÔNG BÁO</asp:Literal></div>
                            </div>
                        </div>
                        <div style="text-align: center;" class="boxcontent">
                            <p>
                                <asp:Literal ID="ltrThongBao" runat="server">THÔNG BÁO</asp:Literal></p>
                            <asp:Button ID="btnCo" Text="Tiếp tục" runat="server" OnClick="btnCo_Click" />
                            <asp:Button ID="btnKhong" Text="Quay lại" runat="server" OnClick="btnKhong_Click" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
                        <div class="boxcontent">
                            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
                            <p>
                                <asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal></p>
                            <p>
                                <asp:HyperLink ID="lnkDownload" runat="server"></asp:HyperLink></p>
                        </div>
                    </asp:Panel>
                </div>
                <%--end Content here--%>
                <div class="clear0px">
                </div>
                <uc2:Footer ID="Footer1" runat="server" />
            </div>
        </div>
    </div>

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>
