<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CauHoi_TheLe.aspx.cs" Inherits="Wap_TheThaoSo.Wap.CauHoi_TheLe" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=no" />

    <title>.: Thể lệ :.</title>
    <link href="/assets/Css/Style.css" rel="stylesheet" />
    <%-- <link href="/CssHandler.ashx?t=WapCss&f=style.css&v=<%= AppEnv.GetSetting("CssVersion") %>" rel="stylesheet" type="text/css" media="screen" />
    
    <style>
    
    .btn-danger {
        background-color: #d9534f;
        border-color: #d43f3a;
        color: #fff;
        cursor: pointer;
    }

    </style>--%>
</head>
<body style="background: #dedede;margin:0px auto">
    <form id="form1" runat="server">
        
        <div id="body" style="width: 100%">
            <div class="header_thele">
                <a href="/Wap/cauhoi.aspx">
                    <img src="/assets/Images/tthe-le-back.png" /></a>
            </div>
            <div class="content_thele">
                <p style="line-height:25px">
                    <%--<img style="width: 100%" src="/assets/Images/tthe-le-content.png"/>--%>
                      Khách hàng đăng ký dịch vụ bằng cách soạn tin 
                        nhắn <span style="color: #ff5400"><b>DK MM</b></span> gửi <span style="color: #ff5400"><b>949</b></span><br />
                    Giá dịch vụ: <span style="color: #29a2ff"><b>3000đ/ngày</b></span>
                    Sau khi đăng ký dịch vụ thành công, mỗi ngày 
                        khách hàng sẽ nhận được 5 câu hỏi miễn phí trên 
                        trang <a href="http://visport.vn/Wap/cauhoi.aspx">http://visport.vn/Wap/cauhoi.aspx</a> ( sử dụng trên web/wap)
                        Sau khi khách hàng trả lời hết 5 câu hỏi miễn phí 
                        trong ngày, ở câu hói thứ 5 sẽ thông báo cho khách 
                        hàng có muốn trả lời tiếp các câu hỏi không, các 
                        câu hỏi mua thêm sẽ được tính <span style="color: #29a2ff"><b>1.000đ/1 câu hỏi</b></span>. 
                        Không giới hạn số lượng câu hỏi trả lời thêm.
                        Khách hàng trả lời đúng được cộng 1 điểm, trả lời 
                        sai không được cộng điểm
                        Mỗi tuần sẽ có giải thưởng <span style="color: #29a2ff"><b>1 triệu</b></span> tiền mặt cho 
                        khách hàng giành được số điểm cao nhất. Điểm 
                        tuần tính từ 00h00 ngày thứ 2 hàng tuần đến 
                        23h59:59 ngày chủ nhật.                         
                        Khách hàng mua thêm câu hỏi bằng cách click trên 
                        wap để mua thêm câu hỏi. Mỗi lượt mua thêm 
                        được 1 câu hỏi.
                </p>
            </div>
        </div>


    </form>
</body>
</html>
