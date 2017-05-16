<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HinhNenChiTiet_New.ascx.cs" Inherits="Wap_TheThaoSo.HinhNen.UserControl.HinhNenChiTiet_New" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="NewPagging.ascx" TagName="Pagging" TagPrefix="uc2" %>
<%@ Register Src="../../TinTuc/UserControl/BottomCategory.ascx" TagName="BottomCategory"
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
                        <a href="<%= UrlProcess.GetHinhNenHomeNewUrl() %>">Ảnh Đẹp </a>
                    </div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <div class="text-detail">
                    <a href="javascript:void(0)" class="bold color-red font16px">
                        <%= AlbumName %>
                    </a>
                    <div class="sapo font14px">
                        <%= AlbumDetail %>
                    </div>
                    <div align="center">
                        <%--Body--%>

                       <a href="javascript:void(0)"> Click vào hình để tải ảnh về máy </a>
                        <div class="clear2px"></div>

                        <asp:Repeater ID="rptAlbumDetail" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <a href="<%# AppEnv.GetSetting("urldata") + Eval("PicAvatar") %>">
                                    <img alt="" src="<%# AppEnv.GetAvatar(Eval("PicAvatar"),310,200) %>" />
                                </a>
                                <div class="clear2px"></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="clear2px">
                </div>
                <div class="clear5px">
                </div>
                <div class="other-news">
                    <div class="clear5px">
                    </div>
                    <div style="background-color: #b10228; height: 1px; width: 100%; float: left; margin-top: 8px;">
                        <b class="color-red" style="position: absolute; margin-top: -7px; background-color: #fff;
                            padding-left: 5px;">Các Album khác</b>
                    </div>
                    <div class="clear5px">
                    </div>
                    <div class="clear5px">
                    </div>
                    <ul>
                        <asp:Repeater ID="rptOtherNews" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li><a href="<%# UrlProcess.GetHinhNenDetailNewUrl(0,ConvertUtility.ToInt32(Eval("AlbumId").ToString())) %>">
                                    <%# Eval("AlbumName")%>
                                </a><span class="font12px italic">(<%# AppEnv.ToTimeSinceString(ConvertUtility.ToDateTime(Eval("CreateDate")))%>)</span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear5px">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clear5px">
    </div>
    <div style="height: 1px; background-color: #b5b5b5">
    </div>
    <uc4:BottomCategory ID="BottomCategory1" runat="server" />
    <uc1:GiaiTri ID="GiaiTri1" runat="server" />
    <div class="clear5px">
    </div>
</div>