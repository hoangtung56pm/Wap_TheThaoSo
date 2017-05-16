<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomCategory.ascx.cs" Inherits="Wap_TheThaoSo.Video.UserControl.BottomCategory" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>

<div id="othercategory">
        <ul>
            <li><a href="<%= UrlProcess.GetVideoCategoryUrl(28) %>" class="none">Clip trận đấu</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryUrl(20) %>">Đẹp nhất</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryUrl(22) %>">Hot nhất</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryUrl(21) %>">Dị nhất</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryUrl(66) %>">Tennis</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryUrl(67) %>">Đua xe</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryUrl(9999) %>">Khác</a> </li>
        </ul>
    </div>
