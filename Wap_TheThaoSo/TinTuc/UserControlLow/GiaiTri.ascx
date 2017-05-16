<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiaiTri.ascx.cs" Inherits="Wap_TheThaoSo.TinTuc.UserControlLow.GiaiTri" %>

<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<div id="GiaiTri">
    <div class="giaitri-top">
        <div class="giaitri-image">
        </div>
        <div class="giaitri-bg">
        </div>
    </div>
    <div class="clear15px">
    </div>
    <div class="giaitri-item">
        <div class="item">
            
            <a href="<%= UrlProcess.GetNhacChuongHomeLowUrl() %>">
                <img alt="" src="/layout/images/Ringtone.png" width="50px" height="50px" /></a>
            <div class="clear5px">
            </div>
            <a href="<%= UrlProcess.GetNhacChuongHomeLowUrl() %>">Nhạc chuông</a>
        </div>
        <div class="item">
            <a href="<%= UrlProcess.GetVideoHomeLowUrl() %>">
                <img alt="" src="/layout/images/video.png" width="50px" height="50px"  /></a>
            <div class="clear5px">
            </div>
            <a href="<%= UrlProcess.GetVideoHomeLowUrl() %>">Video clip</a>
        </div>
        <div class="item">
            <a href="<%= UrlProcess.GetHinhNenHomeLowUrl() %>">
                <img alt="" src="/layout/images/Picture.png" width="50px" height="50px" /></a>
            <div class="clear5px">
            </div>
            <a href="<%= UrlProcess.GetHinhNenHomeLowUrl() %>">Ảnh đẹp</a>
        </div>
        <div class="item">
            <a href="<%= UrlProcess.GetTuVanLowUrl() %>">
                <img alt="" src="/layout/images/Tuvan.png" width="50px" height="50px"  /></a>
            <div class="clear5px">
            </div>
            <a href="<%= UrlProcess.GetTuVanLowUrl() %>">Tư vấn</a>
        </div>
    </div>

    <div class="clear10px"></div>

    <%--<div class="separator"></div>--%>

</div>
