<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="Wap_TheThaoSo.Wap.LandingPage" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>


<%@ Register Src="UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no" />

    <title>.: Landing page :.</title>
    <link href="/assets/Css/Style.css" rel="stylesheet" />
    <link href="/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet">

    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/masonry/3.3.2/masonry.pkgd.min.js"></script>
    <script type="text/javascript" src="/assets/jquery/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/assets/plugins/bootstrap/js/bootstrap.js"></script>
   <%-- <script type="text/javascript">
        $(document).ready(function () {            
            $("#popup-login").modal();
        });
    </script>--%>
    <style>
        .close {
            cursor: pointer;
            float: right;
            margin-top: -22px;
        }

            .close:hover {
                margin-top: -22px;
            }
    </style>
</head>
<body style="margin: 0px auto" class="modal-open">
    <form id="form1" runat="server">        
        <asp:Literal runat="server" ID="ltrBody"></asp:Literal>       
       <%-- <div class="modal fade in" id="popup-login" style="display: block; padding-left: 0px;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body" style="padding: 0;">
                        <a href="http://visport.vn/wap/DangKy.aspx">
                            <img style="width: 100%; margin-top: -30px;" src="/assets/Images/Landing/anh6.jpg" /></a>
                        <asp:LinkButton runat="server" ID="btn_Huy" class="close" Style="opacity: 0.6" OnClick="btn_Huy_Click"><img src="/assets/Images/close.jpg" /></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>--%>
        <%-- <div class="modal fade in" id="popup-login" style="display: block; padding-left: 0px;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body" style="padding: 0;">
                        <a href="http://visport.vn/wap/DangKy.aspx">
                            <img style="width: 100%; margin-top: -30px;" src="/assets/Images/Landing/anh6.jpg" /></a>
                        <asp:LinkButton runat="server" ID="btn_Huy" class="close" Style="opacity: 0.6" OnClick="btn_Huy_Click"><img src="/assets/Images/close.jpg" /></asp:LinkButton>
                        <a href="http://wap.vietnamobile.com.vn" class="close" Style="opacity: 0.6"><img src="/assets/Images/close.jpg" /></a>
                    </div>
                </div>
            </div>
        </div>--%>
    </form>
</body>
</html>
