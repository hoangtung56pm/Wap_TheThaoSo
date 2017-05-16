<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HinhNen_New.ascx.cs" Inherits="Wap_TheThaoSo.HinhNen.UserControl.HinhNen_New" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="DownloadPagging.ascx" TagName="DownloadPagging" TagPrefix="uc2" %>
<%@ Register Src="NewPagging.ascx" TagName="NewPagging" TagPrefix="uc3" %>
<%@ Register Src="../../TinTuc/UserControl/BottomCategory.ascx" TagName="BottomCategory" TagPrefix="uc4" %>

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
                            <a href="<%# UrlProcess.GetHinhNenDetailNewUrl(0,ConvertUtility.ToInt32(Eval("AlbumId").ToString())) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("AlbumAvatar"),100,90) %>" />
                            </a>
                        </div>

                        <a class="link-title" href="<%# UrlProcess.GetHinhNenDetailNewUrl(0,ConvertUtility.ToInt32(Eval("AlbumId").ToString())) %>">
                            <%# Eval("AlbumName") %>
                        </a>
                        <br />
                        <span class="font12px italic">
                            <%# ConvertUtility.ToDateTime(Eval("CreateDate")).ToString("dd/MM/yyyy hh:mm")%>
                         </span>

                        <p style="margin:0px;" class="justify lineheight padding-right7px margin-left5px font12px">
                            <%# AppEnv.TrimLength(Eval("AlbumDetail").ToString(), 85)%>
                        </p>

                        <div class="clear0px"></div>

                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="item-alternate">
                       
                         <div class="image">
                            <a href="<%# UrlProcess.GetHinhNenDetailNewUrl(0,ConvertUtility.ToInt32(Eval("AlbumId").ToString())) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("AlbumAvatar"),100,90) %>" />
                            </a>
                        </div>
                        <a class="link-title" href="<%# UrlProcess.GetHinhNenDetailNewUrl(0,ConvertUtility.ToInt32(Eval("AlbumId").ToString())) %>">
                            <%# Eval("AlbumName") %>
                        </a>
                        <br />
                        <span class="font12px italic">
                            <%# ConvertUtility.ToDateTime(Eval("CreateDate")).ToString("dd/MM/yyyy hh:mm")%>
                        </span>

                        <p style="margin-bottom:3px;margin-top:3px;" class="justify lineheight padding-right7px margin-left5px font12px">
                            <%# AppEnv.TrimLength(Eval("AlbumDetail").ToString(), 85)%>
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