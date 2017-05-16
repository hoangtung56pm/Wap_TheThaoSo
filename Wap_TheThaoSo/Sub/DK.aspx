<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DK.aspx.cs" Inherits="Wap_TheThaoSo.Sub.DK" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="../Wap/UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Wap/UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>


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
        <uc1:Header ID="Header1" runat="server" />
        <asp:Panel ID="pnlSMS" runat="server" Visible="false">
            <div class="rbroundbox">
                <div class="rbtop">
                    <div>
                        <asp:Literal ID="ltrHuongdan" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div style="text-align: center;" class="boxcontent">
                <p style="text-align: left;">
                    <asp:Literal ID="ltrSMS" runat="server"></asp:Literal>
                </p>

            </div>
        </asp:Panel>

        <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
            <div class="rbroundbox">
                <div class="rbtop">
                    <div>
                        <asp:Literal ID="ltrTitle" runat="server">Dịch vụ Sub</asp:Literal>
                    </div>
                </div>
            </div>
            <div style="text-align: center;" class="boxcontent">
                <p style="text-align: left;">
                    <asp:Literal ID="ltrThongBao" runat="server">Giới Thiệu</asp:Literal>
                </p>

                <p style="text-align: left;">
                    <asp:Literal ID="ltrThongBaoNoiDung" runat="server"></asp:Literal>
                </p>

            </div>
        </asp:Panel>
        <asp:Panel ID="pnlConfirm" runat="server" Visible=" false">
            <div class="rbroundbox">
                <div class="rbtop">
                    <div>
                        <asp:Literal ID="Literal1" runat="server">Đăng ký Dịch Vụ</asp:Literal>
                    </div>
                </div>
            </div>
            <div class="boxcontent">
                <asp:Label ID="lblTen1" runat="server" CssClass="blue bold"></asp:Label>
                <%--<p>
                    <asp:Button runat="server" ID="btnReg" Text="Đăng ký" OnClick="btnReg_Click" />

                </p>--%>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
            <div class="rbroundbox">
                <div class="rbtop">
                    <div>
                        <asp:Literal ID="ltrTieuDe" runat="server">Đăng ký Dịch Vụ</asp:Literal>
                    </div>
                </div>
            </div>
            <div class="boxcontent">
                <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
                <p>
                    <asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal>
                </p>
            </div>
        </asp:Panel>
        <uc2:Footer ID="Footer1" runat="server" />
        <%--end Content here--%>
    </form>
</body>
</html>
