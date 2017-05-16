<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landing1.aspx.cs" Inherits="Wap_TheThaoSo.Wap.Landing1" %>

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
    <style>
        #container {
            background-image: url(/assets/Images/Landing/anh2.jpg);
            background-repeat: no-repeat;
            background-size: cover;
            width: auto;
            height: 648px;
        }

        .dv-free-register {
            font-weight: 600;
            text-align: center;
            padding-top: 495px;
        }

        .dv-register-btn {
            text-align: center;
            margin-top: 7px;
        }

        .td-info-regis {
            font-weight: 500;
            color: #797979;
            font-size: 12px;
            text-align: center;
            padding-left: 10px;
        }

        .dv-tbl-info {
            text-align: center;
        }

            .dv-tbl-info table {
                width: 100%;
            }

        .container a img {
            background-repeat: no-repeat;
            background-size: cover;
            width: auto;
        }

        
    </style>
    <script type="text/javascript">
        function GetSession()
        {

            var username = '<%= Session["msisdn"] %>';
            //alert(username);
            if (username == 'Khách') {
                window.location = ('http://wap.vietnamobile.com.vn/Video/Default.aspx?lang=1&display=home&w=320');
            } else {
                window.location = ('http://wap.vietnamobile.com.vn/sub/DK.aspx?id=813');
            }           
        }
    </script>
</head>
<body style="margin: 0px auto">
    <form id="form1" runat="server">
        <div id="container">
          <%--  <a href="http://visport.vn/wap/DangKy.aspx" onclick="return confirm('Bạn có đồng ý đăng ký dịch vụ Visport với giá 5.000đ/ngày không ?')">
                <img style="width: 100%; margin-top: -100px;" src="/assets/Images/Landing/anh1.jpg" class="ri" /></a>--%>
           <div onclick="GetSession();" style="cursor: pointer;">
                <div class="dv-free-register">
                MIỄN PHÍ ĐĂNG KÝ
            </div>
            <div class="dv-register-btn">
                <asp:LinkButton runat="server" ID="btn_DangKy" OnClick="btn_DangKy_Click"><img src="/assets/Images/dangky.png" /></asp:LinkButton>
            </div>
           </div>
            <div class="dv-tbl-info">
                <table>
                    <tr>
                        <td class="td-cancel">
                            <asp:LinkButton runat="server" ID="btn_Huy" OnClick="btn_Huy_Click"><img alt="" src="/assets/Images/btn_huy.png" /></asp:LinkButton>
                        </td>
                        <td class="td-info-regis">Gía 3.000đ/ngày
                        <br />
                            <b>HUY CONHIP15</b><br />
                            gửi <b>949</b>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
