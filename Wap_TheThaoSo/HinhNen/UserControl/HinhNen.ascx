<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HinhNen.ascx.cs" Inherits="Wap_TheThaoSo.HinhNen.UserControl.HinhNen" %>
<%@ Import Namespace="Wap_TheThaoSo.Library" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.UrlProcess" %>
<%@ Import Namespace="Wap_TheThaoSo.Library.Utilities" %>
<%@ Register Src="../../Wap/UserControl/GiaiTri.ascx" TagName="GiaiTri" TagPrefix="uc1" %>
<%@ Register Src="DownloadPagging.ascx" TagName="DownloadPagging" TagPrefix="uc2" %>
<%@ Register Src="NewPagging.ascx" TagName="NewPagging" TagPrefix="uc3" %>
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
                        <a href="javascript:void(0)">Hình nền</a></div>
                    <div class="red-separator margin-right2px">
                    </div>
                </div>
                <div class="clear5px">
                </div>
            </div>
        </div>
        <div class="clear5px">
        </div>
        <div class="background-xam-e0e0e0 height22px lineheight22">
            <b class="padding-left5px">Mới cập nhật</b>
        </div>
        <div class="home_conent_bottom">
            <div class="hinhanh">
                <asp:Repeater ID="rptMoiCapNhat" runat="server">
                    <ItemTemplate>
                        <div class="item">
                            <div class="image">
                                <a href="<%# UrlProcess.GetHinhNenDetailUrl(ConvertUtility.ToInt32(Eval("W_WItemId"))) %>">
                                    <img alt="" src="<%# AppEnv.GetSetting("urldata1") + Eval("WThumnail").ToString().Replace("~/Upload","/Upload") %>" />
                                </a>
                            </div>
                            <div class="text">
                                <a href="<%# UrlProcess.GetHinhNenDetailUrl(ConvertUtility.ToInt32(Eval("W_WItemId"))) %>">
                                    <%# Eval("WTitle") %></a>
                                <div class="clear5px">
                                </div>
                                <div class="floatleft">
                                    Lượt tải:
                                    <%# Eval("Download") %></div>
                                <div class="clear2px">
                                </div>
                                <div class="tai">
                                     <a href="<%# UrlProcess.GetWallpaperDownloadUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("W_WItemId")), CatID.ToString()) %>">
                                      Tải (<%= Price %>/lượt) </a>
                                        
                                       <%-- <b class="floatleft padding-left5px padding-right5px">
                                        |</b><a href="<%# UrlProcess.GetHinhNenDetailUrl(ConvertUtility.ToInt32(Eval("W_WItemId"))) %>">
                                            Tặng</a>--%>
                                </div>
                            </div>
                            <div class="clear0px">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear5px">
                </div>
                <uc3:NewPagging ID="NewPagging1" runat="server" />
                <div class="clear5px">
                </div>

                <div align="right"><i>Giá tải hình nền: <%= Price %>/lượt</i></div>

            </div>
        </div>
        <div class="clear5px">
        </div>
        <div class="background-xam-e0e0e0 height22px lineheight22">
            <b class="padding-left5px">Tải nhiều nhất</b>
        </div>
        <div class="home_conent_bottom">
            <div class="hinhanh">
                <asp:Repeater ID="rptTaiNhieuNhat" runat="server">
                    <ItemTemplate>
                        <div class="item">
                            <div class="image">
                                <a href="<%# UrlProcess.GetHinhNenDetailUrl(ConvertUtility.ToInt32(Eval("W_WItemId")))  %>">
                                    <img alt="" src="<%# AppEnv.GetSetting("urldata1") + Eval("WThumnail").ToString().Replace("~/Upload","/Upload") %>" />
                                </a>
                            </div>
                            <div class="text">
                                <a href="<%# UrlProcess.GetHinhNenDetailUrl(ConvertUtility.ToInt32(Eval("W_WItemId"))) %>">
                                    <%# Eval("WTitle") %></a>
                                <div class="clear5px">
                                </div>
                                <div class="floatleft">
                                    Lượt tải:
                                    <%# Eval("Download") %></div>
                                <div class="clear2px">
                                </div>
                                <div class="tai">
                                     <a href="<%# UrlProcess.GetWallpaperDownloadUrl(Lang.ToString(),Width.ToString(), ConvertUtility.ToString(Eval("W_WItemId")), CatID.ToString()) %>">
                                        Tải (<%= Price %>/lượt)</a> 
                                        
                                        <%--<b class="floatleft padding-left5px padding-right5px">|</b><a href="<%# UrlProcess.GetHinhNenDetailUrl(ConvertUtility.ToInt32(Eval("W_WItemId"))) %>">
                                            Tặng</a>--%>
                                            
                                    </div>
                            </div>
                            <div class="clear0px">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear5px">
                </div>
                <uc2:DownloadPagging ID="DownloadPagging1" runat="server" Visible="false" />
                <div class="clear5px">
                </div>
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
