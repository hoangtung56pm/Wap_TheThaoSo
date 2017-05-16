<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GiaiTri.ascx.cs" Inherits="Wap_TheThaoSo.Wap.UserControl.GiaiTri" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>

<div id="GiaiTri">

    <div class="giaitri-top item-bg-gt">
        <div class="red-separator-gt margin-left2px"></div>
        <div class="floatleft padding-left5px padding-right5px background-white">
                    <a class="item-top-gt" href="#">
                        Giải trí</a></div>
        <div class="red-separator-gt margin-right2px"></div>
    </div>

    <div class="clear15px">
    </div>
    <div class="giaitri-item">
        <div class="item">
            
            <a href="<%= UrlProcess.GetNhacChuongHomeUrl() %>">
                <img alt="" src="/layout/images/Ringtone.png" width="50px" height="50px" /></a>
            <div class="clear5px">
            </div>
            <a href="<%= UrlProcess.GetNhacChuongHomeUrl() %>">Nhạc chuông</a>
        </div>
        <div class="item">
            <a href="<%= UrlProcess.GetVideoHomeUrl() %>">
                <img alt="" src="/layout/images/video.png" width="50px" height="50px"  /></a>
            <div class="clear5px"></div>
            <a href="<%= UrlProcess.GetVideoHomeUrl() %>">Video clip</a>
        </div>
        <div class="item">
            <a href="<%= UrlProcess.GetHinhNenHomeUrl() %>">
                <img alt="" src="/layout/images/Picture.png" width="50px" height="50px" /></a>
            <div class="clear5px">
            </div>
            <a href="<%= UrlProcess.GetHinhNenHomeUrl() %>">Ảnh đẹp</a>
        </div>
       <%-- <div class="item">
            <a href="<%= UrlProcess.GetTuVanUrl() %>">
                <img alt="" src="/layout/images/Tuvan.png" width="50px" height="50px"  /></a>
            <div class="clear5px">
            </div>
            <a href="<%= UrlProcess.GetTuVanUrl() %>">Tư vấn</a>
        </div>--%>
    </div>
    <div class="clear10px">
    </div>
    <div class="separator">
    </div>
</div>
