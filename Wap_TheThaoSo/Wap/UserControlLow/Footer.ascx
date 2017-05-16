<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Wap_TheThaoSo.Wap.UserControlLow.Footer" %>

<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>

<div id="footer">
                <div class="footer-top">
                    <ul>
                        <li><a href="<%= UrlProcess.GetTranCauVangLowUrl() %>" class="yellow">Trận cầu vàng</a> </li>
                        <li class="none"><a href="<%= UrlProcess.GetDuLieuHomeLowUrl() %>">Dữ liệu</a> </li>
                        <li class="none"><a href="<%= UrlProcess.GetVideoHomeLowUrl() %>">Video</a> </li>
                        <li class="none"><a href="<%= UrlProcess.GetLivescoreLowUrl() %>">Livescore</a> </li>
                    </ul>
                </div>
                <div class="footer-bottom">
                    <div class="clear10px"></div>
                    <a href="<%= RawUrl %>">Đầu trang </a>|<a style="text-decoration:none;" href="/Wap/HuongDan.aspx">Hướng dẫn</a>|Copyright © Vietnamobile
                </div>
            </div>