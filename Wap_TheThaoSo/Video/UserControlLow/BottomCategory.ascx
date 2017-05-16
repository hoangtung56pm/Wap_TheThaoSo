<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomCategory.ascx.cs" Inherits="Wap_TheThaoSo.Video.UserControlLow.BottomCategory" %>

<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>

<div id="othercategory">
        <ul>
            <li><a href="<%= UrlProcess.GetVideoCategoryLowUrl(28) %>" class="none">Clip trận đấu</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryLowUrl(20) %>">Đẹp nhất</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryLowUrl(22) %>">Hot nhất</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryLowUrl(21) %>">Dị nhất</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryLowUrl(66) %>">Tennis</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryLowUrl(67) %>">Đua xe</a> </li>
            <li class="none"><a href="<%= UrlProcess.GetVideoCategoryLowUrl(9999) %>">Khác</a> </li>
        </ul>
    </div>
