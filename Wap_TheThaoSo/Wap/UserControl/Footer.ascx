<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Wap_TheThaoSo.Wap.UserControl.Footer" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<div id="footer">
    <div class="footer-top">
        <ul>
           <%-- <li><a href="<%= UrlProcess.GetTranCauVangUrl() %>" class="yellow">Trận cầu vàng</a>
            </li>--%>
            <li class="none"><a href="<%= UrlProcess.GetDuLieuHomeUrl() %>">Dữ liệu</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoHomeUrl() %>">Video</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetLivescoreUrl() %>">Livescore</a> </li>

            <li class="none"><a href="<%= UrlProcess.GetHomeUrl("1","320") %>">Tin tức</a> </li>

        </ul>
    </div>
    <div class="footer-bottom">
        <div class="clear10px">
        </div>
        <a style="text-decoration:none;" href="#"> Đầu trang </a>|<a style="text-decoration:none;" href="/Wap/HuongDan.aspx">Hướng dẫn</a>|Copyright © Vietnamobile
    </div>
</div>
