<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HinhNen_New.ascx.cs" Inherits="Wap_TheThaoSo.HinhNen.UserControlLow.HinhNen_New" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControlLow/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="../../HinhNen/UserControl/DownloadPagging.ascx" TagName="DownloadPagging" TagPrefix="uc2" %>
<%@ Register Src="../../HinhNen/UserControl/NewPagging.ascx" TagName="NewPagging" TagPrefix="uc3" %>
<%@ Register Src="../../TinTuc/UserControlLow/BottomCategory.ascx" TagName="BottomCategory"
    TagPrefix="uc4" %>

<div id="content">
    <div class="home_content">
        <div class="clear5px">
        </div>
        <div class="home_conent_top">
           
            <div class="item">

                        <div class="item-top item-bg">
                            <div class="red-separator margin-left2px">
                            </div>
                            <div class="floatleft padding-left5px padding-right5px  background-white">
                                <a  href="#">Ảnh Đẹp</a>
                             </div>
                            <div class="red-separator margin-right2px"></div>
                        </div>
                        
                        <div class="clear7px"></div>

                        <div class="background-xam-e0e0e0 height22px lineheight22"><b class="padding-left5px">Mới cập nhật</b></div>

                        <div class="clear2px"></div>

                    </div>

        </div>
        <div class="clear5px">
        </div>
        <div class="home_conent_bottom">
            <asp:Repeater ID="rptMoiCapNhat" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">

                        <div class="image">
                            <a href="<%# UrlProcess.GetHinhNenDetailNewLowUrl(0,ConvertUtility.ToInt32(Eval("AlbumId").ToString())) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("AlbumAvatar"),60,60) %>" />
                            </a>
                        </div>

                        <a class="link-title" href="<%# UrlProcess.GetHinhNenDetailNewLowUrl(0,ConvertUtility.ToInt32(Eval("AlbumId").ToString())) %>">
                            <%# Eval("AlbumName")%>
                        </a>

                         <p class="justify lineheight padding-right7px margin-left5px font12px">
                            <%# Eval("AlbumDetail") %>
                        </p>

                        <div class="clear0px"></div>

                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="item-alternate">
                       
                         <div class="image">
                            <a href="<%# UrlProcess.GetHinhNenDetailNewLowUrl(0,ConvertUtility.ToInt32(Eval("AlbumId").ToString())) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("AlbumAvatar"),60,60) %>" />
                            </a>
                        </div>
                        <a class="link-title" href="<%# UrlProcess.GetHinhNenDetailNewLowUrl(0,ConvertUtility.ToInt32(Eval("AlbumId").ToString())) %>">
                            <%# Eval("AlbumName")%>
                        </a>

                         <p class="justify lineheight padding-right7px margin-left5px font12px">
                            <%# Eval("AlbumDetail") %>
                        </p>

                        <div class="clear0px"></div>

                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
            <div class="clear5px"></div>
            <uc3:NewPagging ID="NewPagging1" runat="server" />
            <div class="clear5px"></div>
        </div>
    </div>
    <div class="clear5px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    <uc4:BottomCategory ID="BottomCategory1" runat="server" />
    <div class="clear5px">
    </div>
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
</div>