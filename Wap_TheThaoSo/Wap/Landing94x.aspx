<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landing94x.aspx.cs" Inherits="Wap_TheThaoSo.Wap.Landing94x" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <%--<link href="main.css" type="text/css" rel="stylesheet">--%>
    <script type="text/javascript" src="/assets/jquery/jquery-2.1.4.min.js"></script>
    <title></title>
    <style>
        html, body {
            height: 100%;
            width: 100%;
            text-align: center;
        }

        body {
            background-image: url('/assets/Images/240x480.jpg');
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-position: center center;
            background-size: cover;
            width: 100%;
        }
       /*.wrapper{
           background-image: url('/assets/Images/240x480.jpg');
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-position: center center;
            background-size: cover;
            width: 100%;
            text-align: center;
            height:1800px;
       }*/
        .footer {
            position: fixed;
            bottom: 10px;
        }

            .footer span {
                color: #82644a;
                font-size: 30px;
                margin-left: 20px;
                margin-right: 20px;
            }

        input[type="submit"] {
            margin-top: 50%;
        }

        .btn-agree {
            background-image: url('/assets/Images/agree.png');
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-position: center center;
            background-size: cover;
            background-color: transparent;
            border: none;
            width: 30%;
            height: 127px;
            color: #fff;
            font-size: 40px;
            
        }

        .btn-cancel {
            background-image: url(/assets/Images/cancel.png);
            background-repeat: no-repeat;
            background-attachment: scroll;
            background-position: center center;
            background-size: cover;
            background-color: transparent;
            border: none;
            width: 30%;
            height: 127px;
            color: #f45538;
            font-size: 40px;
           
        }
    </style>
   <script>
       $(document).ready(function () {

           $('.wrapper').on('click', function () {

               $.urlParam = function (name) {
                   var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                   return results[1] || 0;
               }
               //alert($.urlParam('id'));
               window.location = ('http://vnm.ising.vn/sub/DK.aspx?id=' + $.urlParam('id'));
           });

       });
   </script>
     <%--<script type="text/javascript">
        function GetSession()
        {
            var username = '<%= Session["msisdn"] %>';
            var urlParams;
            (window.onpopstate = function () {
                var match,
                    pl = /\+/g,  // Regex for replacing addition symbol with a space
                    search = /([^&=]+)=?([^&]*)/g,
                    decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
                    query = window.location.search.substring(1);

                urlParams = {};
                while (match = search.exec(query))
                    urlParams[decode(match[1])] = decode(match[2]);
            })();
            window.location = ('http://vnm.ising.vn/sub/DK.aspx?id=' + urlParams["id"]);
        }
    </script>--%>
</head>
<body style="cursor: pointer;">
    <form id="form1" runat="server">
        <div class="wrapper">
            <%--<input type="button" id="btn-cancel" value="Bỏ qua">--%>
            <asp:Button runat="server" ID="btnCancel" Text="Bỏ qua" CssClass="btn-cancel" OnClick="btnCancel_Click" />
            <%--<input type="button" id="btn-agree" value="Đồng ý">--%>
            <asp:Button runat="server" ID="btnAgree" Text="Đồng ý" CssClass="btn-agree" OnClick="btnAgree_Click" />
            <div class="footer">
                <%--<p>
                    Quý khách vui lòng xác nhận đồng ý đăng ký
            và gia hạn dịch vụ [tên dịch vụ] với giá cước dịch vụ là [giá cước/chu kỳ].
        Trân trọng cảm ơn
                </p>--%>
                <asp:Label runat="server" ID="lblAlert"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

