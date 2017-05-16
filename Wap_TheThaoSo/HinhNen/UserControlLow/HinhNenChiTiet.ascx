﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HinhNenChiTiet.ascx.cs" Inherits="Wap_TheThaoSo.HinhNen.UserControlLow.HinhNenChiTiet" %>

<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControlLow/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="../../HinhNen/UserControl/NewPagging.ascx" TagName="Pagging" TagPrefix="uc2" %>
<%@ Register Src="../../TinTuc/UserControlLow/BottomCategory.ascx" TagName="BottomCategory" TagPrefix="uc4" %>

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
                        <a href="javascript:void(0)">Hình nền</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
                <asp:Repeater ID="rptContentTop" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="image">
                            <img alt="" src="<%# AppEnv.GetSetting("urldata1") + Eval("WThumnail").ToString().Replace("~/Upload","/Upload") %>" />
                        </div>
                        <div class="text">
                            <a href="#">
                                <%# Eval("WTitle") %></a>
                            <div class="clearright1px">
                            </div>
                            <div class="justify lineheight">
                                <%# Eval("Download") %>
                                lượt tải</div>
                            <div class="clearright1px">
                            </div>
                            <div class="justify lineheight">
                                Giá tải: <%= Price %>/lượt
                             </div>
                            <div class="clearright1px">
                            </div>
                            <div class="taive">
                                <a class="link_taive" href="<%# UrlProcess.GetWallpaperDownloadLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("W_WItemId")), CatID.ToString()) %>">
                                    <img alt="" src="/layout/images/icon-taive.png" />Tải về</a>
                            </div>
                            <div class="clearright2px">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


                <div class="clear7px">
                </div>
                <div style="height: 1px; background-color: #b5b5b5">
                </div>
                <div class="clear2px">
                </div>
            </div>
        </div>
        <div class="clear5px">
        </div>
        <div class="background-xam-e0e0e0 height22px lineheight22">
            <b class="padding-left5px">Các hình nền khác</b>
        </div>
        <div class="home_conent_bottom">
            <asp:Repeater ID="rptContentBottom" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item-video">
                        <div class="image">
                            <a href="<%# UrlProcess.GetHinhNenDetailLowUrl(ConvertUtility.ToInt32(Eval("W_WItemId"))) %>">
                                <img alt="" src="<%# AppEnv.GetSetting("urldata1") + Eval("WThumnail").ToString().Replace("~/Upload","/Upload") %>" />
                            </a>
                        </div>
                        <div class="text margin-left3px">
                            <a href="<%# UrlProcess.GetHinhNenDetailLowUrl(ConvertUtility.ToInt32(Eval("W_WItemId"))) %>">
                                <%# Eval("WTitle") %></a>
                            <div class="clear5px">
                            </div>
                            <div class="justify lineheight">
                                Lượt tải:
                                <%# Eval("Download") %></div>
                            <div class="clear5px">
                            </div>
                            <div class="justify lineheight">
                                Giá tải: <%= Price %>/lượt
                                </div>
                            <div class="clear5px">
                            </div>
                            <a href="<%# UrlProcess.GetWallpaperDownloadLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("W_WItemId")), CatID.ToString()) %>">
                                Tải</a> 
                        </div>
                        <div class="clear0px">
                        </div>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="item-video-alternate">
                        <div class="image">
                            <a href="<%# UrlProcess.GetHinhNenDetailLowUrl(ConvertUtility.ToInt32(Eval("W_WItemId"))) %>">
                                <img alt="" src="<%# AppEnv.GetSetting("urldata1") + Eval("WThumnail").ToString().Replace("~/Upload","/Upload") %>" />
                            </a>
                        </div>
                        <div class="text margin-left3px">
                            <a href="<%# UrlProcess.GetHinhNenDetailLowUrl(ConvertUtility.ToInt32(Eval("W_WItemId"))) %>">
                                <%# Eval("WTitle") %></a>
                            <div class="clear5px">
                            </div>
                            <div class="justify lineheight">
                                Lượt tải:
                                <%# Eval("Download") %></div>
                            <div class="clear5px">
                            </div>
                            <div class="justify lineheight">
                                Giá tải: <%= Price %>/lượt
                             </div>
                            <div class="clear5px">
                            </div>
                            <a href="<%# UrlProcess.GetWallpaperDownloadLowUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("W_WItemId")), CatID.ToString()) %>">
                                Tải</a> 
    
                        </div>
                        <div class="clear0px">
                        </div>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
            <div class="clear10px">
            </div>
            <uc2:Pagging ID="Pagging1" runat="server" />
            <div class="clear5px">
            </div>
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